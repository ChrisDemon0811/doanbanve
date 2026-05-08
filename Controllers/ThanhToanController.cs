using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class ThanhToanController
    {
        private readonly HoaDonDAO hoaDonDAO = new();
        private readonly VoucherDAO voucherDAO = new();
        private readonly GioHangDAO gioHangDAO = new();
        private readonly ChiTietGioHangDAO chiTietGioHangDAO = new();

        public async Task<(bool HopLe, int? MaVoucher, decimal TienGiam, string ThongBao)> ApDungVoucher(string maGiamGia, decimal tongTien)
        {
            return await voucherDAO.KiemTraVoucher(maGiamGia, tongTien);
        }

        public async Task<int> LuuHoaDon(int maNguoiDung, List<MucGioHang> danhSachMuc, int? maVoucher, decimal tienGiam, string thanhToan)
        {
            var tongTien = danhSachMuc.Sum(m => m.TinhTongTien());
            var maHoaDon = await hoaDonDAO.ThemHoaDon(maNguoiDung, tongTien, maVoucher, tienGiam, thanhToan);
            foreach (var muc in danhSachMuc)
            {
                await hoaDonDAO.ThemChiTietHoaDon(maHoaDon, muc);
            }

            if (maVoucher.HasValue)
            {
                await voucherDAO.TruSoLuong(maVoucher.Value);
            }

            var maGioHang = await gioHangDAO.LayHoacTaoGioHang(maNguoiDung);
            await chiTietGioHangDAO.XoaTheoGioHang(maGioHang);
            return maHoaDon;
        }
    }
}
