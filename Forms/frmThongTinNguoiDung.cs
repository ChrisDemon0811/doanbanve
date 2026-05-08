using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmThongTinNguoiDung : Form
    {
        private readonly HoaDonController hoaDonController = new();

        public frmThongTinNguoiDung()
        {
            InitializeComponent();
        }

        private async void frmThongTinNguoiDung_Load(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            lblHoTen.Text = Session.NguoiDungHienTai.HoTen;
            lblTaiKhoan.Text = Session.NguoiDungHienTai.TaiKhoan;
            lblEmail.Text = Session.NguoiDungHienTai.Email ?? "Chưa cập nhật";
            lblSoDienThoai.Text = Session.NguoiDungHienTai.SoDienThoai ?? "Chưa cập nhật";
            lblVaiTro.Text = Session.NguoiDungHienTai.VaiTro;

            await TaiDanhSachHoaDon();
        }

        private async Task TaiDanhSachHoaDon()
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            pnlDonHangDanhSach.Controls.Clear();
            var danhSach = await hoaDonController.LayDanhSachDaThanhToan(Session.NguoiDungHienTai.MaNguoiDung);
            foreach (var hoaDon in danhSach)
            {
                pnlDonHangDanhSach.Controls.Add(TaoTheHoaDon(hoaDon));
            }
        }

        private Panel TaoTheHoaDon(Models.DonHangDaThanhToan hoaDon)
        {
            var theHoaDon = new Panel
            {
                Width = 640,
                Height = 120,
                BackColor = Color.White,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblMaHoaDon = new Label
            {
                Text = $"Hóa đơn #{hoaDon.MaHoaDon}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(16, 12),
                AutoSize = true
            };

            var lblNgayLap = new Label
            {
                Text = "Ngày lập: " + hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                Location = new Point(16, 40),
                AutoSize = true
            };

            var lblTongTien = new Label
            {
                Text = "Tổng tiền: " + hoaDon.TongTien.ToString("N0") + " VNĐ",
                Location = new Point(16, 64),
                AutoSize = true
            };

            var lblThanhToan = new Label
            {
                Text = "Thanh toán: " + hoaDon.ThanhToan,
                Location = new Point(16, 88),
                AutoSize = true
            };

            var lblThanhTien = new Label
            {
                Text = hoaDon.ThanhTien.ToString("N0") + " VNĐ",
                ForeColor = Color.FromArgb(210, 85, 30),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(480, 40),
                AutoSize = true
            };

            var btnChiTiet = new Button
            {
                Text = "Chi tiết thanh toán",
                Location = new Point(420, 76),
                Size = new Size(130, 28)
            };
            btnChiTiet.Click += (_, _) => MoChiTietHoaDon(hoaDon.MaHoaDon);

            var btnThongTinVe = new Button
            {
                Text = "Thông tin vé",
                Location = new Point(556, 76),
                Size = new Size(90, 28)
            };
            btnThongTinVe.Click += (_, _) => MoThongTinVeTuHoaDon(hoaDon.MaHoaDon);

            theHoaDon.Controls.Add(lblMaHoaDon);
            theHoaDon.Controls.Add(lblNgayLap);
            theHoaDon.Controls.Add(lblTongTien);
            theHoaDon.Controls.Add(lblThanhToan);
            theHoaDon.Controls.Add(lblThanhTien);
            theHoaDon.Controls.Add(btnChiTiet);
            theHoaDon.Controls.Add(btnThongTinVe);
            return theHoaDon;
        }

        private void MoChiTietHoaDon(int maHoaDon)
        {
            var formChiTiet = new frmChiTietThanhToan(maHoaDon);
            formChiTiet.ShowDialog();
        }

        private async void MoThongTinVeTuHoaDon(int maHoaDon)
        {
            var danhSach = await hoaDonController.LayChiTietHoaDon(maHoaDon);
            var muc = danhSach.FirstOrDefault();
            if (muc == null)
            {
                return;
            }

            var formThongTin = new frmThongTinVe(muc.Ve.TenVe, muc.Ve.ThongTinVe);
            formThongTin.ShowDialog();
        }
    }
}
