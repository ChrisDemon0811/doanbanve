using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class HoaDonController
    {
        private readonly HoaDonDAO hoaDonDAO = new();

        public async Task<List<DonHangDaThanhToan>> LayDanhSachDaThanhToan(int maNguoiDung)
        {
            return await hoaDonDAO.LayDanhSachDaThanhToan(maNguoiDung);
        }

        public async Task<List<MucGioHang>> LayChiTietHoaDon(int maHoaDon)
        {
            return await hoaDonDAO.LayChiTietHoaDon(maHoaDon);
        }

        public async Task<ThongTinHoaDon?> LayThongTinHoaDon(int maHoaDon)
        {
            return await hoaDonDAO.LayThongTinHoaDon(maHoaDon);
        }
    }
}
