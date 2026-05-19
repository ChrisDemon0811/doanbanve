using doanbanve.Controllers;

namespace doanbanve.Forms
{
    public partial class ucQuanLyNguoiDung : UserControl
    {
        private readonly NguoiDungController nguoiDungController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theNguoiDungDangChon;

        public ucQuanLyNguoiDung()
        {
            InitializeComponent();
            flpDanhSachNguoiDung.SizeChanged += FlpDanhSachNguoiDung_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            flpDanhSachNguoiDung.SuspendLayout();
            flpDanhSachNguoiDung.Controls.Clear();
            theNguoiDungDangChon = null;
            var danhSach = await nguoiDungController.LayDanhSachNguoiDung();
            foreach (var nguoiDung in danhSach)
            {
                flpDanhSachNguoiDung.Controls.Add(TaoTheNguoiDung(nguoiDung));
            }
            flpDanhSachNguoiDung.ResumeLayout();
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
                Text = "Vai trò: " + nguoiDung.VaiTro,
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
            var vaiTro = nguoiDung.VaiTro;

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
    }
}
