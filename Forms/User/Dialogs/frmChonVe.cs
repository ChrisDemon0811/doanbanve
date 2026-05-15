using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmChonVe : Form
    {
        private readonly Ve ve;
        private readonly int? maChiTietGioHang;

        public frmChonVe(Ve ve, int? maChiTietGioHang = null)
        {
            InitializeComponent();
            this.ve = ve;
            this.maChiTietGioHang = maChiTietGioHang;
        }

        private void frmChonVe_Load(object sender, EventArgs e)
        {
            lblTenVe.Text = ve.TenVe;
            dtpNgaySuDung.MinDate = DateTime.Today;
            dtpNgaySuDung.Value = DateTime.Today;
            dtpNgaySuDung.Format = DateTimePickerFormat.Custom;
            dtpNgaySuDung.CustomFormat = "dddd, dd/MM/yyyy";
            lblGiaNguoiLon.Text = ve.GiaNguoiLon.ToString("N0") + " VNĐ";
            lblGiaTreEm.Text = ve.GiaTreEm.ToString("N0") + " VNĐ";
            lblGiaNguoiCaoTuoi.Text = ve.GiaNguoiCaoTuoi.ToString("N0") + " VNĐ";

            if (maChiTietGioHang.HasValue && mucBanDau != null)
            {
                dtpNgaySuDung.Value = mucBanDau.NgaySuDung.Date;
                nudNguoiLon.Value = mucBanDau.SoLuongNguoiLon;
                nudTreEm.Value = mucBanDau.SoLuongTreEm;
                nudNguoiCaoTuoi.Value = mucBanDau.SoLuongNguoiCaoTuoi;
            }

            CapNhatTongTien();
        }

        private void btnCongNguoiLon_Click(object sender, EventArgs e)
        {
            nudNguoiLon.Value += 1;
            CapNhatTongTien();
        }

        private void btnTruNguoiLon_Click(object sender, EventArgs e)
        {
            if (nudNguoiLon.Value > 0)
            {
                nudNguoiLon.Value -= 1;
                CapNhatTongTien();
            }
        }

        private void btnCongTreEm_Click(object sender, EventArgs e)
        {
            nudTreEm.Value += 1;
            CapNhatTongTien();
        }

        private void btnTruTreEm_Click(object sender, EventArgs e)
        {
            if (nudTreEm.Value > 0)
            {
                nudTreEm.Value -= 1;
                CapNhatTongTien();
            }
        }

        private void btnCongNguoiCaoTuoi_Click(object sender, EventArgs e)
        {
            nudNguoiCaoTuoi.Value += 1;
            CapNhatTongTien();
        }

        private void btnTruNguoiCaoTuoi_Click(object sender, EventArgs e)
        {
            if (nudNguoiCaoTuoi.Value > 0)
            {
                nudNguoiCaoTuoi.Value -= 1;
                CapNhatTongTien();
            }
        }

        private void nudNguoiLon_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void nudTreEm_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void nudNguoiCaoTuoi_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            var tongTien = (decimal)nudNguoiLon.Value * ve.GiaNguoiLon
                + (decimal)nudTreEm.Value * ve.GiaTreEm
                + (decimal)nudNguoiCaoTuoi.Value * ve.GiaNguoiCaoTuoi;

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để thêm giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TongSoLuong() == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LuuGioHangAsync("Đã thêm vé vào giỏ hàng.");
        }

        private void btnDatNgay_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để đặt vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TongSoLuong() == 0)
            {
                MessageBox.Show("Vui lòng chọn số lượng vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LuuGioHangAsync("Đã thêm vé và chuyển sang bước thanh toán.", true);
        }

        private async void LuuGioHangAsync(string thongBao, bool moThanhToan = false)
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            try
            {
                var muc = TaoMucGioHang();
                var gioHangController = new Controllers.GioHangController();

                if (maChiTietGioHang.HasValue)
                {
                    muc.MaChiTietGioHang = maChiTietGioHang.Value;
                    await gioHangController.CapNhatMuc(Session.NguoiDungHienTai.MaNguoiDung, muc);
                }
                else
                {
                    await gioHangController.ThemHoacGopMuc(Session.NguoiDungHienTai.MaNguoiDung, muc);
                }

                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (moThanhToan)
                {
                    var formThanhToan = new frmThanhToan();
                    formThanhToan.ShowDialog();
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Models.MucGioHang? mucBanDau { get; set; }

        private int TongSoLuong()
        {
            return (int)(nudNguoiLon.Value + nudTreEm.Value + nudNguoiCaoTuoi.Value);
        }

        private MucGioHang TaoMucGioHang()
        {
            return new MucGioHang
            {
                Ve = ve,
                NgaySuDung = dtpNgaySuDung.Value.Date,
                SoLuongNguoiLon = (int)nudNguoiLon.Value,
                SoLuongTreEm = (int)nudTreEm.Value,
                SoLuongNguoiCaoTuoi = (int)nudNguoiCaoTuoi.Value
            };
        }
    }
}
