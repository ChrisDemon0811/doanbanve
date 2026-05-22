using doanbanve.Data;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class VoucherDAO
    {
        public async Task<(bool HopLe, int? MaVoucher, decimal TienGiam, string ThongBao)> KiemTraVoucher(string maGiamGia, decimal tongTien)
        {
            using var db = DuLieuContext.TaoMoi();
            var voucher = await db.Voucher
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaGiamGia == maGiamGia);

            if (voucher == null)
            {
                return (false, null, 0, "Mã voucher không tồn tại.");
            }

            if (!voucher.TrangThai || voucher.SoLuong <= 0)
            {
                return (false, null, 0, "Voucher đã hết hiệu lực.");
            }

            var homNay = DateTime.Today;
            if (homNay < voucher.NgayBatDau.Date || homNay > voucher.NgayKetThuc.Date)
            {
                return (false, null, 0, "Voucher đã hết hạn.");
            }

            decimal tienGiam = voucher.KieuGiamGia == "PhanTram"
                ? tongTien * (voucher.GiaTriGiam / 100m)
                : voucher.GiaTriGiam;

            if (tienGiam > tongTien)
            {
                tienGiam = tongTien;
            }

            return (true, voucher.MaVoucher, tienGiam, "Áp dụng voucher thành công.");
        }

        public async Task<List<(int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong, bool TrangThai)>> LayDanhSachVoucher()
        {
            using var db = DuLieuContext.TaoMoi();
            var danhSach = await db.Voucher
                .AsNoTracking()
                .OrderByDescending(x => x.MaVoucher)
                .Select(x => new
                {
                    x.MaVoucher,
                    x.MaGiamGia,
                    x.TenVoucher,
                    x.KieuGiamGia,
                    x.GiaTriGiam,
                    x.NgayBatDau,
                    x.NgayKetThuc,
                    x.SoLuong,
                    x.TrangThai
                })
                .ToListAsync();

            return danhSach
                .Select(x => (
                    x.MaVoucher,
                    x.MaGiamGia,
                    x.TenVoucher,
                    x.KieuGiamGia,
                    x.GiaTriGiam,
                    x.NgayBatDau,
                    x.NgayKetThuc,
                    x.SoLuong,
                    x.TrangThai))
                .ToList();
        }

        public async Task<int> ThemVoucher(string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            using var db = DuLieuContext.TaoMoi();
            var voucher = new VoucherDuLieu
            {
                MaGiamGia = maGiamGia,
                TenVoucher = tenVoucher,
                KieuGiamGia = kieuGiamGia,
                GiaTriGiam = giaTriGiam,
                NgayBatDau = ngayBatDau.Date,
                NgayKetThuc = ngayKetThuc.Date,
                SoLuong = soLuong,
                TrangThai = true
            };

            db.Voucher.Add(voucher);
            await db.SaveChangesAsync();
            return voucher.MaVoucher;
        }

        public async Task SuaVoucher(int maVoucher, string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            using var db = DuLieuContext.TaoMoi();
            var voucher = await db.Voucher.FirstOrDefaultAsync(x => x.MaVoucher == maVoucher);
            if (voucher == null)
            {
                return;
            }

            voucher.MaGiamGia = maGiamGia;
            voucher.TenVoucher = tenVoucher;
            voucher.KieuGiamGia = kieuGiamGia;
            voucher.GiaTriGiam = giaTriGiam;
            voucher.NgayBatDau = ngayBatDau.Date;
            voucher.NgayKetThuc = ngayKetThuc.Date;
            voucher.SoLuong = soLuong;
            await db.SaveChangesAsync();
        }

        public async Task XoaVoucher(int maVoucher)
        {
            using var db = DuLieuContext.TaoMoi();
            var voucher = await db.Voucher.FirstOrDefaultAsync(x => x.MaVoucher == maVoucher);
            if (voucher == null)
            {
                return;
            }

            db.Voucher.Remove(voucher);
            await db.SaveChangesAsync();
        }

        public async Task TruSoLuong(int maVoucher)
        {
            using var db = DuLieuContext.TaoMoi();
            var voucher = await db.Voucher.FirstOrDefaultAsync(x => x.MaVoucher == maVoucher);
            if (voucher == null)
            {
                return;
            }

            if (voucher.SoLuong > 0)
            {
                voucher.SoLuong -= 1;
                await db.SaveChangesAsync();
            }
        }
    }
}
