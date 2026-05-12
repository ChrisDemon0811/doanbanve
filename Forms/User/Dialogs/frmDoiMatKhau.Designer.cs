namespace doanbanve.Forms
{
    partial class frmDoiMatKhau
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMatKhauCu;
        private Label lblMatKhauMoi;
        private Label lblMatKhauXacNhan;
        private TextBox txtMatKhauCu;
        private TextBox txtMatKhauMoi;
        private TextBox txtMatKhauXacNhan;
        private Button btnDoiMatKhau;

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
            lblMatKhauCu = new Label();
            lblMatKhauMoi = new Label();
            lblMatKhauXacNhan = new Label();
            txtMatKhauCu = new TextBox();
            txtMatKhauMoi = new TextBox();
            txtMatKhauXacNhan = new TextBox();
            btnDoiMatKhau = new Button();
            SuspendLayout();
            // 
            // lblMatKhauCu
            // 
            lblMatKhauCu.AutoSize = true;
            lblMatKhauCu.Location = new Point(20, 20);
            lblMatKhauCu.Name = "lblMatKhauCu";
            lblMatKhauCu.Size = new Size(86, 15);
            lblMatKhauCu.TabIndex = 0;
            lblMatKhauCu.Text = "Mật khẩu hiện tại:";
            // 
            // txtMatKhauCu
            // 
            txtMatKhauCu.Location = new Point(160, 16);
            txtMatKhauCu.Name = "txtMatKhauCu";
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauCu.Size = new Size(200, 23);
            txtMatKhauCu.TabIndex = 1;
            // 
            // lblMatKhauMoi
            // 
            lblMatKhauMoi.AutoSize = true;
            lblMatKhauMoi.Location = new Point(20, 56);
            lblMatKhauMoi.Name = "lblMatKhauMoi";
            lblMatKhauMoi.Size = new Size(86, 15);
            lblMatKhauMoi.TabIndex = 2;
            lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Location = new Point(160, 52);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.Size = new Size(200, 23);
            txtMatKhauMoi.TabIndex = 3;
            // 
            // lblMatKhauXacNhan
            // 
            lblMatKhauXacNhan.AutoSize = true;
            lblMatKhauXacNhan.Location = new Point(20, 92);
            lblMatKhauXacNhan.Name = "lblMatKhauXacNhan";
            lblMatKhauXacNhan.Size = new Size(101, 15);
            lblMatKhauXacNhan.TabIndex = 4;
            lblMatKhauXacNhan.Text = "Xác nhận mật khẩu:";
            // 
            // txtMatKhauXacNhan
            // 
            txtMatKhauXacNhan.Location = new Point(160, 88);
            txtMatKhauXacNhan.Name = "txtMatKhauXacNhan";
            txtMatKhauXacNhan.PasswordChar = '*';
            txtMatKhauXacNhan.Size = new Size(200, 23);
            txtMatKhauXacNhan.TabIndex = 5;
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.Location = new Point(160, 128);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(120, 28);
            btnDoiMatKhau.TabIndex = 6;
            btnDoiMatKhau.Text = "Đổi mật khẩu";
            btnDoiMatKhau.UseVisualStyleBackColor = true;
            btnDoiMatKhau.Click += btnDoiMatKhau_Click;
            // 
            // frmDoiMatKhau
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 180);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(txtMatKhauXacNhan);
            Controls.Add(lblMatKhauXacNhan);
            Controls.Add(txtMatKhauMoi);
            Controls.Add(lblMatKhauMoi);
            Controls.Add(txtMatKhauCu);
            Controls.Add(lblMatKhauCu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDoiMatKhau";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
