using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class LoaiVeDAO
    {
        public async Task<List<LoaiVe>> LayDanhSachLoaiVe()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.LoaiVe
                .AsNoTracking()
                .Where(x => x.TrangThai)
                .OrderBy(x => x.TenLoaiVe)
                .ToListAsync();
        }

        public async Task<List<LoaiVe>> LayDanhSachLoaiVeQuanLy()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.LoaiVe
                .AsNoTracking()
                .Where(x => x.TrangThai)
                .OrderBy(x => x.TenLoaiVe)
                .ToListAsync();
        }

        public async Task<int> ThemLoaiVe(LoaiVe loaiVe)
        {
            using var db = DuLieuContext.TaoMoi();
            loaiVe.TrangThai = true;
            db.LoaiVe.Add(loaiVe);
            await db.SaveChangesAsync();
            return loaiVe.MaLoaiVe;
        }

        public async Task SuaLoaiVe(LoaiVe loaiVe)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.LoaiVe.FirstOrDefaultAsync(x => x.MaLoaiVe == loaiVe.MaLoaiVe);
            if (duLieu == null)
            {
                return;
            }

            duLieu.TenLoaiVe = loaiVe.TenLoaiVe;
            duLieu.MoTa = loaiVe.MoTa;
            await db.SaveChangesAsync();
        }

        public async Task XoaLoaiVe(int maLoaiVe)
        {
            using var db = DuLieuContext.TaoMoi();
            using var giaoDich = await db.Database.BeginTransactionAsync();

            var danhSachMaVe = await db.Ve
                .Where(x => x.MaLoaiVe == maLoaiVe)
                .Select(x => x.MaVe)
                .ToListAsync();

            if (danhSachMaVe.Count > 0)
            {
                var chiTietGioHangCanXoa = await db.ChiTietGioHang
                    .Where(x => danhSachMaVe.Contains(x.MaVe))
                    .ToListAsync();
                db.ChiTietGioHang.RemoveRange(chiTietGioHangCanXoa);

                var chiTietHoaDonCanXoa = await db.ChiTietHoaDon
                    .Where(x => danhSachMaVe.Contains(x.MaVe))
                    .ToListAsync();
                db.ChiTietHoaDon.RemoveRange(chiTietHoaDonCanXoa);

                var veCanXoa = await db.Ve
                    .Where(x => x.MaLoaiVe == maLoaiVe)
                    .ToListAsync();
                db.Ve.RemoveRange(veCanXoa);
            }

            var loaiVe = await db.LoaiVe.FirstOrDefaultAsync(x => x.MaLoaiVe == maLoaiVe);
            if (loaiVe != null)
            {
                db.LoaiVe.Remove(loaiVe);
            }

            await db.SaveChangesAsync();
            await giaoDich.CommitAsync();
        }
    }
}
