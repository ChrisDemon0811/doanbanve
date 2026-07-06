using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmGioHang : Form
    {
        public frmGioHang()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutChinh(btnMuaHang);
        }

        private readonly Controllers.GioHangController gioHangController = new();

        private async void frmGioHang_Load(object sender, EventArgs e)
        {
            await HienThiDanhSach();
        }

        private async Task HienThiDanhSach()
        {
            pnlDanhSach.Controls.Clear();
            lblTongTien.Text = "0 VN\u0110";
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

            lblTongTien.Text = tongTien.ToString("N0") + " VN\u0110";
            lblTongSoLuong.Text = tongSoLuong.ToString();
        }

        private Panel TaoTheGioHang(Models.MucGioHang muc)
        {
            var doRongThe = Math.Max(860, pnlDanhSach.ClientSize.Width - pnlDanhSach.Padding.Horizontal - 32);
            var doRongNoiDung = Math.Max(480, doRongThe - 260);
            var fontTenVe = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            var tenVe = GiaoDienHelper.ChuanHoaNoiDungHienThi(muc.Ve.TenVe);
            var chieuCaoTen = GiaoDienHelper.TinhChieuCaoVanBan(tenVe, fontTenVe, doRongNoiDung, 32);
            var yNgaySuDung = 16 + chieuCaoTen + 8;
            var ySoLuong = yNgaySuDung + 26;
            var ySoLuongCon = ySoLuong + 26;
            var yNut = ySoLuongCon + 34;
            var chieuCaoThe = yNut + 46;

            var theMuc = new Panel
            {
                Width = doRongThe,
                Height = chieuCaoThe,
                BackColor = Color.White,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle
            };
            GiaoDienHelper.ApDungThe(theMuc);

            var lblTenVe = new Label
            {
                Text = tenVe,
                Font = fontTenVe,
                Location = new Point(16, 16),
                AutoSize = false,
                Size = new Size(doRongNoiDung, chieuCaoTen),
                UseMnemonic = false
            };

            var lblNgaySuDung = new Label
            {
                Text = "Ngày sử dụng: " + muc.NgaySuDung.ToString("dd/MM/yyyy"),
                Location = new Point(16, yNgaySuDung),
                AutoSize = true
            };

            var lblSoLuong = new Label
            {
                Text = $"Người lớn: {muc.SoLuongNguoiLon} | Trẻ em: {muc.SoLuongTreEm} | Người cao tuổi: {muc.SoLuongNguoiCaoTuoi}",
                Location = new Point(16, ySoLuong),
                AutoSize = true
            };

            var lblSoLuongCon = new Label
            {
                Text = $"Còn lại ngày {muc.NgaySuDung:dd/MM/yyyy}: {muc.Ve.SoLuong} vé",
                Location = new Point(16, ySoLuongCon),
                AutoSize = true
            };

            var lblGia = new Label
            {
                Text = muc.TinhTongTien().ToString("N0") + " VNĐ",
                ForeColor = GiaoDienHelper.MauNhan,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(doRongThe - 210, yNgaySuDung),
                AutoSize = false,
                Size = new Size(170, 28),
                TextAlign = ContentAlignment.MiddleRight
            };

            var btnSua = new Button
            {
                Text = "Sửa",
                Location = new Point(doRongThe - 300, yNut),
                Size = new Size(80, 28)
            };
            GiaoDienHelper.ApDungNutPhu(btnSua);
            btnSua.Click += (_, _) => SuaMucGioHang(muc);

            var btnThongTinVe = new Button
            {
                Text = "Thông tin vé",
                Location = new Point(doRongThe - 210, yNut),
                Size = new Size(110, 28)
            };
            GiaoDienHelper.ApDungNutPhu(btnThongTinVe);
            btnThongTinVe.Click += (_, _) => MoThongTinVe(muc.Ve);

            var btnXoa = new Button
            {
                Text = "Xóa",
                Location = new Point(doRongThe - 90, yNut),
                Size = new Size(80, 28)
            };
            GiaoDienHelper.ApDungNutPhu(btnXoa);
            btnXoa.Click += async (_, _) => await XoaMucGioHang(muc);

            theMuc.Controls.Add(lblTenVe);
            theMuc.Controls.Add(lblNgaySuDung);
            theMuc.Controls.Add(lblSoLuong);
            theMuc.Controls.Add(lblSoLuongCon);
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

        private async void btnMuaHang_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để mua hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var danhSachNgayQuaKhu = await gioHangController.LayDanhSachNgayQuaKhu(Session.NguoiDungHienTai.MaNguoiDung);
            if (danhSachNgayQuaKhu.Count > 0)
            {
                var noiDungLoi = TaoThongBaoNgayQuaKhu(danhSachNgayQuaKhu);
                MessageBox.Show(noiDungLoi, "Ngày sử dụng không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formThanhToan = new frmThanhToan();
            formThanhToan.ShowDialog();
            _ = HienThiDanhSach();
        }

        private static string TaoThongBaoNgayQuaKhu(List<Models.MucGioHang> danhSachNgayQuaKhu)
        {
            var danhSachHienThi = danhSachNgayQuaKhu
                .Take(5)
                .Select(muc => $"- {GiaoDienHelper.ChuanHoaNoiDungHienThi(muc.Ve.TenVe)}: {muc.NgaySuDung:dd/MM/yyyy}");

            var thongBao = "Giỏ hàng có vé dùng ngày trong quá khứ nên chưa thể thanh toán.\n\n"
                + string.Join("\n", danhSachHienThi);

            if (danhSachNgayQuaKhu.Count > 5)
            {
                thongBao += $"\n- ... và {danhSachNgayQuaKhu.Count - 5} vé khác";
            }

            return thongBao + "\n\nVui lòng bấm Sửa để chọn lại ngày từ hôm nay trở về sau.";
        }

        private void MoThongTinVe(Models.Ve ve)
        {
            var formThongTin = new frmThongTinVe(ve);
            formThongTin.ShowDialog();
        }
    }
}

