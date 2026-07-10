using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class BaoCaoDAO
    {
        public async Task<List<BaoCaoVeDTO>> LayDanhSachVe()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.Ve
                .AsNoTracking()
                .Where(ve => ve.TrangThai)
                .Join(
                    db.LoaiVe.AsNoTracking(),
                    ve => ve.MaLoaiVe,
                    loaiVe => loaiVe.MaLoaiVe,
                    (ve, loaiVe) => new BaoCaoVeDTO
                    {
                        MaVe = ve.MaVe,
                        TenVe = ve.TenVe,
                        MaLoaiVe = ve.MaLoaiVe,
                        TenLoaiVe = loaiVe.TenLoaiVe,
                        GiaVe = ve.GiaVe,
                        GiaNguoiLon = ve.GiaNguoiLon,
                        GiaTreEm = ve.GiaTreEm,
                        GiaNguoiCaoTuoi = ve.GiaNguoiCaoTuoi,
                        SoLuongConLai = ve.SoLuong,
                        TrangThai = ve.TrangThai
                    })
                .OrderBy(x => x.TenLoaiVe)
                .ThenBy(x => x.TenVe)
                .ToListAsync();
        }

        public async Task<List<BaoCaoDoanhThu>> LayBaoCaoDoanhThu(DateTime? tuNgay, DateTime? denNgay, bool theoThang)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVanHoaDon = ApDungBoLocNgay(
                db.HoaDon
                    .AsNoTracking()
                    .Where(x => x.TrangThai == "DaThanhToan"),
                tuNgay,
                denNgay);

            var danhSachHoaDon = await truyVanHoaDon
                .Select(hoaDon => new
                {
                    hoaDon.MaHoaDon,
                    hoaDon.NgayLap,
                    hoaDon.TongTien,
                    hoaDon.TienGiam
                })
                .ToListAsync();

            if (danhSachHoaDon.Count == 0)
            {
                return new List<BaoCaoDoanhThu>();
            }

            var danhSachMaHoaDon = danhSachHoaDon.Select(x => x.MaHoaDon).ToList();
            var danhSachSoVeTheoHoaDon = await db.ChiTietHoaDon
                .AsNoTracking()
                .Where(chiTiet => danhSachMaHoaDon.Contains(chiTiet.MaHoaDon))
                .GroupBy(chiTiet => chiTiet.MaHoaDon)
                .Select(g => new
                {
                    MaHoaDon = g.Key,
                    TongSoVe = g.Sum(chiTiet => chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi)
                })
                .ToListAsync();

            var soVeTheoHoaDon = danhSachSoVeTheoHoaDon.ToDictionary(x => x.MaHoaDon, x => x.TongSoVe);
            var danhSachDuLieu = danhSachHoaDon
                .Select(hoaDon => new
                {
                    hoaDon.MaHoaDon,
                    hoaDon.NgayLap,
                    hoaDon.TongTien,
                    hoaDon.TienGiam,
                    TongSoVe = soVeTheoHoaDon.TryGetValue(hoaDon.MaHoaDon, out var tongSoVe) ? tongSoVe : 0
                })
                .ToList();

            if (theoThang)
            {
                var duLieuTheoThang = danhSachDuLieu
                    .GroupBy(x => new { x.NgayLap.Year, x.NgayLap.Month })
                    .Select(g => new
                    {
                        g.Key.Year,
                        g.Key.Month,
                        TongHoaDon = g.Count(),
                        TongSoVe = g.Sum(x => x.TongSoVe),
                        TongTien = g.Sum(x => x.TongTien),
                        TongGiamGia = g.Sum(x => x.TienGiam),
                        TongThanhTien = g.Sum(x => x.TongTien - x.TienGiam)
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToList();

                return duLieuTheoThang
                    .Select(x => new BaoCaoDoanhThu
                    {
                        NgayBaoCao = $"{x.Month:00}/{x.Year}",
                        SoHoaDon = x.TongHoaDon,
                        TongSoVe = x.TongSoVe,
                        TongTien = x.TongTien,
                        TongTienGiam = x.TongGiamGia,
                        TongThanhTien = x.TongThanhTien
                    })
                    .ToList();
            }

            var duLieuTheoNgay = danhSachDuLieu
                .GroupBy(x => x.NgayLap.Date)
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongHoaDon = g.Count(),
                    TongSoVe = g.Sum(x => x.TongSoVe),
                    TongTien = g.Sum(x => x.TongTien),
                    TongGiamGia = g.Sum(x => x.TienGiam),
                    TongThanhTien = g.Sum(x => x.TongTien - x.TienGiam)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            return duLieuTheoNgay
                .Select(x => new BaoCaoDoanhThu
                {
                    NgayBaoCao = x.Ngay.ToString("dd/MM/yyyy"),
                    SoHoaDon = x.TongHoaDon,
                    TongSoVe = x.TongSoVe,
                    TongTien = x.TongTien,
                    TongTienGiam = x.TongGiamGia,
                    TongThanhTien = x.TongThanhTien
                })
                .ToList();
        }

        public async Task<List<BaoCaoVeBanChayTheoLoai>> LayBaoCaoVeBanChayTheoLoai(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                          join hoaDon in db.HoaDon.AsNoTracking() on chiTiet.MaHoaDon equals hoaDon.MaHoaDon
                          join ve in db.Ve.AsNoTracking() on chiTiet.MaVe equals ve.MaVe
                          join loaiVe in db.LoaiVe.AsNoTracking() on ve.MaLoaiVe equals loaiVe.MaLoaiVe
                          where hoaDon.TrangThai == "DaThanhToan"
                          select new
                          {
                              loaiVe.MaLoaiVe,
                              loaiVe.TenLoaiVe,
                              hoaDon.NgayLap,
                              SoVeDaBan = chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi,
                              chiTiet.ThanhTien
                          };

            if (tuNgay.HasValue)
            {
                truyVan = truyVan.Where(x => x.NgayLap >= tuNgay.Value.Date);
            }

            if (denNgay.HasValue)
            {
                var mocDenNgay = denNgay.Value.Date.AddDays(1);
                truyVan = truyVan.Where(x => x.NgayLap < mocDenNgay);
            }

            return await truyVan
                .GroupBy(x => new { x.MaLoaiVe, x.TenLoaiVe })
                .Select(g => new BaoCaoVeBanChayTheoLoai
                {
                    MaLoaiVe = g.Key.MaLoaiVe,
                    TenLoaiVe = g.Key.TenLoaiVe,
                    SoVeDaBan = g.Sum(x => x.SoVeDaBan),
                    TongThanhTien = g.Sum(x => x.ThanhTien)
                })
                .OrderByDescending(x => x.SoVeDaBan)
                .ThenByDescending(x => x.TongThanhTien)
                .ToListAsync();
        }

        private static IQueryable<HoaDonDuLieu> ApDungBoLocNgay(IQueryable<HoaDonDuLieu> truyVan, DateTime? tuNgay, DateTime? denNgay)
        {
            if (tuNgay.HasValue)
            {
                truyVan = truyVan.Where(x => x.NgayLap >= tuNgay.Value.Date);
            }

            if (denNgay.HasValue)
            {
                var mocDenNgay = denNgay.Value.Date.AddDays(1);
                truyVan = truyVan.Where(x => x.NgayLap < mocDenNgay);
            }

            return truyVan;
        }
    }
}
