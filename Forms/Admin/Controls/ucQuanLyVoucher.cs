using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class ucQuanLyVoucher : UserControl
    {
        private readonly VoucherController voucherController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theVoucherDangChon;
        private List<VoucherHienThi> danhSachVoucherHienThi = new();

        private sealed record VoucherHienThi(
            int MaVoucher,
            string MaGiamGia,
            string TenVoucher,
            string KieuGiamGia,
            decimal GiaTriGiam,
            DateTime NgayBatDau,
            DateTime NgayKetThuc,
            int SoLuong,
            bool TrangThai);

        public ucQuanLyVoucher()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutChinh(btnThemVoucher);
            GiaoDienHelper.ApDungNutPhu(btnSuaVoucher);
            GiaoDienHelper.ApDungNutPhu(btnXoaVoucher);
            GiaoDienHelper.ApDungNutPhu(btnXoaLocVoucher);
            flpDanhSachVoucher.SizeChanged += FlpDanhSachVoucher_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            var danhSach = await voucherController.LayDanhSachVoucher();
            danhSachVoucherHienThi = danhSach.Select(voucher => new VoucherHienThi(
                voucher.MaVoucher,
                voucher.MaGiamGia,
                voucher.TenVoucher,
                voucher.KieuGiamGia,
                voucher.GiaTriGiam,
                voucher.NgayBatDau,
                voucher.NgayKetThuc,
                voucher.SoLuong,
                voucher.TrangThai)).ToList();

            HienThiDanhSachVoucher();
        }

        private void HienThiDanhSachVoucher()
        {
            flpDanhSachVoucher.SuspendLayout();
            flpDanhSachVoucher.Controls.Clear();
            theVoucherDangChon = null;

            var tuKhoa = txtTimKiemVoucher.Text.Trim();
            IEnumerable<VoucherHienThi> danhSachLoc = danhSachVoucherHienThi;
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                danhSachLoc = danhSachLoc.Where(voucher => KhopTuKhoaTimKiem(voucher, tuKhoa));
            }

            foreach (var voucher in danhSachLoc)
            {
                flpDanhSachVoucher.Controls.Add(TaoTheVoucher(voucher));
            }

            if (flpDanhSachVoucher.Controls.Count == 0)
            {
                flpDanhSachVoucher.Controls.Add(new Label
                {
                    Text = "Không tìm thấy voucher phù hợp.",
                    AutoSize = true,
                    Margin = new Padding(12),
                    ForeColor = Color.FromArgb(90, 90, 90)
                });
            }

            flpDanhSachVoucher.ResumeLayout();
        }

        private static bool KhopTuKhoaTimKiem(VoucherHienThi voucher, string tuKhoa)
        {
            return CoChua(voucher.MaGiamGia, tuKhoa)
                || CoChua(voucher.TenVoucher, tuKhoa)
                || CoChua(voucher.KieuGiamGia, tuKhoa)
                || CoChua(GiaoDienHelper.DinhDangKieuGiamGia(voucher.KieuGiamGia), tuKhoa)
                || CoChua(GiaoDienHelper.DinhDangTrangThai(voucher.TrangThai), tuKhoa)
                || CoChua(voucher.SoLuong.ToString(), tuKhoa);
        }

        private static bool CoChua(string? noiDung, string tuKhoa)
        {
            return !string.IsNullOrWhiteSpace(noiDung)
                && noiDung.Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase);
        }

        private Panel TaoTheVoucher(VoucherHienThi voucher)
        {
            var the = new Panel
            {
                Width = flpDanhSachVoucher.ClientSize.Width - flpDanhSachVoucher.Padding.Horizontal - 24,
                Height = 164,
                BackColor = mauNenMacDinh,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Tag = voucher
            };
            GiaoDienHelper.ApDungThe(the);

            var lblTen = new Label
            {
                Text = voucher.TenVoucher,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 10),
                AutoSize = true
            };

            var lblMa = new Label
            {
                Text = "Mã giảm giá: " + voucher.MaGiamGia,
                Location = new Point(12, 38),
                AutoSize = true
            };

            var lblGiaTri = new Label
            {
                Text = "Giá trị: " + voucher.GiaTriGiam.ToString("N0") + (voucher.KieuGiamGia == "PhanTram" ? " %" : " VNĐ"),
                Location = new Point(12, 60),
                AutoSize = true
            };

            var lblKieuGiamGia = new Label
            {
                Text = "Kiểu giảm giá: " + GiaoDienHelper.DinhDangKieuGiamGia(voucher.KieuGiamGia),
                Location = new Point(320, 60),
                AutoSize = true
            };

            var lblThoiGian = new Label
            {
                Text = $"Thời gian: {voucher.NgayBatDau:dd/MM/yyyy} - {voucher.NgayKetThuc:dd/MM/yyyy}",
                Location = new Point(12, 82),
                AutoSize = true
            };

            var lblSoLuong = new Label
            {
                Text = "Số lượng: " + voucher.SoLuong,
                Location = new Point(12, 104),
                AutoSize = true
            };

            var lblTrangThai = new Label
            {
                Text = "Trạng thái: " + GiaoDienHelper.DinhDangTrangThai(voucher.TrangThai),
                Location = new Point(12, 126),
                AutoSize = true
            };

            the.Controls.Add(lblTen);
            the.Controls.Add(lblMa);
            the.Controls.Add(lblGiaTri);
            the.Controls.Add(lblKieuGiamGia);
            the.Controls.Add(lblThoiGian);
            the.Controls.Add(lblSoLuong);
            the.Controls.Add(lblTrangThai);
            GanSuKienChonThe(the);
            return the;
        }

        private void GanSuKienChonThe(Control control)
        {
            control.Click += TheVoucher_Click;
            foreach (Control con in control.Controls)
            {
                con.Click += TheVoucher_Click;
            }
        }

        private void TheVoucher_Click(object? sender, EventArgs e)
        {
            var the = LayTheTuControl(sender as Control);
            if (the == null)
            {
                return;
            }

            if (theVoucherDangChon != null)
            {
                theVoucherDangChon.BackColor = mauNenMacDinh;
            }

            the.BackColor = mauNenChon;
            theVoucherDangChon = the;
        }

        private static Panel? LayTheTuControl(Control? control)
        {
            while (control != null && control is not Panel)
            {
                control = control.Parent;
            }

            return control as Panel;
        }

        private VoucherHienThi? LayVoucherDangChon()
        {
            return theVoucherDangChon?.Tag as VoucherHienThi;
        }

        private void FlpDanhSachVoucher_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control control in flpDanhSachVoucher.Controls)
            {
                if (control is Panel the)
                {
                    the.Width = flpDanhSachVoucher.ClientSize.Width - flpDanhSachVoucher.Padding.Horizontal - 24;
                }
            }
        }

        private async void btnThemVoucher_Click(object sender, EventArgs e)
        {
            var formNhap = new frmNhapVoucher(null);
            if (formNhap.ShowDialog() != DialogResult.OK || formNhap.VoucherHienTai == null)
            {
                return;
            }

            try
            {
                var v = formNhap.VoucherHienTai.Value;
                await voucherController.ThemVoucher(v.MaGiamGia, v.TenVoucher, v.KieuGiamGia, v.GiaTriGiam, v.NgayBatDau, v.NgayKetThuc, v.SoLuong);
                await TaiDuLieu();
                MessageBox.Show("Đã thêm voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaVoucher_Click(object sender, EventArgs e)
        {
            var voucherChon = LayVoucherDangChon();
            if (voucherChon == null)
            {
                MessageBox.Show("Vui lòng chọn voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var voucher = (
                voucherChon.MaVoucher,
                voucherChon.MaGiamGia,
                voucherChon.TenVoucher,
                voucherChon.KieuGiamGia,
                voucherChon.GiaTriGiam,
                voucherChon.NgayBatDau,
                voucherChon.NgayKetThuc,
                voucherChon.SoLuong
            );

            var formNhap = new frmNhapVoucher(voucher);
            if (formNhap.ShowDialog() != DialogResult.OK || formNhap.VoucherHienTai == null)
            {
                return;
            }

            try
            {
                var v = formNhap.VoucherHienTai.Value;
                await voucherController.SuaVoucher(voucherChon.MaVoucher, v.MaGiamGia, v.TenVoucher, v.KieuGiamGia, v.GiaTriGiam, v.NgayBatDau, v.NgayKetThuc, v.SoLuong);
                await TaiDuLieu();
                MessageBox.Show("Đã cập nhật voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaVoucher_Click(object sender, EventArgs e)
        {
            var voucherChon = LayVoucherDangChon();
            if (voucherChon == null)
            {
                MessageBox.Show("Vui lòng chọn voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa voucher này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await voucherController.XoaVoucher(voucherChon.MaVoucher);
                await TaiDuLieu();
                MessageBox.Show("Đã xóa voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiemVoucher_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachVoucher();
        }

        private void btnXoaLocVoucher_Click(object sender, EventArgs e)
        {
            txtTimKiemVoucher.Clear();
            txtTimKiemVoucher.Focus();
        }
    }
}
