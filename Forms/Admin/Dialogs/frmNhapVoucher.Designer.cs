namespace doanbanve.Forms
{
    partial class frmNhapVoucher
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblMaGiamGia;
        private TextBox txtMaGiamGia;
        private Label lblTenVoucher;
        private TextBox txtTenVoucher;
        private Label lblKieuGiamGia;
        private ComboBox cboKieuGiamGia;
        private Label lblGiaTriGiam;
        private TextBox txtGiaTriGiam;
        private Label lblNgayBatDau;
        private DateTimePicker dtpNgayBatDau;
        private Label lblNgayKetThuc;
        private DateTimePicker dtpNgayKetThuc;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
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
            lblMaGiamGia = new Label();
            txtMaGiamGia = new TextBox();
            lblTenVoucher = new Label();
            txtTenVoucher = new TextBox();
            lblKieuGiamGia = new Label();
            cboKieuGiamGia = new ComboBox();
            lblGiaTriGiam = new Label();
            txtGiaTriGiam = new TextBox();
            lblNgayBatDau = new Label();
            dtpNgayBatDau = new DateTimePicker();
            lblNgayKetThuc = new Label();
            dtpNgayKetThuc = new DateTimePicker();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblMaGiamGia
            // 
            lblMaGiamGia.AutoSize = true;
            lblMaGiamGia.Location = new Point(28, 28);
            lblMaGiamGia.Name = "lblMaGiamGia";
            lblMaGiamGia.Size = new Size(76, 15);
            lblMaGiamGia.TabIndex = 0;
            lblMaGiamGia.Text = "Mã giảm giá:";
            // 
            // txtMaGiamGia
            // 
            txtMaGiamGia.Location = new Point(180, 24);
            txtMaGiamGia.Name = "txtMaGiamGia";
            txtMaGiamGia.Size = new Size(350, 27);
            txtMaGiamGia.TabIndex = 1;
            // 
            // lblTenVoucher
            // 
            lblTenVoucher.AutoSize = true;
            lblTenVoucher.Location = new Point(28, 76);
            lblTenVoucher.Name = "lblTenVoucher";
            lblTenVoucher.Size = new Size(74, 15);
            lblTenVoucher.TabIndex = 2;
            lblTenVoucher.Text = "Tên voucher:";
            // 
            // txtTenVoucher
            // 
            txtTenVoucher.Location = new Point(180, 72);
            txtTenVoucher.Name = "txtTenVoucher";
            txtTenVoucher.Size = new Size(350, 27);
            txtTenVoucher.TabIndex = 3;
            // 
            // lblKieuGiamGia
            // 
            lblKieuGiamGia.AutoSize = true;
            lblKieuGiamGia.Location = new Point(28, 124);
            lblKieuGiamGia.Name = "lblKieuGiamGia";
            lblKieuGiamGia.Size = new Size(82, 15);
            lblKieuGiamGia.TabIndex = 4;
            lblKieuGiamGia.Text = "Kiểu giảm giá:";
            // 
            // cboKieuGiamGia
            // 
            cboKieuGiamGia.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKieuGiamGia.Location = new Point(180, 120);
            cboKieuGiamGia.Name = "cboKieuGiamGia";
            cboKieuGiamGia.Size = new Size(350, 28);
            cboKieuGiamGia.TabIndex = 5;
            // 
            // lblGiaTriGiam
            // 
            lblGiaTriGiam.AutoSize = true;
            lblGiaTriGiam.Location = new Point(28, 172);
            lblGiaTriGiam.Name = "lblGiaTriGiam";
            lblGiaTriGiam.Size = new Size(78, 15);
            lblGiaTriGiam.TabIndex = 6;
            lblGiaTriGiam.Text = "Giá trị giảm:";
            // 
            // txtGiaTriGiam
            // 
            txtGiaTriGiam.Location = new Point(180, 168);
            txtGiaTriGiam.Name = "txtGiaTriGiam";
            txtGiaTriGiam.Size = new Size(350, 27);
            txtGiaTriGiam.TabIndex = 7;
            // 
            // lblNgayBatDau
            // 
            lblNgayBatDau.AutoSize = true;
            lblNgayBatDau.Location = new Point(28, 220);
            lblNgayBatDau.Name = "lblNgayBatDau";
            lblNgayBatDau.Size = new Size(78, 15);
            lblNgayBatDau.TabIndex = 8;
            lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Location = new Point(180, 216);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(350, 28);
            dtpNgayBatDau.TabIndex = 9;
            // 
            // lblNgayKetThuc
            // 
            lblNgayKetThuc.AutoSize = true;
            lblNgayKetThuc.Location = new Point(28, 268);
            lblNgayKetThuc.Name = "lblNgayKetThuc";
            lblNgayKetThuc.Size = new Size(85, 15);
            lblNgayKetThuc.TabIndex = 10;
            lblNgayKetThuc.Text = "Ngày kết thúc:";
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Location = new Point(180, 264);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(350, 28);
            dtpNgayKetThuc.TabIndex = 11;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(28, 316);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(54, 15);
            lblSoLuong.TabIndex = 12;
            lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(180, 312);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(350, 27);
            txtSoLuong.TabIndex = 13;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(294, 360);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 36);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(418, 360);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(112, 36);
            btnHuy.TabIndex = 15;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // frmNhapVoucher
            // 
            AcceptButton = btnLuu;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHuy;
            ClientSize = new Size(560, 416);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(dtpNgayKetThuc);
            Controls.Add(lblNgayKetThuc);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(lblNgayBatDau);
            Controls.Add(txtGiaTriGiam);
            Controls.Add(lblGiaTriGiam);
            Controls.Add(cboKieuGiamGia);
            Controls.Add(lblKieuGiamGia);
            Controls.Add(txtTenVoucher);
            Controls.Add(lblTenVoucher);
            Controls.Add(txtMaGiamGia);
            Controls.Add(lblMaGiamGia);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmNhapVoucher";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin voucher";
            Load += frmNhapVoucher_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
