namespace doanbanve.Data
{
    public class VoucherDuLieu
    {
        public int MaVoucher { get; set; }
        public string MaGiamGia { get; set; } = string.Empty;
        public string TenVoucher { get; set; } = string.Empty;
        public string KieuGiamGia { get; set; } = string.Empty;
        public decimal GiaTriGiam { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
    }

    public class GioHangDuLieu
    {
        public int MaGioHang { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class ChiTietGioHangDuLieu
    {
        public int MaChiTietGioHang { get; set; }
        public int MaGioHang { get; set; }
        public int MaVe { get; set; }
        public DateTime NgaySuDung { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongNguoiCaoTuoi { get; set; }
        public decimal? DonGiaNguoiLon { get; set; }
        public decimal? DonGiaTreEm { get; set; }
        public decimal? DonGiaNguoiCaoTuoi { get; set; }
    }

    public class HoaDonDuLieu
    {
        public int MaHoaDon { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public int? MaVoucher { get; set; }
        public decimal TienGiam { get; set; }
        public string ThanhToan { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
    }

    public class ChiTietHoaDonDuLieu
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaVe { get; set; }
        public DateTime NgaySuDung { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongNguoiCaoTuoi { get; set; }
        public decimal DonGiaNguoiLon { get; set; }
        public decimal DonGiaTreEm { get; set; }
        public decimal DonGiaNguoiCaoTuoi { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
