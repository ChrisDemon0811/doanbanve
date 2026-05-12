using doanbanve.Controllers;

namespace doanbanve.Forms
{
    public partial class frmDatMatKhauNguoiDung : Form
    {
        private readonly int maNguoiDung;
        private readonly string taiKhoan;
        private readonly NguoiDungController nguoiDungController = new();

        public frmDatMatKhauNguoiDung(int maNguoiDung, string taiKhoan)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
            this.taiKhoan = taiKhoan;
        }

        private void frmDatMatKhauNguoiDung_Load(object sender, EventArgs e)
        {
            lblTaiKhoan.Text = $"Tài khoản: {taiKhoan}";
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            var matKhauMoi = txtMatKhauMoi.Text.Trim();
            if (string.IsNullOrWhiteSpace(matKhauMoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await nguoiDungController.DatMatKhau(maNguoiDung, matKhauMoi);
                MessageBox.Show("Đã reset mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
