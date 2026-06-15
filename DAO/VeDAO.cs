using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class VeDAO
    {
        public async Task<List<Ve>> LayDanhSachVe(int? maLoaiVe)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = db.Ve
                .AsNoTracking()
                .Where(x => x.TrangThai);

            if (maLoaiVe.HasValue && maLoaiVe.Value > 0)
            {
                truyVan = truyVan.Where(x => x.MaLoaiVe == maLoaiVe.Value);
            }

            return await truyVan
                .OrderBy(x => x.GiaVe)
                .ToListAsync();
        }

        public async Task<List<Ve>> LayDanhSachVeQuanLy()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.Ve
                .AsNoTracking()
                .Where(x => x.TrangThai)
                .OrderBy(x => x.GiaVe)
                .ToListAsync();
        }

        public async Task<int> LaySoLuongConLaiTheoNgay(int maVe, DateTime ngaySuDung)
        {
            using var db = DuLieuContext.TaoMoi();
            var sucChuaMoiNgay = await db.Ve
                .AsNoTracking()
                .Where(x => x.MaVe == maVe && x.TrangThai)
                .Select(x => (int?)x.SoLuong)
                .FirstOrDefaultAsync();

            if (!sucChuaMoiNgay.HasValue)
            {
                throw new InvalidOperationException("Vé không tồn tại hoặc đã ngừng bán.");
            }

            var ngay = ngaySuDung.Date;
            var soLuongDaBan = await (
                from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                join hoaDon in db.HoaDon.AsNoTracking() on chiTiet.MaHoaDon equals hoaDon.MaHoaDon
                where chiTiet.MaVe == maVe &&
                      chiTiet.NgaySuDung == ngay &&
                      hoaDon.TrangThai == "DaThanhToan"
                select (int?)(chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi)
            ).SumAsync() ?? 0;

            return Math.Max(0, sucChuaMoiNgay.Value - soLuongDaBan);
        }

        public async Task<int> ThemVe(Ve ve)
        {
            using var db = DuLieuContext.TaoMoi();
            ve.TrangThai = true;
            db.Ve.Add(ve);
            await db.SaveChangesAsync();
            return ve.MaVe;
        }

        public async Task SuaVe(Ve ve)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.Ve.FirstOrDefaultAsync(x => x.MaVe == ve.MaVe);
            if (duLieu == null)
            {
                return;
            }

            duLieu.MaLoaiVe = ve.MaLoaiVe;
            duLieu.TenVe = ve.TenVe;
            duLieu.GiaVe = ve.GiaVe;
            duLieu.GiaNguoiLon = ve.GiaNguoiLon;
            duLieu.GiaTreEm = ve.GiaTreEm;
            duLieu.GiaNguoiCaoTuoi = ve.GiaNguoiCaoTuoi;
            duLieu.SoLuong = ve.SoLuong;
            duLieu.MoTa = ve.MoTa;
            duLieu.ThongTinVe = ve.ThongTinVe;
            duLieu.AnhVe = ve.AnhVe;
            await db.SaveChangesAsync();
        }

        public async Task XoaVe(int maVe)
        {
            using var db = DuLieuContext.TaoMoi();
            using var giaoDich = await db.Database.BeginTransactionAsync();

            var chiTietGioHangCanXoa = await db.ChiTietGioHang
                .Where(x => x.MaVe == maVe)
                .ToListAsync();
            db.ChiTietGioHang.RemoveRange(chiTietGioHangCanXoa);

            var chiTietHoaDonCanXoa = await db.ChiTietHoaDon
                .Where(x => x.MaVe == maVe)
                .ToListAsync();
            db.ChiTietHoaDon.RemoveRange(chiTietHoaDonCanXoa);

            var ve = await db.Ve.FirstOrDefaultAsync(x => x.MaVe == maVe);
            if (ve != null)
            {
                db.Ve.Remove(ve);
            }

            await db.SaveChangesAsync();
            await giaoDich.CommitAsync();
        }
    }
}
