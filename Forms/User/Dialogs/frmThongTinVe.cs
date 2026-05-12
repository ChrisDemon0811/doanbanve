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
        }
    }
}
