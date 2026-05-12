using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmDangNhap : Form
    {
        private readonly NguoiDungController nguoiDungController = new();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            var taiKhoan = txtTaiKhoan.Text.Trim();
            var matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var nguoiDung = await nguoiDungController.DangNhap(taiKhoan, matKhau);
                if (nguoiDung == null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Session.DangNhap(nguoiDung);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var formDangKy = new frmDangKy();
            formDangKy.ShowDialog();
        }
    }
}
