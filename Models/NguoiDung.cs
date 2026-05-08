namespace doanbanve.Models
{
    public class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string TaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string VaiTro { get; set; } = string.Empty;
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }
    }
}
