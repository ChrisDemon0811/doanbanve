namespace doanbanve.Forms
{
    partial class frmNhapLoaiVe
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenLoaiVe;
        private TextBox txtTenLoaiVe;
        private Label lblMoTa;
        private TextBox txtMoTa;
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
            lblTenLoaiVe = new Label();
            txtTenLoaiVe = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblTenLoaiVe
            // 
            lblTenLoaiVe.AutoSize = true;
            lblTenLoaiVe.Location = new Point(20, 20);
            lblTenLoaiVe.Name = "lblTenLoaiVe";
            lblTenLoaiVe.Size = new Size(75, 15);
            lblTenLoaiVe.TabIndex = 0;
            lblTenLoaiVe.Text = "Tên loại vé:";
            // 
            // txtTenLoaiVe
            // 
            txtTenLoaiVe.Location = new Point(120, 16);
            txtTenLoaiVe.Name = "txtTenLoaiVe";
            txtTenLoaiVe.Size = new Size(240, 23);
            txtTenLoaiVe.TabIndex = 1;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 56);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(40, 15);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(120, 52);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(240, 80);
            txtMoTa.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(184, 146);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 28);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(280, 146);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 28);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmNhapLoaiVe
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 190);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtTenLoaiVe);
            Controls.Add(lblTenLoaiVe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmNhapLoaiVe";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin loại vé";
            Load += frmNhapLoaiVe_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
