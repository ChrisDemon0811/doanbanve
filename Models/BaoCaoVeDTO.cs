namespace doanbanve.Models
{
    public class BaoCaoVeDTO
    {
        public int MaVe { get; set; }
        public string TenVe { get; set; } = string.Empty;
        public int MaLoaiVe { get; set; }
        public string TenLoaiVe { get; set; } = string.Empty;
        public decimal GiaVe { get; set; }
        public decimal GiaNguoiLon { get; set; }
        public decimal GiaTreEm { get; set; }
        public decimal GiaNguoiCaoTuoi { get; set; }
        public int SoLuongConLai { get; set; }
        public bool TrangThai { get; set; }

        public decimal GiaTriUocTinh => SoLuongConLai * (GiaVe > 0 ? GiaVe : GiaNguoiLon);
        public string TrangThaiHienThi => TrangThai ? "Đang bán" : "Ngừng bán";
    }
}
