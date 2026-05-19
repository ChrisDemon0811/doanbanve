namespace doanbanve.Forms
{
    partial class frmCapNhatThongTinNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Button btnLuu;
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
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(24, 24);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(57, 20);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(140, 20);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(320, 27);
            txtHoTen.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(24, 64);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(140, 60);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 27);
            txtEmail.TabIndex = 3;
            // 
            // lblSoDienThoai
            // 
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(24, 104);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Size = new Size(100, 20);
            lblSoDienThoai.TabIndex = 4;
            lblSoDienThoai.Text = "Số điện thoại:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(140, 100);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(320, 27);
            txtSoDienThoai.TabIndex = 5;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(268, 148);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 30);
            btnLuu.TabIndex = 6;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(370, 148);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(90, 30);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmCapNhatThongTinNguoiDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 200);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtSoDienThoai);
            Controls.Add(lblSoDienThoai);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCapNhatThongTinNguoiDung";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập nhật thông tin";
            Load += frmCapNhatThongTinNguoiDung_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
