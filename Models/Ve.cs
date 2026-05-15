namespace doanbanve.Models
{
    public class Ve
    {
        public int MaVe { get; set; }
        public int MaLoaiVe { get; set; }
        public string TenVe { get; set; } = string.Empty;
        public decimal GiaVe { get; set; }
        public decimal GiaNguoiLon { get; set; }
        public decimal GiaTreEm { get; set; }
        public decimal GiaNguoiCaoTuoi { get; set; }
        public int SoLuong { get; set; }
        public string? MoTa { get; set; }
        public string? ThongTinVe { get; set; }
        public string? AnhVe { get; set; }
        public bool TrangThai { get; set; }
    }
}
