using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmGioHang : Form
    {
        public frmGioHang()
        {
            InitializeComponent();
        }

        private readonly Controllers.GioHangController gioHangController = new();

        private async void frmGioHang_Load(object sender, EventArgs e)
        {
            await HienThiDanhSach();
        }

        private async Task HienThiDanhSach()
        {
            pnlDanhSach.Controls.Clear();
            lblTongTien.Text = "0 VNĐ";
            lblTongSoLuong.Text = "0";

            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để xem giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            var danhSach = await gioHangController.LayDanhSach(Session.NguoiDungHienTai.MaNguoiDung);
            var tongTien = 0m;
            var tongSoLuong = 0;

            foreach (var muc in danhSach)
            {
                var theMuc = TaoTheGioHang(muc);
                pnlDanhSach.Controls.Add(theMuc);
                tongTien += muc.TinhTongTien();
                tongSoLuong += muc.TinhTongSoLuong();
            }

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblTongSoLuong.Text = tongSoLuong.ToString();
        }

        private Panel TaoTheGioHang(Models.MucGioHang muc)
        {
            var theMuc = new Panel
            {
                Width = 820,
                Height = 140,
                BackColor = Color.White,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle
            };

            var lblTenVe = new Label
            {
                Text = muc.Ve.TenVe,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(16, 16),
                AutoSize = true
            };

            var lblNgaySuDung = new Label
            {
                Text = "Ngày sử dụng: " + muc.NgaySuDung.ToString("dd/MM/yyyy"),
                Location = new Point(16, 44),
                AutoSize = true
            };

            var lblSoLuong = new Label
            {
                Text = $"Người lớn: {muc.SoLuongNguoiLon} | Trẻ em: {muc.SoLuongTreEm} | Người cao tuổi: {muc.SoLuongNguoiCaoTuoi}",
                Location = new Point(16, 70),
                AutoSize = true
            };

            var lblGia = new Label
            {
                Text = muc.TinhTongTien().ToString("N0") + " VNĐ",
                ForeColor = Color.FromArgb(210, 85, 30),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(680, 52),
                AutoSize = true
            };

            var btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(520, 86),
                Size = new Size(80, 28)
            };
            btnSua.Click += (_, _) => SuaMucGioHang(muc);

            var btnThongTinVe = new Button
            {
                Text = "Thông tin vé",
                Location = new Point(610, 86),
                Size = new Size(86, 28)
            };
            btnThongTinVe.Click += (_, _) => MoThongTinVe(muc.Ve);

            var btnXoa = new Button
            {
                Text = "Xóa",
                Location = new Point(700, 86),
                Size = new Size(80, 28)
            };
            btnXoa.Click += async (_, _) => await XoaMucGioHang(muc);

            theMuc.Controls.Add(lblTenVe);
            theMuc.Controls.Add(lblNgaySuDung);
            theMuc.Controls.Add(lblSoLuong);
            theMuc.Controls.Add(lblGia);
            theMuc.Controls.Add(btnSua);
            theMuc.Controls.Add(btnThongTinVe);
            theMuc.Controls.Add(btnXoa);
            return theMuc;
        }

        private async Task XoaMucGioHang(Models.MucGioHang muc)
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            await gioHangController.XoaMuc(muc.MaChiTietGioHang);
            await HienThiDanhSach();
        }

        private void SuaMucGioHang(Models.MucGioHang muc)
        {
            var formChonVe = new frmChonVe(muc.Ve, muc.MaChiTietGioHang)
            {
                mucBanDau = muc
            };
            formChonVe.ShowDialog();
            _ = HienThiDanhSach();
        }

        private void btnMuaHang_Click(object sender, EventArgs e)
        {
            var formThanhToan = new frmThanhToan();
            formThanhToan.ShowDialog();
            _ = HienThiDanhSach();
        }

        private void MoThongTinVe(Models.Ve ve)
        {
            var formThongTin = new frmThongTinVe(ve.TenVe, ve.ThongTinVe);
            formThongTin.ShowDialog();
        }
    }
}
