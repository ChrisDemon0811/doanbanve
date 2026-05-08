using doanbanve.Controllers;
using doanbanve.Models;

namespace doanbanve.Forms
{
    public partial class frmChiTietHoaDonQuanLy : Form
    {
        private readonly HoaDonController hoaDonController = new();
        private readonly int maHoaDon;
        private ThongTinHoaDon? thongTinHoaDon;

        public frmChiTietHoaDonQuanLy(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
        }

        private async void frmChiTietHoaDonQuanLy_Load(object sender, EventArgs e)
        {
            await TaiChiTiet();
        }

        private async Task TaiChiTiet()
        {
            pnlDanhSach.Controls.Clear();
            thongTinHoaDon = await hoaDonController.LayThongTinHoaDon(maHoaDon);
            HienThiThongTinHoaDon();
            var danhSach = await hoaDonController.LayChiTietHoaDon(maHoaDon);
            foreach (var muc in danhSach)
            {
                pnlDanhSach.Controls.Add(TaoTheChiTiet(muc));
            }
        }

        private void HienThiThongTinHoaDon()
        {
            if (thongTinHoaDon == null)
            {
                return;
            }

            lblMaHoaDon.Text = $"Mã hóa đơn: {thongTinHoaDon.MaHoaDon}";
            lblNguoiDat.Text = $"Người đặt: {thongTinHoaDon.HoTenNguoiDat}";
            lblNgayDat.Text = $"Ngày đặt: {thongTinHoaDon.NgayLap:dd/MM/yyyy HH:mm}";
            lblThanhToan.Text = $"Hình thức thanh toán: {thongTinHoaDon.ThanhToan}";
            lblGiamGia.Text = $"Giảm giá: {thongTinHoaDon.TienGiam.ToString("N0")} VNĐ";
            lblTrangThai.Text = $"Trạng thái: {thongTinHoaDon.TrangThai}";
        }

        private Panel TaoTheChiTiet(MucGioHang muc)
        {
            var theMuc = new Panel
            {
                Width = 620,
                Height = 140,
                BackColor = Color.White,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTenVe = new Label
            {
                Text = muc.Ve.TenVe,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(16, 12),
                AutoSize = true
            };

            var lblNgaySuDung = new Label
            {
                Text = "Ngày sử dụng: " + muc.NgaySuDung.ToString("dd/MM/yyyy"),
                Location = new Point(16, 40),
                AutoSize = true
            };

            var lblNguoiLon = new Label
            {
                Text = $"Người lớn: {muc.SoLuongNguoiLon} x {muc.Ve.GiaNguoiLon.ToString("N0")} VNĐ",
                Location = new Point(16, 64),
                AutoSize = true
            };

            var lblTreEm = new Label
            {
                Text = $"Trẻ em: {muc.SoLuongTreEm} x {muc.Ve.GiaTreEm.ToString("N0")} VNĐ",
                Location = new Point(16, 84),
                AutoSize = true
            };

            var lblNguoiCaoTuoi = new Label
            {
                Text = $"Người cao tuổi: {muc.SoLuongNguoiCaoTuoi} x {muc.Ve.GiaNguoiCaoTuoi.ToString("N0")} VNĐ",
                Location = new Point(280, 84),
                AutoSize = true
            };

            var lblThanhTien = new Label
            {
                Text = muc.TinhTongTien().ToString("N0") + " VNĐ",
                ForeColor = Color.FromArgb(210, 85, 30),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(480, 40),
                AutoSize = true
            };

            theMuc.Controls.Add(lblTenVe);
            theMuc.Controls.Add(lblNgaySuDung);
            theMuc.Controls.Add(lblNguoiLon);
            theMuc.Controls.Add(lblTreEm);
            theMuc.Controls.Add(lblNguoiCaoTuoi);
            theMuc.Controls.Add(lblThanhTien);
            return theMuc;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
