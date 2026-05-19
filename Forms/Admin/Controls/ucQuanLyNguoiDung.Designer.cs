namespace doanbanve.Forms
{
    partial class ucQuanLyNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachNguoiDung;
        private Button btnResetMatKhau;
        private Button btnXemThongTin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            flpDanhSachNguoiDung = new FlowLayoutPanel();
            btnResetMatKhau = new Button();
            btnXemThongTin = new Button();
            SuspendLayout();
            // 
            // flpDanhSachNguoiDung
            // 
            flpDanhSachNguoiDung.AutoScroll = true;
            flpDanhSachNguoiDung.FlowDirection = FlowDirection.TopDown;
            flpDanhSachNguoiDung.Location = new Point(0, 0);
            flpDanhSachNguoiDung.Name = "flpDanhSachNguoiDung";
            flpDanhSachNguoiDung.Padding = new Padding(8);
            flpDanhSachNguoiDung.Size = new Size(968, 533);
            flpDanhSachNguoiDung.TabIndex = 0;
            flpDanhSachNguoiDung.WrapContents = false;
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.Location = new Point(0, 557);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(140, 32);
            btnResetMatKhau.TabIndex = 1;
            btnResetMatKhau.Text = "Reset mật khẩu";
            btnResetMatKhau.UseVisualStyleBackColor = true;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // btnXemThongTin
            // 
            btnXemThongTin.Location = new Point(156, 557);
            btnXemThongTin.Name = "btnXemThongTin";
            btnXemThongTin.Size = new Size(140, 32);
            btnXemThongTin.TabIndex = 2;
            btnXemThongTin.Text = "Xem thông tin";
            btnXemThongTin.UseVisualStyleBackColor = true;
            btnXemThongTin.Click += btnXemThongTin_Click;
            // 
            // ucQuanLyNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXemThongTin);
            Controls.Add(btnResetMatKhau);
            Controls.Add(flpDanhSachNguoiDung);
            Name = "ucQuanLyNguoiDung";
            Size = new Size(968, 608);
            ResumeLayout(false);
        }
    }
}
