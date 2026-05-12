namespace doanbanve.Forms
{
    public partial class frmThongTinVe : Form
    {
        public frmThongTinVe(string tieuDe, string? thongTinVe)
        {
            InitializeComponent();
            Text = "Thông tin vé";
            lblTieuDe.Text = tieuDe;
            txtThongTinVe.Text = string.IsNullOrWhiteSpace(thongTinVe) ? "Đang cập nhật thông tin vé." : thongTinVe;
            DatConTroThongTin();
        }

        public frmThongTinVe(Models.Ve ve)
        {
            InitializeComponent();
            Text = "Thông tin vé";
            lblTieuDe.Text = ve.TenVe;
            txtThongTinVe.Text = TaoNoiDungThongTin(ve);
            DatConTroThongTin();
        }

        private void DatConTroThongTin()
        {
            txtThongTinVe.SelectionStart = 0;
            txtThongTinVe.SelectionLength = 0;
            txtThongTinVe.HideSelection = true;
            txtThongTinVe.TabStop = false;
        }

        private static string TaoNoiDungThongTin(Models.Ve ve)
        {
            var thongTin = string.IsNullOrWhiteSpace(ve.ThongTinVe)
                ? "Đang cập nhật thông tin vé."
                : ve.ThongTinVe;
            var moTa = string.IsNullOrWhiteSpace(ve.MoTa) ? "Đang cập nhật." : ve.MoTa;

            return string.Join(Environment.NewLine, new[]
            {
                $"Mã vé: {ve.MaVe}",
                $"Tên vé: {ve.TenVe}",
                $"Loại vé: {ve.MaLoaiVe}",
                $"Giá vé: {ve.GiaVe.ToString("N0")} VNĐ",
                $"Giá người lớn: {ve.GiaNguoiLon.ToString("N0")} VNĐ",
                $"Giá trẻ em: {ve.GiaTreEm.ToString("N0")} VNĐ",
                $"Giá người cao tuổi: {ve.GiaNguoiCaoTuoi.ToString("N0")} VNĐ",
                $"Số lượng: {ve.SoLuong}",
                $"Mô tả: {moTa}",
                "",
                "Thông tin vé:",
                thongTin
            });
        }
    }
}
