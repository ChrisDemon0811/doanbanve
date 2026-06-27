using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmDashboardNguoiDung : Form
    {
        private readonly LoaiVeController loaiVeController = new();
        private readonly VeController veController = new();
        private int? maLoaiVeDangLoc;
        private string tuKhoaTimKiemVe = string.Empty;

        public frmDashboardNguoiDung()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            Text = "Dashboard bán vé";
            btnThongTinNguoiDung.Text = "Thông tin tài khoản";
            GiaoDienHelper.ApDungNutChinh(btnDangNhap);
            GiaoDienHelper.ApDungNutPhu(btnDangKy);
            GiaoDienHelper.ApDungNutPhu(btnDangXuat);
            GiaoDienHelper.ApDungNutPhu(btnGioHang);
            GiaoDienHelper.ApDungNutPhu(btnThongTinNguoiDung);
            GiaoDienHelper.ApDungNutPhu(btnDoiMatKhau);
            GiaoDienHelper.ApDungNutPhu(btnChamSocKhachHang);
            GiaoDienHelper.ApDungNutPhu(btnXoaTimKiemVe);
        }

        private async void frmDashboardNguoiDung_Load(object sender, EventArgs e)
        {
            HienThiThongTinDangNhap();
            await TaiDuLieuLoaiVe();
            maLoaiVeDangLoc = null;
            await TaiDanhSachVeHienTai();
        }

        private void HienThiThongTinDangNhap()
        {
            var daDangNhap = Session.NguoiDungHienTai != null;
            btnDangNhap.Visible = !daDangNhap;
            btnDangKy.Visible = !daDangNhap;
            btnDangXuat.Visible = daDangNhap;
            btnDoiMatKhau.Visible = daDangNhap;
            btnThongTinNguoiDung.Visible = daDangNhap;
            btnChamSocKhachHang.Visible = daDangNhap;

            if (daDangNhap)
            {
                lblXinChao.Text = $"Xin chào, {Session.NguoiDungHienTai!.HoTen}!";
                lblThongTin.Text = $"Vai trò: {GiaoDienHelper.DinhDangVaiTro(Session.NguoiDungHienTai!.VaiTro)}";
            }
            else
            {
                lblXinChao.Text = "Xin chào!";
                lblThongTin.Text = string.Empty;
            }

            ChuyenDashboardQuanLy();
        }

        private void ChuyenDashboardQuanLy()
        {
            if (Session.NguoiDungHienTai?.VaiTro != "QuanLy")
            {
                return;
            }

            var formQuanLy = new frmDashboardQuanLy();
            Hide();
            formQuanLy.FormClosed += (_, _) =>
            {
                if (formQuanLy.Tag?.ToString() == "DangXuat")
                {
                    Show();
                    HienThiThongTinDangNhap();
                }
                else
                {
                    Application.Exit();
                }
            };
            formQuanLy.Show();
        }

        private async Task TaiDuLieuLoaiVe()
        {
            pnlLoaiVe.Controls.Clear();
            var nutTatCa = TaoNutLoaiVe("Tất cả vé", null);
            pnlLoaiVe.Controls.Add(nutTatCa);

            try
            {
                var danhSachLoaiVe = await loaiVeController.LayDanhSachLoaiVe();
                foreach (var loaiVe in danhSachLoaiVe)
                {
                    pnlLoaiVe.Controls.Add(TaoNutLoaiVe(loaiVe.TenLoaiVe, loaiVe));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Button TaoNutLoaiVe(string tenLoai, LoaiVe? loaiVe)
        {
            var nutLoai = new Button
            {
                Text = tenLoai,
                AutoSize = true,
                Height = 36,
                Padding = new Padding(16, 6, 16, 6),
                Margin = new Padding(8, 8, 8, 8),
                Tag = loaiVe?.MaLoaiVe
            };
            GiaoDienHelper.ApDungNutPhu(nutLoai);
            nutLoai.Click += async (_, _) =>
            {
                maLoaiVeDangLoc = loaiVe?.MaLoaiVe;
                await TaiDanhSachVeHienTai();
            };
            return nutLoai;
        }

        private async Task TaiDanhSachVeHienTai()
        {
            pnlVe.Controls.Clear();
            try
            {
                var danhSachVe = await veController.LayDanhSachVe(maLoaiVeDangLoc);
                var tuKhoa = tuKhoaTimKiemVe.Trim();
                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    danhSachVe = danhSachVe
                        .Where(ve => KhopTuKhoaTimKiem(ve, tuKhoa))
                        .ToList();
                }

                if (danhSachVe.Count == 0)
                {
                    pnlVe.Controls.Add(TaoNhanKhongCoKetQua());
                    return;
                }

                foreach (var ve in danhSachVe)
                {
                    pnlVe.Controls.Add(TaoTheVe(ve));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel TaoTheVe(Ve ve)
        {
            var doRongThe = Math.Max(980, pnlVe.ClientSize.Width - pnlVe.Padding.Horizontal - 32);
            var doRongNoiDung = Math.Max(520, doRongThe - 330);
            var fontTenVe = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            var fontMoTa = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            var tenVe = GiaoDienHelper.ChuanHoaNoiDungHienThi(ve.TenVe);
            var moTa = GiaoDienHelper.ChuanHoaNoiDungHienThi(ve.MoTa, "Đang cập nhật mô tả.");
            var chieuCaoTen = GiaoDienHelper.TinhChieuCaoVanBan(tenVe, fontTenVe, doRongNoiDung, 34);
            var chieuCaoMoTa = GiaoDienHelper.TinhChieuCaoVanBan(moTa, fontMoTa, doRongNoiDung, 42);
            var yMoTa = 16 + chieuCaoTen + 10;
            var ySoLuong = yMoTa + chieuCaoMoTa + 14;
            var yNut = ySoLuong + 34;
            var chieuCaoThe = yNut + 48;

            var theVe = new Panel
            {
                Width = doRongThe,
                Height = chieuCaoThe,
                BackColor = Color.White,
                Margin = new Padding(8, 8, 8, 8),
                BorderStyle = BorderStyle.FixedSingle
            };
            GiaoDienHelper.ApDungThe(theVe);

            var lblTenVe = new Label
            {
                Text = tenVe,
                Font = fontTenVe,
                Location = new Point(16, 16),
                AutoSize = false,
                Size = new Size(doRongNoiDung, chieuCaoTen),
                UseMnemonic = false
            };

            var lblMoTa = new Label
            {
                Text = moTa,
                Font = fontMoTa,
                Location = new Point(16, yMoTa),
                AutoSize = false,
                Size = new Size(doRongNoiDung, chieuCaoMoTa),
                UseMnemonic = false
            };

            var lblGia = new Label
            {
                Text = $"Chỉ từ {ve.GiaVe.ToString("N0")} VNĐ",
                ForeColor = GiaoDienHelper.MauNhan,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(doRongThe - 250, Math.Max(24, yMoTa + 2)),
                AutoSize = false,
                Size = new Size(214, 28),
                TextAlign = ContentAlignment.MiddleRight
            };

            var lblSoLuongCon = new Label
            {
                Text = $"Số lượng/ngày: {ve.SoLuong} vé",
                Location = new Point(16, ySoLuong),
                AutoSize = true
            };

            var btnChon = new Button
            {
                Text = "Chọn",
                Location = new Point(doRongThe - 150, yNut),
                Size = new Size(100, 30),
            };
            GiaoDienHelper.ApDungNutChinh(btnChon);
            btnChon.Click += (_, _) => MoFormChonVe(ve);

            var btnThongTinVe = new Button
            {
                Text = "Thông tin vé",
                Location = new Point(16, yNut),
                Size = new Size(120, 30)
            };
            GiaoDienHelper.ApDungNutPhu(btnThongTinVe);
            btnThongTinVe.Click += (_, _) => MoThongTinVe(ve);

            theVe.Controls.Add(lblTenVe);
            theVe.Controls.Add(lblMoTa);
            theVe.Controls.Add(lblGia);
            theVe.Controls.Add(lblSoLuongCon);
            theVe.Controls.Add(btnThongTinVe);
            theVe.Controls.Add(btnChon);
            return theVe;
        }
        private Label TaoNhanKhongCoKetQua()
        {
            return new Label
            {
                Text = "Không tìm thấy vé phù hợp.",
                AutoSize = true,
                Location = new Point(16, 16),
                Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(90, 90, 90)
            };
        }

        private static bool KhopTuKhoaTimKiem(Ve ve, string tuKhoa)
        {
            return CoChua(ve.TenVe, tuKhoa)
                || CoChua(ve.MoTa, tuKhoa)
                || CoChua(ve.ThongTinVe, tuKhoa);
        }

        private static bool CoChua(string? noiDung, string tuKhoa)
        {
            return !string.IsNullOrWhiteSpace(noiDung)
                && noiDung.Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase);
        }

        private void MoFormChonVe(Ve ve)
        {
            var formChonVe = new frmChonVe(ve);
            formChonVe.ShowDialog();
        }

        private void MoThongTinVe(Ve ve)
        {
            var formThongTin = new frmThongTinVe(ve);
            formThongTin.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session.DangXuat();
            HienThiThongTinDangNhap();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var formDangNhap = new frmDangNhap();
            formDangNhap.ShowDialog();
            HienThiThongTinDangNhap();
            _ = TaiDuLieuLoaiVe();
            _ = TaiDanhSachVeHienTai();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var formDangKy = new frmDangKy();
            formDangKy.ShowDialog();
            HienThiThongTinDangNhap();
        }

        private void btnGioHang_Click(object sender, EventArgs e)
        {
            var formGioHang = new frmGioHang();
            formGioHang.ShowDialog();
            _ = TaiDanhSachVeHienTai();
        }

        private void btnThongTinNguoiDung_Click(object sender, EventArgs e)
        {
            var formThongTin = new frmThongTinNguoiDung();
            formThongTin.ShowDialog();
            HienThiThongTinDangNhap();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            var formDoiMatKhau = new frmDoiMatKhau();
            formDoiMatKhau.ShowDialog();
            HienThiThongTinDangNhap();
        }

        private void btnChamSocKhachHang_Click(object sender, EventArgs e)
        {
            var formChat = new frmChatAI();
            formChat.ShowDialog();
        }

        private void txtTimKiemVe_TextChanged(object sender, EventArgs e)
        {
            tuKhoaTimKiemVe = txtTimKiemVe.Text;
            _ = TaiDanhSachVeHienTai();
        }

        private void btnXoaTimKiemVe_Click(object sender, EventArgs e)
        {
            txtTimKiemVe.Clear();
            txtTimKiemVe.Focus();
        }
    }
}

