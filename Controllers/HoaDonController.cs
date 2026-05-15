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

        public async Task<List<ThongTinHoaDon>> LayDanhSachHoaDonQuanLy()
        {
            return await hoaDonDAO.LayDanhSachHoaDonQuanLy();
        }

        public async Task<List<MucGioHang>> LayChiTietHoaDon(int maHoaDon)
        {
            return await hoaDonDAO.LayChiTietHoaDon(maHoaDon);
        }

        public async Task<ThongTinHoaDon?> LayThongTinHoaDon(int maHoaDon)
        {
            return await hoaDonDAO.LayThongTinHoaDon(maHoaDon);
        }

        public async Task<ThongKeDuLieu> LayThongKeDuLieu(DateTime? tuNgay, DateTime? denNgay)
        {
            return await hoaDonDAO.LayThongKeDuLieu(tuNgay, denNgay);
        }

        public async Task<int> LayTongVeDaBan(DateTime? tuNgay, DateTime? denNgay)
        {
            return await hoaDonDAO.LayTongVeDaBan(tuNgay, denNgay);
        }

        public async Task<List<ThongKeTheoLoaiVe>> LayThongKeTheoLoaiVe(DateTime? tuNgay, DateTime? denNgay)
        {
            return await hoaDonDAO.LayThongKeTheoLoaiVe(tuNgay, denNgay);
        }

        public async Task<List<ThongKeDoanhThuNgay>> LayThongKeDoanhThuTheoNgay(DateTime? tuNgay, DateTime? denNgay)
        {
            return await hoaDonDAO.LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);
        }
    }
}
