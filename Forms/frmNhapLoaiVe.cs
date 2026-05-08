using doanbanve.Models;

namespace doanbanve.Forms
{
    public partial class frmNhapLoaiVe : Form
    {
        public LoaiVe? LoaiVeHienTai { get; private set; }

        public frmNhapLoaiVe(LoaiVe? loaiVe)
        {
            InitializeComponent();
            LoaiVeHienTai = loaiVe;
        }

        private void frmNhapLoaiVe_Load(object sender, EventArgs e)
        {
            if (LoaiVeHienTai != null)
            {
                txtTenLoaiVe.Text = LoaiVeHienTai.TenLoaiVe;
                txtMoTa.Text = LoaiVeHienTai.MoTa ?? string.Empty;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiVe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoaiVeHienTai = new LoaiVe
            {
                TenLoaiVe = txtTenLoaiVe.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                TrangThai = true
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
