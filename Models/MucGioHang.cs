namespace doanbanve.Models
{
    public class MucGioHang
    {
        public int MaChiTietGioHang { get; set; }
        public int MaGioHang { get; set; }
        public Ve Ve { get; set; } = new();
        public DateTime NgaySuDung { get; set; }
        public int SoLuongNguoiLon { get; set; }
        public int SoLuongTreEm { get; set; }
        public int SoLuongNguoiCaoTuoi { get; set; }

        public decimal TinhTongTien()
        {
            return (SoLuongNguoiLon * Ve.GiaNguoiLon)
                + (SoLuongTreEm * Ve.GiaTreEm)
                + (SoLuongNguoiCaoTuoi * Ve.GiaNguoiCaoTuoi);
        }

        public int TinhTongSoLuong()
        {
            return SoLuongNguoiLon + SoLuongTreEm + SoLuongNguoiCaoTuoi;
        }
    }
}
