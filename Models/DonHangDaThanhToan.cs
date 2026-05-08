namespace doanbanve.Models
{
    public class DonHangDaThanhToan
    {
        public int MaHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal TienGiam { get; set; }
        public decimal ThanhTien { get; set; }
        public string ThanhToan { get; set; } = string.Empty;
    }
}
