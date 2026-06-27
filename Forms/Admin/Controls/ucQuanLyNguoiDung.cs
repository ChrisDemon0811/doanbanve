using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class ucQuanLyNguoiDung : UserControl
    {
        private readonly NguoiDungController nguoiDungController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theNguoiDungDangChon;
        private List<Models.NguoiDung> danhSachNguoiDung = new();

        public ucQuanLyNguoiDung()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutPhu(btnXemThongTin);
            GiaoDienHelper.ApDungNutPhu(btnResetMatKhau);
            GiaoDienHelper.ApDungNutPhu(btnXoaLocNguoiDung);
            flpDanhSachNguoiDung.SizeChanged += FlpDanhSachNguoiDung_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            danhSachNguoiDung = await nguoiDungController.LayDanhSachNguoiDung();
            HienThiDanhSachNguoiDung();
        }

        private void HienThiDanhSachNguoiDung()
        {
            flpDanhSachNguoiDung.SuspendLayout();
            flpDanhSachNguoiDung.Controls.Clear();
            theNguoiDungDangChon = null;

            var tuKhoa = txtTimKiemNguoiDung.Text.Trim();
            IEnumerable<Models.NguoiDung> danhSachLoc = danhSachNguoiDung;
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                danhSachLoc = danhSachLoc.Where(nguoiDung => KhopTuKhoaTimKiem(nguoiDung, tuKhoa));
            }

            foreach (var nguoiDung in danhSachLoc)
            {
                flpDanhSachNguoiDung.Controls.Add(TaoTheNguoiDung(nguoiDung));
            }

            if (flpDanhSachNguoiDung.Controls.Count == 0)
            {
                flpDanhSachNguoiDung.Controls.Add(new Label
                {
                    Text = "Không tìm thấy người dùng phù hợp.",
                    AutoSize = true,
                    Margin = new Padding(12),
                    ForeColor = Color.FromArgb(90, 90, 90)
                });
            }

            flpDanhSachNguoiDung.ResumeLayout();
        }

        private static bool KhopTuKhoaTimKiem(Models.NguoiDung nguoiDung, string tuKhoa)
        {
            return CoChua(nguoiDung.HoTen, tuKhoa)
                || CoChua(nguoiDung.TaiKhoan, tuKhoa)
                || CoChua(nguoiDung.Email, tuKhoa)
                || CoChua(nguoiDung.SoDienThoai, tuKhoa)
                || CoChua(nguoiDung.VaiTro, tuKhoa)
                || CoChua(GiaoDienHelper.DinhDangVaiTro(nguoiDung.VaiTro), tuKhoa);
        }

        private static bool CoChua(string? noiDung, string tuKhoa)
        {
            return !string.IsNullOrWhiteSpace(noiDung)
                && noiDung.Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase);
        }

        private Panel TaoTheNguoiDung(Models.NguoiDung nguoiDung)
        {
            var the = new Panel
            {
                Width = flpDanhSachNguoiDung.ClientSize.Width - flpDanhSachNguoiDung.Padding.Horizontal - 24,
                Height = 110,
                BackColor = mauNenMacDinh,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Tag = nguoiDung
            };
            GiaoDienHelper.ApDungThe(the);

            var lblHoTen = new Label
            {
                Text = nguoiDung.HoTen,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 10),
                AutoSize = true
            };

            var lblTaiKhoan = new Label
            {
                Text = "Tài khoản: " + nguoiDung.TaiKhoan,
                Location = new Point(12, 38),
                AutoSize = true
            };

            var lblEmail = new Label
            {
                Text = "Email: " + (nguoiDung.Email ?? "Chưa cập nhật"),
                Location = new Point(12, 60),
                AutoSize = true
            };

            var lblVaiTro = new Label
            {
                Text = "Vai trò: " + GiaoDienHelper.DinhDangVaiTro(nguoiDung.VaiTro),
                Location = new Point(320, 38),
                AutoSize = true
            };

            var lblSoDienThoai = new Label
            {
                Text = "Số điện thoại: " + (nguoiDung.SoDienThoai ?? "Chưa cập nhật"),
                Location = new Point(320, 60),
                AutoSize = true
            };

            the.Controls.Add(lblHoTen);
            the.Controls.Add(lblTaiKhoan);
            the.Controls.Add(lblEmail);
            the.Controls.Add(lblVaiTro);
            the.Controls.Add(lblSoDienThoai);
            GanSuKienChonThe(the);
            return the;
        }

        private void GanSuKienChonThe(Control control)
        {
            control.Click += TheNguoiDung_Click;
            foreach (Control con in control.Controls)
            {
                con.Click += TheNguoiDung_Click;
            }
        }

        private void TheNguoiDung_Click(object? sender, EventArgs e)
        {
            var the = LayTheTuControl(sender as Control);
            if (the == null)
            {
                return;
            }

            if (theNguoiDungDangChon != null)
            {
                theNguoiDungDangChon.BackColor = mauNenMacDinh;
            }

            the.BackColor = mauNenChon;
            theNguoiDungDangChon = the;
        }

        private static Panel? LayTheTuControl(Control? control)
        {
            while (control != null && control is not Panel)
            {
                control = control.Parent;
            }

            return control as Panel;
        }

        private Models.NguoiDung? LayNguoiDungDangChon()
        {
            return theNguoiDungDangChon?.Tag as Models.NguoiDung;
        }

        private void FlpDanhSachNguoiDung_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control control in flpDanhSachNguoiDung.Controls)
            {
                if (control is Panel the)
                {
                    the.Width = flpDanhSachNguoiDung.ClientSize.Width - flpDanhSachNguoiDung.Padding.Horizontal - 24;
                }
            }
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            var nguoiDung = LayNguoiDungDangChon();
            if (nguoiDung == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var hoTen = nguoiDung.HoTen;
            var taiKhoan = nguoiDung.TaiKhoan;
            var email = nguoiDung.Email ?? "";
            var soDienThoai = nguoiDung.SoDienThoai ?? "";
            var vaiTro = GiaoDienHelper.DinhDangVaiTro(nguoiDung.VaiTro);

            MessageBox.Show($"Họ tên: {hoTen}\nTài khoản: {taiKhoan}\nEmail: {email}\nSố điện thoại: {soDienThoai}\nVai trò: {vaiTro}",
                "Thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            var nguoiDung = LayNguoiDungDangChon();
            if (nguoiDung == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maNguoiDung = nguoiDung.MaNguoiDung;
            var taiKhoan = nguoiDung.TaiKhoan;
            using var formDatMatKhau = new frmDatMatKhauNguoiDung(maNguoiDung, taiKhoan);
            formDatMatKhau.ShowDialog();
        }

        private void txtTimKiemNguoiDung_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachNguoiDung();
        }

        private void btnXoaLocNguoiDung_Click(object sender, EventArgs e)
        {
            txtTimKiemNguoiDung.Clear();
            txtTimKiemNguoiDung.Focus();
        }
    }
}
