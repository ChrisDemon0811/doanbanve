namespace doanbanve.Forms
{
    partial class frmDatMatKhauNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTaiKhoan;
        private Label lblMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Button btnXacNhan;
        private Button btnHuy;

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
            lblTaiKhoan = new Label();
            lblMatKhauMoi = new Label();
            txtMatKhauMoi = new TextBox();
            btnXacNhan = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblTaiKhoan
            // 
            lblTaiKhoan.AutoSize = true;
            lblTaiKhoan.Location = new Point(16, 16);
            lblTaiKhoan.Name = "lblTaiKhoan";
            lblTaiKhoan.Size = new Size(74, 20);
            lblTaiKhoan.TabIndex = 0;
            lblTaiKhoan.Text = "Tài khoản:";
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(16, 48);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(94, 20);
            lblMatKhauMoi.TabIndex = 1;
            lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(120, 44);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.Size = new Size(220, 27);
            txtMatKhauMoi.TabIndex = 2;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(180, 84);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(80, 28);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(270, 84);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(70, 28);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmDatMatKhauNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 126);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(lblTaiKhoan);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDatMatKhauNguoiDung";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reset mật khẩu";
            Load += frmDatMatKhauNguoiDung_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
