namespace doanbanve.Forms
{
    partial class frmDangKy
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Label lblMatKhau;
        private Label lblHoTen;
        private Label lblEmail;
        private Label lblSoDienThoai;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtSoDienThoai;
        private Button btnDangKy;

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
            lblTaiKhoan = new Label();
            lblMatKhau = new Label();
            lblHoTen = new Label();
            lblEmail = new Label();
            lblSoDienThoai = new Label();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            txtSoDienThoai = new TextBox();
            btnDangKy = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDe.Location = new Point(152, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(177, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "ĐĂNG KÝ TÀI KHOẢN";
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(52, 72);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(69, 15);
            lblTaiKhoan.TabIndex = 1;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(52, 112);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(63, 15);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(52, 152);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(44, 15);
            lblHoTen.TabIndex = 3;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(52, 192);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(52, 232);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(79, 15);
            lblSoDienThoai.TabIndex = 5;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(156, 69);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(240, 23);
            txtTaiKhoan.TabIndex = 6;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(156, 109);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(240, 23);
            txtMatKhau.TabIndex = 7;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(156, 149);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(240, 23);
            txtHoTen.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(156, 189);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 23);
            txtEmail.TabIndex = 9;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(156, 229);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(240, 23);
            txtSoDienThoai.TabIndex = 10;
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(156, 276);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(96, 30);
            btnDangKy.TabIndex = 11;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // frmDangKy
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 340);
            Controls.Add(btnDangKy);
            Controls.Add(txtSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTaiKhoan);
            Controls.Add(lblSoDienThoai);
            Controls.Add(lblEmail);
            Controls.Add(lblHoTen);
            Controls.Add(lblMatKhau);
            Controls.Add(lblTaiKhoan);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDangKy";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đăng ký";
            AcceptButton = btnDangKy;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
