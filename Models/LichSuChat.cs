namespace doanbanve.Models
{
    public class LichSuChat
    {
        public int MaLichSuChat { get; set; }
        public int MaNguoiDung { get; set; }
        public string CauHoi { get; set; } = string.Empty;
        public string TraLoi { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; }
    }
}
