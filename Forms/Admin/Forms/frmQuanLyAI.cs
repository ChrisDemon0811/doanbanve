using doanbanve.Controllers;
using doanbanve.Models;

namespace doanbanve.Forms.Admin.Forms
{
    public partial class frmQuanLyAI : Form
    {
        private readonly CauHinhAIController cauHinhController = new();

        public frmQuanLyAI()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            doanbanve.Utils.GiaoDienHelper.ApDungNutChinh(btnLuu);
        }

        private async void frmQuanLyAI_Load(object sender, EventArgs e)
        {
            try
            {
                var cauHinh = await cauHinhController.LayCauHinhHienTai();
                if (cauHinh == null)
                {
                    return;
                }

                txtNhaCungCap.Text = cauHinh.NhaCungCap;
                txtKhoaApi.Text = cauHinh.KhoaApi;
                txtMoHinh.Text = cauHinh.MoHinh;
                rtbNhacLenh.Text = cauHinh.NhacLenh;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            var nhaCungCap = txtNhaCungCap.Text.Trim();
            var khoaApi = txtKhoaApi.Text.Trim();
            var moHinh = txtMoHinh.Text.Trim();
            var nhacLenh = rtbNhacLenh.Text.Trim();

            if (string.IsNullOrWhiteSpace(nhaCungCap) || string.IsNullOrWhiteSpace(khoaApi) || string.IsNullOrWhiteSpace(moHinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cấu hình AI.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cauHinh = new CauHinhAI
                {
                    NhaCungCap = nhaCungCap,
                    KhoaApi = khoaApi,
                    MoHinh = moHinh,
                    NhacLenh = nhacLenh
                };

                await cauHinhController.LuuCauHinh(cauHinh);
                MessageBox.Show("Đã lưu cấu hình AI.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
