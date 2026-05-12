namespace doanbanve.Forms
{
    public partial class frmNhapVoucher : Form
    {
        public (int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong)? VoucherHienTai { get; private set; }

        public frmNhapVoucher((int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong)? voucher)
        {
            InitializeComponent();
            VoucherHienTai = voucher;
            dtpNgayBatDau.MinDate = DateTime.Today;
            dtpNgayKetThuc.MinDate = DateTime.Today.AddDays(1);
            dtpNgayBatDau.ValueChanged += dtpNgayBatDau_ValueChanged;
        }

        private void frmNhapVoucher_Load(object sender, EventArgs e)
        {
            cboKieuGiamGia.Items.AddRange(new object[] { "PhanTram", "TienMat" });
            cboKieuGiamGia.SelectedIndex = 0;

            dtpNgayBatDau.MinDate = DateTime.Today;
            dtpNgayKetThuc.MinDate = DateTime.Today.AddDays(1);

            if (VoucherHienTai != null)
            {
                txtMaGiamGia.Text = VoucherHienTai.Value.MaGiamGia;
                txtTenVoucher.Text = VoucherHienTai.Value.TenVoucher;
                cboKieuGiamGia.SelectedItem = VoucherHienTai.Value.KieuGiamGia;
                txtGiaTriGiam.Text = VoucherHienTai.Value.GiaTriGiam.ToString();
                dtpNgayBatDau.Value = VoucherHienTai.Value.NgayBatDau.Date < DateTime.Today
                    ? DateTime.Today
                    : VoucherHienTai.Value.NgayBatDau.Date;
                dtpNgayKetThuc.Value = VoucherHienTai.Value.NgayKetThuc.Date <= dtpNgayBatDau.Value.Date
                    ? dtpNgayBatDau.Value.Date.AddDays(1)
                    : VoucherHienTai.Value.NgayKetThuc.Date;
                txtSoLuong.Text = VoucherHienTai.Value.SoLuong.ToString();
            }
            else
            {
                dtpNgayBatDau.Value = DateTime.Today;
                dtpNgayKetThuc.Value = DateTime.Today.AddDays(1);
            }
        }

        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            var ngayToiThieu = dtpNgayBatDau.Value.Date.AddDays(1);
            dtpNgayKetThuc.MinDate = ngayToiThieu;
            if (dtpNgayKetThuc.Value.Date < ngayToiThieu)
            {
                dtpNgayKetThuc.Value = ngayToiThieu;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaGiamGia.Text) || string.IsNullOrWhiteSpace(txtTenVoucher.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaTriGiam.Text.Trim(), out var giaTriGiam) || giaTriGiam <= 0)
            {
                MessageBox.Show("Giá trị giảm không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out var soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var kieuGiamGia = cboKieuGiamGia.SelectedItem?.ToString() ?? "PhanTram";
            if (dtpNgayKetThuc.Value.Date <= dtpNgayBatDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VoucherHienTai = (0, txtMaGiamGia.Text.Trim(), txtTenVoucher.Text.Trim(), kieuGiamGia, giaTriGiam, dtpNgayBatDau.Value.Date, dtpNgayKetThuc.Value.Date, soLuong);
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
