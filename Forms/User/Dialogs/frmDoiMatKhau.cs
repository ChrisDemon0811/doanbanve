using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmDoiMatKhau : Form
    {
        private readonly NguoiDungController nguoiDungController = new();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private async void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            var matKhauCu = txtMatKhauCu.Text.Trim();
            var matKhauMoi = txtMatKhauMoi.Text.Trim();
            var matKhauXacNhan = txtMatKhauXacNhan.Text.Trim();

            if (string.IsNullOrWhiteSpace(matKhauCu) || string.IsNullOrWhiteSpace(matKhauMoi) || string.IsNullOrWhiteSpace(matKhauXacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var matKhauCuMaHoa = Utils.MaHoaMatKhau.MaHoaMD5(matKhauCu);
            if (Session.NguoiDungHienTai.MatKhau != matKhauCuMaHoa)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != matKhauXacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var matKhauMoiMaHoa = Utils.MaHoaMatKhau.MaHoaMD5(matKhauMoi);
                await nguoiDungController.DatMatKhau(Session.NguoiDungHienTai.MaNguoiDung, matKhauMoi);
                Session.NguoiDungHienTai.MatKhau = matKhauMoiMaHoa;
                MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
