using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class ChiTietGioHangDAO
    {
        public async Task<List<MucGioHang>> LayDanhSach(int maGioHang)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await (
                from chiTiet in db.ChiTietGioHang.AsNoTracking()
                join ve in db.Ve.AsNoTracking() on chiTiet.MaVe equals ve.MaVe
                where chiTiet.MaGioHang == maGioHang
                orderby chiTiet.MaChiTietGioHang descending
                select new
                {
                    ChiTiet = chiTiet,
                    Ve = ve,
                    SoLuongDaBan = (
                        from chiTietHoaDon in db.ChiTietHoaDon.AsNoTracking()
                        join hoaDon in db.HoaDon.AsNoTracking() on chiTietHoaDon.MaHoaDon equals hoaDon.MaHoaDon
                        where chiTietHoaDon.MaVe == chiTiet.MaVe &&
                              chiTietHoaDon.NgaySuDung == chiTiet.NgaySuDung &&
                              hoaDon.TrangThai == "DaThanhToan"
                        select (int?)(chiTietHoaDon.SoLuongNguoiLon + chiTietHoaDon.SoLuongTreEm + chiTietHoaDon.SoLuongNguoiCaoTuoi)
                    ).Sum() ?? 0
                }).ToListAsync();

            return duLieu.Select(x => new MucGioHang
            {
                MaChiTietGioHang = x.ChiTiet.MaChiTietGioHang,
                MaGioHang = x.ChiTiet.MaGioHang,
                Ve = new Ve
                {
                    MaVe = x.ChiTiet.MaVe,
                    TenVe = x.Ve.TenVe,
                    SoLuong = Math.Max(0, x.Ve.SoLuong - x.SoLuongDaBan),
                    GiaNguoiLon = x.Ve.GiaNguoiLon,
                    GiaTreEm = x.Ve.GiaTreEm,
                    GiaNguoiCaoTuoi = x.Ve.GiaNguoiCaoTuoi,
                    MoTa = x.Ve.MoTa,
                    ThongTinVe = x.Ve.ThongTinVe,
                    AnhVe = x.Ve.AnhVe
                },
                NgaySuDung = x.ChiTiet.NgaySuDung,
                SoLuongNguoiLon = x.ChiTiet.SoLuongNguoiLon,
                SoLuongTreEm = x.ChiTiet.SoLuongTreEm,
                SoLuongNguoiCaoTuoi = x.ChiTiet.SoLuongNguoiCaoTuoi
            }).ToList();
        }

        public async Task<MucGioHang?> LayTheoVeVaNgay(int maGioHang, int maVe, DateTime ngaySuDung)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.ChiTietGioHang
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.MaGioHang == maGioHang &&
                    x.MaVe == maVe &&
                    x.NgaySuDung == ngaySuDung.Date);

            if (duLieu == null)
            {
                return null;
            }

            return new MucGioHang
            {
                MaChiTietGioHang = duLieu.MaChiTietGioHang,
                MaGioHang = duLieu.MaGioHang,
                Ve = new Ve { MaVe = duLieu.MaVe },
                NgaySuDung = duLieu.NgaySuDung,
                SoLuongNguoiLon = duLieu.SoLuongNguoiLon,
                SoLuongTreEm = duLieu.SoLuongTreEm,
                SoLuongNguoiCaoTuoi = duLieu.SoLuongNguoiCaoTuoi
            };
        }

        public async Task<int> LayTongSoLuongTheoVeVaNgay(int maGioHang, int maVe, DateTime ngaySuDung, int? maChiTietBoQua = null)
        {
            using var db = DuLieuContext.TaoMoi();
            var ngay = ngaySuDung.Date;
            var truyVan = db.ChiTietGioHang
                .AsNoTracking()
                .Where(x => x.MaGioHang == maGioHang &&
                            x.MaVe == maVe &&
                            x.NgaySuDung == ngay);

            if (maChiTietBoQua.HasValue)
            {
                truyVan = truyVan.Where(x => x.MaChiTietGioHang != maChiTietBoQua.Value);
            }

            return await truyVan.SumAsync(x => (int?)(x.SoLuongNguoiLon + x.SoLuongTreEm + x.SoLuongNguoiCaoTuoi)) ?? 0;
        }

        public async Task<int> Them(MucGioHang muc)
        {
            using var db = DuLieuContext.TaoMoi();
            var chiTiet = new ChiTietGioHangDuLieu
            {
                MaGioHang = muc.MaGioHang,
                MaVe = muc.Ve.MaVe,
                NgaySuDung = muc.NgaySuDung.Date,
                SoLuongNguoiLon = muc.SoLuongNguoiLon,
                SoLuongTreEm = muc.SoLuongTreEm,
                SoLuongNguoiCaoTuoi = muc.SoLuongNguoiCaoTuoi,
                DonGiaNguoiLon = muc.Ve.GiaNguoiLon,
                DonGiaTreEm = muc.Ve.GiaTreEm,
                DonGiaNguoiCaoTuoi = muc.Ve.GiaNguoiCaoTuoi
            };

            db.ChiTietGioHang.Add(chiTiet);
            await db.SaveChangesAsync();
            return chiTiet.MaChiTietGioHang;
        }

        public async Task CapNhat(MucGioHang muc)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.ChiTietGioHang.FirstOrDefaultAsync(x => x.MaChiTietGioHang == muc.MaChiTietGioHang);
            if (duLieu == null)
            {
                return;
            }

            duLieu.NgaySuDung = muc.NgaySuDung.Date;
            duLieu.SoLuongNguoiLon = muc.SoLuongNguoiLon;
            duLieu.SoLuongTreEm = muc.SoLuongTreEm;
            duLieu.SoLuongNguoiCaoTuoi = muc.SoLuongNguoiCaoTuoi;
            duLieu.DonGiaNguoiLon = muc.Ve.GiaNguoiLon;
            duLieu.DonGiaTreEm = muc.Ve.GiaTreEm;
            duLieu.DonGiaNguoiCaoTuoi = muc.Ve.GiaNguoiCaoTuoi;
            await db.SaveChangesAsync();
        }

        public async Task Xoa(int maChiTietGioHang)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.ChiTietGioHang.FirstOrDefaultAsync(x => x.MaChiTietGioHang == maChiTietGioHang);
            if (duLieu == null)
            {
                return;
            }

            db.ChiTietGioHang.Remove(duLieu);
            await db.SaveChangesAsync();
        }

        public async Task XoaTheoGioHang(int maGioHang)
        {
            using var db = DuLieuContext.TaoMoi();
            var danhSach = await db.ChiTietGioHang
                .Where(x => x.MaGioHang == maGioHang)
                .ToListAsync();

            if (danhSach.Count == 0)
            {
                return;
            }

            db.ChiTietGioHang.RemoveRange(danhSach);
            await db.SaveChangesAsync();
        }
    }
}
