namespace doanbanve.Forms
{
    partial class ucQuanLyNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachNguoiDung;
        private Button btnResetMatKhau;
        private Button btnXemThongTin;
        private Label lblTimKiemNguoiDung;
        private TextBox txtTimKiemNguoiDung;
        private Button btnXoaLocNguoiDung;

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
            lblTimKiemNguoiDung = new Label();
            txtTimKiemNguoiDung = new TextBox();
            btnXoaLocNguoiDung = new Button();
            SuspendLayout();
            // 
            // flpDanhSachNguoiDung
            // 
            flpDanhSachNguoiDung.AutoScroll = true;
            flpDanhSachNguoiDung.FlowDirection = FlowDirection.TopDown;
            flpDanhSachNguoiDung.Location = new Point(0, 44);
            flpDanhSachNguoiDung.Name = "flpDanhSachNguoiDung";
            flpDanhSachNguoiDung.Padding = new Padding(8);
            flpDanhSachNguoiDung.Size = new Size(968, 489);
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
            // lblTimKiemNguoiDung
            // 
            lblTimKiemNguoiDung.AutoSize = true;
            lblTimKiemNguoiDung.Location = new Point(0, 12);
            lblTimKiemNguoiDung.Name = "lblTimKiemNguoiDung";
            lblTimKiemNguoiDung.Size = new Size(73, 20);
            lblTimKiemNguoiDung.TabIndex = 3;
            lblTimKiemNguoiDung.Text = "Tìm kiếm:";
            // 
            // txtTimKiemNguoiDung
            // 
            txtTimKiemNguoiDung.Location = new Point(74, 8);
            txtTimKiemNguoiDung.Name = "txtTimKiemNguoiDung";
            txtTimKiemNguoiDung.Size = new Size(300, 27);
            txtTimKiemNguoiDung.TabIndex = 4;
            txtTimKiemNguoiDung.TextChanged += txtTimKiemNguoiDung_TextChanged;
            // 
            // btnXoaLocNguoiDung
            // 
            btnXoaLocNguoiDung.Location = new Point(382, 8);
            btnXoaLocNguoiDung.Name = "btnXoaLocNguoiDung";
            btnXoaLocNguoiDung.Size = new Size(96, 27);
            btnXoaLocNguoiDung.TabIndex = 5;
            btnXoaLocNguoiDung.Text = "Xóa lọc";
            btnXoaLocNguoiDung.UseVisualStyleBackColor = true;
            btnXoaLocNguoiDung.Click += btnXoaLocNguoiDung_Click;
            // 
            // ucQuanLyNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaLocNguoiDung);
            Controls.Add(txtTimKiemNguoiDung);
            Controls.Add(lblTimKiemNguoiDung);
            Controls.Add(btnXemThongTin);
            Controls.Add(btnResetMatKhau);
            Controls.Add(flpDanhSachNguoiDung);
            Name = "ucQuanLyNguoiDung";
            Size = new Size(968, 608);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
