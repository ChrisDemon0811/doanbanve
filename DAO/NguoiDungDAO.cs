using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class NguoiDungDAO
    {
        public async Task<NguoiDung?> LayTheoTaiKhoanMatKhau(string taiKhoan, string matKhau)
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.NguoiDung
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.TaiKhoan == taiKhoan &&
                    x.MatKhau == matKhau &&
                    x.TrangThai);
        }

        public async Task<bool> KiemTraTaiKhoanTonTai(string taiKhoan)
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.NguoiDung.AnyAsync(x => x.TaiKhoan == taiKhoan);
        }

        public async Task<int> ThemNguoiDung(NguoiDung nguoiDung)
        {
            using var db = DuLieuContext.TaoMoi();
            nguoiDung.NgayDangKy = DateTime.Now;
            nguoiDung.TrangThai = true;
            db.NguoiDung.Add(nguoiDung);
            await db.SaveChangesAsync();
            return nguoiDung.MaNguoiDung;
        }

        public async Task<List<NguoiDung>> LayDanhSachNguoiDung()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.NguoiDung
                .AsNoTracking()
                .OrderBy(x => x.HoTen)
                .ToListAsync();
        }

        public async Task DatMatKhau(int maNguoiDung, string matKhauMoi)
        {
            using var db = DuLieuContext.TaoMoi();
            var nguoiDung = await db.NguoiDung.FirstOrDefaultAsync(x => x.MaNguoiDung == maNguoiDung);
            if (nguoiDung == null)
            {
                return;
            }

            nguoiDung.MatKhau = matKhauMoi;
            await db.SaveChangesAsync();
        }

        public async Task CapNhatThongTin(int maNguoiDung, string hoTen, string? email, string? soDienThoai)
        {
            using var db = DuLieuContext.TaoMoi();
            var nguoiDung = await db.NguoiDung.FirstOrDefaultAsync(x => x.MaNguoiDung == maNguoiDung);
            if (nguoiDung == null)
            {
                return;
            }

            nguoiDung.HoTen = hoTen;
            nguoiDung.Email = email;
            nguoiDung.SoDienThoai = soDienThoai;
            await db.SaveChangesAsync();
        }
    }
}
