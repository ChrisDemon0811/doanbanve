using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmCapNhatThongTinNguoiDung : Form
    {
        private readonly NguoiDungController nguoiDungController = new();

        public frmCapNhatThongTinNguoiDung()
        {
            InitializeComponent();
        }

        private void frmCapNhatThongTinNguoiDung_Load(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            txtHoTen.Text = Session.NguoiDungHienTai.HoTen;
            txtEmail.Text = Session.NguoiDungHienTai.Email ?? string.Empty;
            txtSoDienThoai.Text = Session.NguoiDungHienTai.SoDienThoai ?? string.Empty;
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            var hoTen = txtHoTen.Text.Trim();
            var email = txtEmail.Text.Trim();
            var soDienThoai = txtSoDienThoai.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await nguoiDungController.CapNhatThongTin(Session.NguoiDungHienTai.MaNguoiDung, hoTen, string.IsNullOrWhiteSpace(email) ? null : email, string.IsNullOrWhiteSpace(soDienThoai) ? null : soDienThoai);
                Session.NguoiDungHienTai.HoTen = hoTen;
                Session.NguoiDungHienTai.Email = string.IsNullOrWhiteSpace(email) ? null : email;
                Session.NguoiDungHienTai.SoDienThoai = string.IsNullOrWhiteSpace(soDienThoai) ? null : soDienThoai;
                MessageBox.Show("Đã cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
