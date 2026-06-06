from __future__ import annotations

import argparse
import datetime as dt
import re
import sys
import time
import unicodedata
from dataclasses import dataclass
from pathlib import Path
from urllib.parse import parse_qs, urlparse

import requests


DEFAULT_URL = (
    "https://booking.vinwonders.com/vi-VND/search?"
    "code=PQVW1&usingDate=31-05-2026&style=b&tab=all"
)


@dataclass
class TicketRow:
    ten_ve: str
    gia_ve: int
    gia_nguoi_lon: int
    gia_tre_em: int
    gia_nguoi_cao_tuoi: int
    so_luong: int
    mo_ta: str
    thong_tin_ve: str
    anh_ve: str | None = None


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description="Crawl VinWonders tickets and export SQL Server INSERT statements."
    )
    parser.add_argument("--url", default=DEFAULT_URL, help="VinWonders search URL.")
    parser.add_argument("--output", default="vinwonders_ve_insert.txt", help="Output .txt file.")
    parser.add_argument("--ma-loai-ve", type=int, default=3, help="Default MaLoaiVe used in INSERT.")
    parser.add_argument("--so-luong", type=int, default=1000, help="Default stock quantity.")
    parser.add_argument("--headful", action="store_true", help="Show browser window while crawling.")
    parser.add_argument("--wait", type=int, default=10, help="Seconds to wait for page rendering.")
    return parser.parse_args()


def normalize_text(value: str) -> str:
    value = unicodedata.normalize("NFKC", value or "")
    return re.sub(r"\s+", " ", value).strip()


def parse_money(value: str) -> int:
    if not value:
        return 0
    match = re.search(r"(\d[\d.]*)\s*(?:vn[d\u0111]|vnd)", value, flags=re.IGNORECASE)
    if not match:
        return 0
    return int(match.group(1).replace(".", ""))


def sql_nvarchar(value: str | None) -> str:
    if value is None or value == "":
        return "NULL"
    escaped = value.replace("'", "''")
    escaped = escaped.replace("\r\n", "\n").replace("\r", "\n").replace("\n", "\\n")
    return f"N'{escaped}'"


def extract_query(url: str) -> tuple[str, str]:
    query = parse_qs(urlparse(url).query)
    code = (query.get("code") or ["PQVW1"])[0]
    using_date = (query.get("usingDate") or ["31-05-2026"])[0]
    return code, using_date


def to_api_date(using_date: str) -> str:
    for fmt in ("%d-%m-%Y", "%d/%m/%Y", "%Y-%m-%d", "%Y/%m/%d"):
        try:
            return dt.datetime.strptime(using_date, fmt).strftime("%Y/%m/%d")
        except ValueError:
            pass
    return using_date


def fetch_listing_metadata(code: str) -> dict[str, dict]:
    url = "https://booking-tour-api.vinpearl.com/api/bwc/vinwonder/vinwonderinfo"
    params = {
        "PageIndex": 1,
        "PageSize": 100,
        "SupplierCode": code,
        "Channel": 10,
        "VinWonderTagGroupCode": "all",
    }
    headers = {
        "User-Agent": "Mozilla/5.0",
        "accept-language": "vi-VN",
        "x-supplier-code": code,
        "origin": "https://booking.vinwonders.com",
        "referer": "https://booking.vinwonders.com/",
    }
    response = requests.get(url, params=params, headers=headers, timeout=30)
    response.raise_for_status()
    payload = response.json().get("data", {})
    result = payload.get("result") or []
    metadata: dict[str, dict] = {}
    for item in result:
        for candidate in ticket_names_from_api(item):
            metadata[normalize_key(candidate)] = item
    return metadata


def ticket_names_from_api(item: dict) -> list[str]:
    names: list[str] = []
    if item.get("ticketName"):
        names.append(item["ticketName"])
    for group_key in ("ticketI18nResponses", "touri18nResponses"):
        for translation in item.get(group_key) or []:
            if translation.get("languageCode") == "vi-VN":
                for key in ("name", "tourName"):
                    if translation.get(key):
                        names.append(translation[key])
    return names


def normalize_key(value: str) -> str:
    value = normalize_text(value).lower()
    value = re.sub(r"^\[[^\]]+\]\s*-\s*", "", value)
    return value


def scrape_rendered_tickets(url: str, code: str, so_luong: int, headful: bool, wait: int) -> list[TicketRow]:
    try:
        from selenium import webdriver
        from selenium.webdriver.chrome.options import Options
        from selenium.webdriver.common.by import By
        from selenium.webdriver.support import expected_conditions as ec
        from selenium.webdriver.support.ui import WebDriverWait
    except ImportError as exc:
        raise RuntimeError("Missing Selenium. Install with: pip install selenium") from exc

    options = Options()
    if not headful:
        options.add_argument("--headless=new")
    options.add_argument("--disable-gpu")
    options.add_argument("--window-size=1365,2000")
    options.add_argument("--lang=vi-VN")

    driver = webdriver.Chrome(options=options)
    rows: list[TicketRow] = []
    try:
        driver.get(url)
        WebDriverWait(driver, wait).until(ec.presence_of_element_located((By.CSS_SELECTOR, ".item-card-v2")))
        time.sleep(2)

        for _ in range(5):
            driver.execute_script("window.scrollTo(0, document.body.scrollHeight)")
            time.sleep(0.8)

        cards = driver.find_elements(By.CSS_SELECTOR, ".item-card-v2")
        for index in range(len(cards)):
            cards = driver.find_elements(By.CSS_SELECTOR, ".item-card-v2")
            card = cards[index]
            row = parse_card(card, so_luong, url)
            prices = scrape_prices_from_choose_modal(driver, card)
            if prices:
                row.gia_nguoi_lon = prices.get("adult") or row.gia_ve
                row.gia_tre_em = prices.get("child") or row.gia_ve
                row.gia_nguoi_cao_tuoi = prices.get("senior") or row.gia_tre_em
                positive_prices = [
                    price
                    for price in (row.gia_nguoi_lon, row.gia_tre_em, row.gia_nguoi_cao_tuoi)
                    if price > 0
                ]
                if positive_prices:
                    row.gia_ve = min(positive_prices)
            rows.append(row)
    finally:
        driver.quit()

    return rows


def parse_card(card, so_luong: int, source_url: str) -> TicketRow:
    lines = [line.strip() for line in card.text.splitlines() if line.strip()]
    ten_ve = lines[0] if lines else "VinWonders ticket"
    gia_ve = parse_money(card.text)
    mo_ta_lines = [
        line
        for line in lines[1:]
        if line not in {"Xem chi tiet", "Xem chi ti\u1ebft", "Chon", "Ch\u1ecdn"}
        and "vn" not in line.lower()
        and not line.lower().startswith("chi tu")
        and not line.lower().startswith("ch\u1ec9 t\u1eeb")
    ]
    mo_ta = "\n".join(mo_ta_lines[:5])
    thong_tin = "\n".join(
        [
            ten_ve,
            "",
            mo_ta,
            "",
            f"Nguon crawl: {source_url}",
            f"Ngay crawl: {dt.datetime.now():%Y-%m-%d %H:%M:%S}",
        ]
    ).strip()
    fallback = gia_ve
    return TicketRow(
        ten_ve=ten_ve,
        gia_ve=fallback,
        gia_nguoi_lon=fallback,
        gia_tre_em=fallback,
        gia_nguoi_cao_tuoi=fallback,
        so_luong=so_luong,
        mo_ta=mo_ta,
        thong_tin_ve=thong_tin,
    )


def scrape_prices_from_choose_modal(driver, card) -> dict[str, int]:
    from selenium.webdriver.common.by import By
    from selenium.webdriver.common.keys import Keys

    prices: dict[str, int] = {}
    try:
        choose = card.find_element(By.CSS_SELECTOR, ".choose")
        driver.execute_script("arguments[0].scrollIntoView({block:'center'});", choose)
        time.sleep(0.2)
        driver.execute_script("arguments[0].click();", choose)
        time.sleep(1.2)
        drawer = driver.find_elements(By.CSS_SELECTOR, ".ant-drawer-open .ant-drawer-content")
        modal_text = drawer[-1].text if drawer else driver.find_element(By.TAG_NAME, "body").text
        prices = parse_modal_prices(modal_text)
        close_buttons = driver.find_elements(By.CSS_SELECTOR, ".ant-drawer-close")
        if close_buttons:
            driver.execute_script("arguments[0].click();", close_buttons[-1])
        else:
            driver.find_element(By.TAG_NAME, "body").send_keys(Keys.ESCAPE)
        time.sleep(0.3)
    except Exception:
        return prices
    return prices


def parse_modal_prices(body_text: str) -> dict[str, int]:
    tail = body_text[-2500:]
    labels = {
        "adult": r"Ng\u01b0\u1eddi l\u1edbn|Nguoi lon",
        "child": r"Tr\u1ebb em|Tre em",
        "senior": r"Ng\u01b0\u1eddi cao tu\u1ed5i|Nguoi cao tuoi",
    }
    prices: dict[str, int] = {}
    for key, label in labels.items():
        match = re.search(
            r"(?:" + label + r")(?P<section>.*?)(?:\n-|\n\+|-\n|$)",
            tail,
            flags=re.IGNORECASE | re.DOTALL,
        )
        if match:
            prices[key] = parse_money(match.group("section"))
    return prices


def enrich_with_api_images(rows: list[TicketRow], metadata: dict[str, dict]) -> None:
    for row in rows:
        item = metadata.get(normalize_key(row.ten_ve))
        if not item:
            continue
        # The WinForms app expects a local filename inside bin/.../image, so keep SQL AnhVe NULL.
        # The source image URL is kept in ThongTinVe for manual download when needed.
        image_url = first_image_url(item)
        if image_url:
            row.thong_tin_ve += f"\nAnh goc: {image_url}"


def first_image_url(item: dict) -> str | None:
    for group_key in ("ticketI18nResponses", "touri18nResponses"):
        for translation in item.get(group_key) or []:
            if translation.get("languageCode") != "vi-VN":
                continue
            image = translation.get("thumbImageView") or {}
            uri = image.get("fileUri")
            if uri:
                return uri if uri.startswith("http") else "https://" + uri
    return None


def build_sql(rows: list[TicketRow], ma_loai_ve: int, source_url: str, api_date: str) -> str:
    lines = [
        "-- Script insert ve crawl tu VinWonders",
        f"-- Source: {source_url}",
        f"-- Using date: {api_date}",
        f"-- Generated at: {dt.datetime.now():%Y-%m-%d %H:%M:%S}",
        "",
        f"DECLARE @MaLoaiVe INT = {ma_loai_ve};",
        "",
        "INSERT INTO Ve",
        "    (MaLoaiVe, TenVe, GiaVe, GiaNguoiLon, GiaTreEm, GiaNguoiCaoTuoi, SoLuong, MoTa, ThongTinVe, AnhVe, TrangThai)",
        "VALUES",
    ]
    value_lines = []
    for row in rows:
        value_lines.append(
            "    ("
            f"@MaLoaiVe, {sql_nvarchar(row.ten_ve)}, {row.gia_ve:.2f}, "
            f"{row.gia_nguoi_lon:.2f}, {row.gia_tre_em:.2f}, {row.gia_nguoi_cao_tuoi:.2f}, "
            f"{row.so_luong}, {sql_nvarchar(row.mo_ta)}, {sql_nvarchar(row.thong_tin_ve)}, "
            f"{sql_nvarchar(row.anh_ve)}, 1)"
        )
    lines.append(",\n".join(value_lines) + ";")
    lines.append("")
    return "\n".join(lines)


def main() -> int:
    args = parse_args()
    code, using_date = extract_query(args.url)
    api_date = to_api_date(using_date)

    print(f"Crawling {args.url}")
    metadata = fetch_listing_metadata(code)
    rows = scrape_rendered_tickets(args.url, code, args.so_luong, args.headful, args.wait)
    enrich_with_api_images(rows, metadata)

    if not rows:
        print("No tickets found.", file=sys.stderr)
        return 1

    output = Path(args.output)
    output.write_text(build_sql(rows, args.ma_loai_ve, args.url, api_date), encoding="utf-8")
    print(f"Exported {len(rows)} tickets to {str(output.resolve()).encode('unicode_escape').decode()}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
