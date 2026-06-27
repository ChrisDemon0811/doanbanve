using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class ucQuanLyHoaDon : UserControl
    {
        private readonly HoaDonController hoaDonController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theHoaDonDangChon;
        private List<Models.ThongTinHoaDon> danhSachHoaDon = new();

        public ucQuanLyHoaDon()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutPhu(btnChiTietHoaDon);
            GiaoDienHelper.ApDungNutPhu(btnXoaLocHoaDon);
            flpDanhSachHoaDon.SizeChanged += FlpDanhSachHoaDon_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            danhSachHoaDon = await hoaDonController.LayDanhSachHoaDonQuanLy();
            HienThiDanhSachHoaDon();
        }

        private void HienThiDanhSachHoaDon()
        {
            flpDanhSachHoaDon.SuspendLayout();
            flpDanhSachHoaDon.Controls.Clear();
            theHoaDonDangChon = null;

            var tuKhoa = txtTimKiemHoaDon.Text.Trim();
            IEnumerable<Models.ThongTinHoaDon> danhSachLoc = danhSachHoaDon;
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                danhSachLoc = danhSachLoc.Where(hoaDon => KhopTuKhoaTimKiem(hoaDon, tuKhoa));
            }

            foreach (var hoaDon in danhSachLoc)
            {
                flpDanhSachHoaDon.Controls.Add(TaoTheHoaDon(hoaDon));
            }

            if (flpDanhSachHoaDon.Controls.Count == 0)
            {
                flpDanhSachHoaDon.Controls.Add(new Label
                {
                    Text = "Không tìm thấy hóa đơn phù hợp.",
                    AutoSize = true,
                    Margin = new Padding(12),
                    ForeColor = Color.FromArgb(90, 90, 90)
                });
            }

            flpDanhSachHoaDon.ResumeLayout();
        }

        private static bool KhopTuKhoaTimKiem(Models.ThongTinHoaDon hoaDon, string tuKhoa)
        {
            return CoChua(hoaDon.MaHoaDon.ToString(), tuKhoa)
                || CoChua(hoaDon.HoTenNguoiDat, tuKhoa)
                || CoChua(hoaDon.TrangThai, tuKhoa)
                || CoChua(GiaoDienHelper.DinhDangTrangThaiHoaDon(hoaDon.TrangThai), tuKhoa)
                || CoChua(hoaDon.ThanhToan, tuKhoa)
                || CoChua(GiaoDienHelper.DinhDangThanhToan(hoaDon.ThanhToan), tuKhoa);
        }

        private static bool CoChua(string? noiDung, string tuKhoa)
        {
            return !string.IsNullOrWhiteSpace(noiDung)
                && noiDung.Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase);
        }

        private Panel TaoTheHoaDon(Models.ThongTinHoaDon hoaDon)
        {
            var the = new Panel
            {
                Width = flpDanhSachHoaDon.ClientSize.Width - flpDanhSachHoaDon.Padding.Horizontal - 24,
                Height = 130,
                BackColor = mauNenMacDinh,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Tag = hoaDon
            };
            GiaoDienHelper.ApDungThe(the);

            var lblMa = new Label
            {
                Text = $"Hóa đơn #{hoaDon.MaHoaDon}",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 10),
                AutoSize = true
            };

            var lblNguoiDat = new Label
            {
                Text = "Người đặt: " + hoaDon.HoTenNguoiDat,
                Location = new Point(12, 38),
                AutoSize = true
            };

            var lblNgayLap = new Label
            {
                Text = "Ngày lập: " + hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                Location = new Point(12, 60),
                AutoSize = true
            };

            var lblThanhTien = new Label
            {
                Text = "Thành tiền: " + hoaDon.ThanhTien.ToString("N0") + " VNĐ",
                Location = new Point(320, 38),
                AutoSize = true
            };

            var lblTrangThai = new Label
            {
                Text = "Trạng thái: " + GiaoDienHelper.DinhDangTrangThaiHoaDon(hoaDon.TrangThai),
                Location = new Point(320, 60),
                AutoSize = true
            };

            var lblThanhToan = new Label
            {
                Text = "Thanh toán: " + GiaoDienHelper.DinhDangThanhToan(hoaDon.ThanhToan),
                Location = new Point(320, 82),
                AutoSize = true
            };

            the.Controls.Add(lblMa);
            the.Controls.Add(lblNguoiDat);
            the.Controls.Add(lblNgayLap);
            the.Controls.Add(lblThanhTien);
            the.Controls.Add(lblTrangThai);
            the.Controls.Add(lblThanhToan);
            GanSuKienChonThe(the);
            return the;
        }

        private void GanSuKienChonThe(Control control)
        {
            control.Click += TheHoaDon_Click;
            foreach (Control con in control.Controls)
            {
                con.Click += TheHoaDon_Click;
            }
        }

        private void TheHoaDon_Click(object? sender, EventArgs e)
        {
            var the = LayTheTuControl(sender as Control);
            if (the == null)
            {
                return;
            }

            if (theHoaDonDangChon != null)
            {
                theHoaDonDangChon.BackColor = mauNenMacDinh;
            }

            the.BackColor = mauNenChon;
            theHoaDonDangChon = the;
        }

        private static Panel? LayTheTuControl(Control? control)
        {
            while (control != null && control is not Panel)
            {
                control = control.Parent;
            }

            return control as Panel;
        }

        private Models.ThongTinHoaDon? LayHoaDonDangChon()
        {
            return theHoaDonDangChon?.Tag as Models.ThongTinHoaDon;
        }

        private void FlpDanhSachHoaDon_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control control in flpDanhSachHoaDon.Controls)
            {
                if (control is Panel the)
                {
                    the.Width = flpDanhSachHoaDon.ClientSize.Width - flpDanhSachHoaDon.Padding.Horizontal - 24;
                }
            }
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            var hoaDon = LayHoaDonDangChon();
            if (hoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var formChiTiet = new frmChiTietHoaDonQuanLy(hoaDon.MaHoaDon);
            formChiTiet.ShowDialog();
        }

        private void txtTimKiemHoaDon_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachHoaDon();
        }

        private void btnXoaLocHoaDon_Click(object sender, EventArgs e)
        {
            txtTimKiemHoaDon.Clear();
            txtTimKiemHoaDon.Focus();
        }
    }
}
