namespace doanbanve.Forms.Admin.Forms
{
    partial class frmQuanLyAI
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private Label lblNhaCungCap;
        private Label lblKhoaApi;
        private Label lblMoHinh;
        private Label lblNhacLenh;
        private TextBox txtNhaCungCap;
        private TextBox txtKhoaApi;
        private TextBox txtMoHinh;
        private RichTextBox rtbNhacLenh;
        private Button btnLuu;

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
            lblNhaCungCap = new Label();
            lblKhoaApi = new Label();
            lblMoHinh = new Label();
            lblNhacLenh = new Label();
            txtNhaCungCap = new TextBox();
            txtKhoaApi = new TextBox();
            txtMoHinh = new TextBox();
            rtbNhacLenh = new RichTextBox();
            btnLuu = new Button();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(24, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(191, 32);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Quản lý cấu hình AI";
            // 
            // lblNhaCungCap
            // 
            lblNhaCungCap.AutoSize = true;
            lblNhaCungCap.Location = new Point(24, 72);
            lblNhaCungCap.Name = "lblNhaCungCap";
            lblNhaCungCap.Size = new Size(96, 20);
            lblNhaCungCap.TabIndex = 1;
            lblNhaCungCap.Text = "Nhà cung cấp";
            // 
            // txtNhaCungCap
            // 
            txtNhaCungCap.Location = new Point(24, 96);
            txtNhaCungCap.Name = "txtNhaCungCap";
            txtNhaCungCap.Size = new Size(520, 27);
            txtNhaCungCap.TabIndex = 2;
            // 
            // lblKhoaApi
            // 
            lblKhoaApi.AutoSize = true;
            lblKhoaApi.Location = new Point(24, 136);
            lblKhoaApi.Name = "lblKhoaApi";
            lblKhoaApi.Size = new Size(60, 20);
            lblKhoaApi.TabIndex = 3;
            lblKhoaApi.Text = "Khóa API";
            // 
            // txtKhoaApi
            // 
            txtKhoaApi.Location = new Point(24, 160);
            txtKhoaApi.Name = "txtKhoaApi";
            txtKhoaApi.Size = new Size(520, 27);
            txtKhoaApi.TabIndex = 4;
            // 
            // lblMoHinh
            // 
            lblMoHinh.AutoSize = true;
            lblMoHinh.Location = new Point(24, 200);
            lblMoHinh.Name = "lblMoHinh";
            lblMoHinh.Size = new Size(55, 20);
            lblMoHinh.TabIndex = 5;
            lblMoHinh.Text = "Mô hình";
            // 
            // txtMoHinh
            // 
            txtMoHinh.Location = new Point(24, 224);
            txtMoHinh.Name = "txtMoHinh";
            txtMoHinh.Size = new Size(520, 27);
            txtMoHinh.TabIndex = 6;
            // 
            // lblNhacLenh
            // 
            lblNhacLenh.AutoSize = true;
            lblNhacLenh.Location = new Point(24, 264);
            lblNhacLenh.Name = "lblNhacLenh";
            lblNhacLenh.Size = new Size(73, 20);
            lblNhacLenh.TabIndex = 7;
            lblNhacLenh.Text = "Nhắc lệnh";
            // 
            // rtbNhacLenh
            // 
            rtbNhacLenh.Location = new Point(24, 288);
            rtbNhacLenh.Name = "rtbNhacLenh";
            rtbNhacLenh.Size = new Size(520, 160);
            rtbNhacLenh.TabIndex = 8;
            rtbNhacLenh.Text = "";
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(444, 464);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 32);
            btnLuu.TabIndex = 9;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // frmQuanLyAI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(580, 520);
            Controls.Add(btnLuu);
            Controls.Add(rtbNhacLenh);
            Controls.Add(lblNhacLenh);
            Controls.Add(txtMoHinh);
            Controls.Add(lblMoHinh);
            Controls.Add(txtKhoaApi);
            Controls.Add(lblKhoaApi);
            Controls.Add(txtNhaCungCap);
            Controls.Add(lblNhaCungCap);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmQuanLyAI";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Quản lý AI";
            Load += frmQuanLyAI_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
