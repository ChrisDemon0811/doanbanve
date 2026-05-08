namespace doanbanve.Forms
{
    partial class frmDashboardNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private Label lblXinChao;
        private Label lblThongTin;
        private Button btnDangXuat;
        private Button btnDangNhap;
        private Button btnDangKy;
        private Button btnGioHang;
        private Button btnThongTinNguoiDung;
        private FlowLayoutPanel pnlLoaiVe;
        private FlowLayoutPanel pnlVe;

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
            lblTieuDe = new Label();
            lblXinChao = new Label();
            lblThongTin = new Label();
            btnDangXuat = new Button();
            btnDangNhap = new Button();
            btnDangKy = new Button();
            btnGioHang = new Button();
            btnThongTinNguoiDung = new Button();
            pnlLoaiVe = new FlowLayoutPanel();
            pnlVe = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(322, 41);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "DASHBOARD BÁN VÉ";
            // 
            // lblXinChao
            // 
            lblXinChao.AutoSize = true;
            lblXinChao.Font = new Font("Segoe UI", 11F);
            lblXinChao.Location = new Point(24, 64);
            lblXinChao.Name = "lblXinChao";
            lblXinChao.Size = new Size(90, 25);
            lblXinChao.TabIndex = 1;
            lblXinChao.Text = "Xin chào!";
            // 
            // lblThongTin
            // 
            lblThongTin.AutoSize = true;
            lblThongTin.Location = new Point(24, 92);
            lblThongTin.Name = "lblThongTin";
            lblThongTin.Size = new Size(0, 20);
            lblThongTin.TabIndex = 2;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Location = new Point(24, 124);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(120, 32);
            btnDangXuat.TabIndex = 3;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(24, 124);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(120, 32);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(152, 124);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(120, 32);
            btnDangKy.TabIndex = 5;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnGioHang
            // 
            btnGioHang.Location = new Point(664, 24);
            btnGioHang.Name = "btnGioHang";
            btnGioHang.Size = new Size(120, 32);
            btnGioHang.TabIndex = 6;
            btnGioHang.Text = "Giỏ hàng";
            btnGioHang.UseVisualStyleBackColor = true;
            btnGioHang.Click += btnGioHang_Click;
            // 
            // btnThongTinNguoiDung
            // 
            btnThongTinNguoiDung.Location = new Point(520, 24);
            btnThongTinNguoiDung.Name = "btnThongTinNguoiDung";
            btnThongTinNguoiDung.Size = new Size(130, 32);
            btnThongTinNguoiDung.TabIndex = 7;
            btnThongTinNguoiDung.Text = "Thông tin user";
            btnThongTinNguoiDung.UseVisualStyleBackColor = true;
            btnThongTinNguoiDung.Click += btnThongTinNguoiDung_Click;
            // 
            // pnlLoaiVe
            // 
            pnlLoaiVe.AutoScroll = true;
            pnlLoaiVe.Location = new Point(24, 176);
            pnlLoaiVe.Name = "pnlLoaiVe";
            pnlLoaiVe.Size = new Size(776, 50);
            pnlLoaiVe.TabIndex = 6;
            // 
            // pnlVe
            // 
            pnlVe.AutoScroll = true;
            pnlVe.Location = new Point(24, 232);
            pnlVe.Name = "pnlVe";
            pnlVe.Size = new Size(776, 395);
            pnlVe.TabIndex = 7;
            // 
            // frmDashboardNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 640);
            Controls.Add(pnlVe);
            Controls.Add(pnlLoaiVe);
            Controls.Add(btnThongTinNguoiDung);
            Controls.Add(btnGioHang);
            Controls.Add(btnDangKy);
            Controls.Add(btnDangNhap);
            Controls.Add(btnDangXuat);
            Controls.Add(lblThongTin);
            Controls.Add(lblXinChao);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDashboardNguoiDung";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard User";
            Load += frmDashboardNguoiDung_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
