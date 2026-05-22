namespace doanbanve.Forms
{
    partial class frmChonVe
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTenVe;
        private Label lblNgaySuDung;
        private DateTimePicker dtpNgaySuDung;
        private GroupBox grpSoLuong;
        private Label lblNguoiLon;
        private Label lblTreEm;
        private Label lblNguoiCaoTuoi;
        private NumericUpDown nudNguoiLon;
        private NumericUpDown nudTreEm;
        private NumericUpDown nudNguoiCaoTuoi;
        private Button btnCongNguoiLon;
        private Button btnTruNguoiLon;
        private Button btnCongTreEm;
        private Button btnTruTreEm;
        private Button btnCongNguoiCaoTuoi;
        private Button btnTruNguoiCaoTuoi;
        private Label lblGiaNguoiLon;
        private Label lblGiaTreEm;
        private Label lblGiaNguoiCaoTuoi;
        private Label lblTongTien;
        private Button btnThemGioHang;
        private Button btnDatNgay;

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
            lblTenVe = new Label();
            lblNgaySuDung = new Label();
            dtpNgaySuDung = new DateTimePicker();
            grpSoLuong = new GroupBox();
            lblGiaNguoiCaoTuoi = new Label();
            lblGiaTreEm = new Label();
            lblGiaNguoiLon = new Label();
            btnTruNguoiCaoTuoi = new Button();
            btnCongNguoiCaoTuoi = new Button();
            btnTruTreEm = new Button();
            btnCongTreEm = new Button();
            btnTruNguoiLon = new Button();
            btnCongNguoiLon = new Button();
            nudNguoiCaoTuoi = new NumericUpDown();
            nudTreEm = new NumericUpDown();
            nudNguoiLon = new NumericUpDown();
            lblNguoiCaoTuoi = new Label();
            lblTreEm = new Label();
            lblNguoiLon = new Label();
            lblTongTien = new Label();
            btnThemGioHang = new Button();
            btnDatNgay = new Button();
            grpSoLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNguoiCaoTuoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTreEm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNguoiLon).BeginInit();
            SuspendLayout();
            // 
            // lblTenVe
            // 
            lblTenVe.AutoSize = true;
            lblTenVe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTenVe.Location = new Point(24, 20);
            lblTenVe.Name = "lblTenVe";
            lblTenVe.Size = new Size(87, 32);
            lblTenVe.TabIndex = 0;
            lblTenVe.Text = "Tên vé";
            // 
            // lblNgaySuDung
            // 
            lblNgaySuDung.AutoSize = true;
            lblNgaySuDung.Location = new Point(24, 64);
            lblNgaySuDung.Name = "lblNgaySuDung";
            lblNgaySuDung.Size = new Size(82, 20);
            lblNgaySuDung.TabIndex = 1;
            lblNgaySuDung.Text = "Chọn ngày:";
            // 
            // dtpNgaySuDung
            // 
            dtpNgaySuDung.Location = new Point(132, 60);
            dtpNgaySuDung.Name = "dtpNgaySuDung";
            dtpNgaySuDung.Size = new Size(227, 27);
            dtpNgaySuDung.TabIndex = 2;
            // 
            // grpSoLuong
            // 
            grpSoLuong.Controls.Add(lblGiaNguoiCaoTuoi);
            grpSoLuong.Controls.Add(lblGiaTreEm);
            grpSoLuong.Controls.Add(lblGiaNguoiLon);
            grpSoLuong.Controls.Add(btnTruNguoiCaoTuoi);
            grpSoLuong.Controls.Add(btnCongNguoiCaoTuoi);
            grpSoLuong.Controls.Add(btnTruTreEm);
            grpSoLuong.Controls.Add(btnCongTreEm);
            grpSoLuong.Controls.Add(btnTruNguoiLon);
            grpSoLuong.Controls.Add(btnCongNguoiLon);
            grpSoLuong.Controls.Add(nudNguoiCaoTuoi);
            grpSoLuong.Controls.Add(nudTreEm);
            grpSoLuong.Controls.Add(nudNguoiLon);
            grpSoLuong.Controls.Add(lblNguoiCaoTuoi);
            grpSoLuong.Controls.Add(lblTreEm);
            grpSoLuong.Controls.Add(lblNguoiLon);
            grpSoLuong.Location = new Point(24, 100);
            grpSoLuong.Name = "grpSoLuong";
            grpSoLuong.Size = new Size(813, 160);
            grpSoLuong.TabIndex = 3;
            grpSoLuong.TabStop = false;
            grpSoLuong.Text = "Số lượng mua";
            // 
            // lblGiaNguoiCaoTuoi
            // 
            lblGiaNguoiCaoTuoi.AutoSize = true;
            lblGiaNguoiCaoTuoi.Location = new Point(665, 114);
            lblGiaNguoiCaoTuoi.Name = "lblGiaNguoiCaoTuoi";
            lblGiaNguoiCaoTuoi.Size = new Size(52, 20);
            lblGiaNguoiCaoTuoi.TabIndex = 14;
            lblGiaNguoiCaoTuoi.Text = "0 VNĐ";
            // 
            // lblGiaTreEm
            // 
            lblGiaTreEm.AutoSize = true;
            lblGiaTreEm.Location = new Point(665, 74);
            lblGiaTreEm.Name = "lblGiaTreEm";
            lblGiaTreEm.Size = new Size(52, 20);
            lblGiaTreEm.TabIndex = 13;
            lblGiaTreEm.Text = "0 VNĐ";
            // 
            // lblGiaNguoiLon
            // 
            lblGiaNguoiLon.AutoSize = true;
            lblGiaNguoiLon.Location = new Point(665, 34);
            lblGiaNguoiLon.Name = "lblGiaNguoiLon";
            lblGiaNguoiLon.Size = new Size(52, 20);
            lblGiaNguoiLon.TabIndex = 12;
            lblGiaNguoiLon.Text = "0 VNĐ";
            // 
            // btnTruNguoiCaoTuoi
            // 
            btnTruNguoiCaoTuoi.Location = new Point(617, 108);
            btnTruNguoiCaoTuoi.Name = "btnTruNguoiCaoTuoi";
            btnTruNguoiCaoTuoi.Size = new Size(32, 26);
            btnTruNguoiCaoTuoi.TabIndex = 11;
            btnTruNguoiCaoTuoi.Text = "-";
            btnTruNguoiCaoTuoi.UseVisualStyleBackColor = true;
            btnTruNguoiCaoTuoi.Click += btnTruNguoiCaoTuoi_Click;
            // 
            // btnCongNguoiCaoTuoi
            // 
            btnCongNguoiCaoTuoi.Location = new Point(577, 108);
            btnCongNguoiCaoTuoi.Name = "btnCongNguoiCaoTuoi";
            btnCongNguoiCaoTuoi.Size = new Size(32, 26);
            btnCongNguoiCaoTuoi.TabIndex = 10;
            btnCongNguoiCaoTuoi.Text = "+";
            btnCongNguoiCaoTuoi.UseVisualStyleBackColor = true;
            btnCongNguoiCaoTuoi.Click += btnCongNguoiCaoTuoi_Click;
            // 
            // btnTruTreEm
            // 
            btnTruTreEm.Location = new Point(617, 68);
            btnTruTreEm.Name = "btnTruTreEm";
            btnTruTreEm.Size = new Size(32, 26);
            btnTruTreEm.TabIndex = 9;
            btnTruTreEm.Text = "-";
            btnTruTreEm.UseVisualStyleBackColor = true;
            btnTruTreEm.Click += btnTruTreEm_Click;
            // 
            // btnCongTreEm
            // 
            btnCongTreEm.Location = new Point(577, 68);
            btnCongTreEm.Name = "btnCongTreEm";
            btnCongTreEm.Size = new Size(32, 26);
            btnCongTreEm.TabIndex = 8;
            btnCongTreEm.Text = "+";
            btnCongTreEm.UseVisualStyleBackColor = true;
            btnCongTreEm.Click += btnCongTreEm_Click;
            // 
            // btnTruNguoiLon
            // 
            btnTruNguoiLon.Location = new Point(617, 28);
            btnTruNguoiLon.Name = "btnTruNguoiLon";
            btnTruNguoiLon.Size = new Size(32, 26);
            btnTruNguoiLon.TabIndex = 7;
            btnTruNguoiLon.Text = "-";
            btnTruNguoiLon.UseVisualStyleBackColor = true;
            btnTruNguoiLon.Click += btnTruNguoiLon_Click;
            // 
            // btnCongNguoiLon
            // 
            btnCongNguoiLon.Location = new Point(577, 28);
            btnCongNguoiLon.Name = "btnCongNguoiLon";
            btnCongNguoiLon.Size = new Size(32, 26);
            btnCongNguoiLon.TabIndex = 6;
            btnCongNguoiLon.Text = "+";
            btnCongNguoiLon.UseVisualStyleBackColor = true;
            btnCongNguoiLon.Click += btnCongNguoiLon_Click;
            // 
            // nudNguoiCaoTuoi
            // 
            nudNguoiCaoTuoi.Location = new Point(505, 110);
            nudNguoiCaoTuoi.Name = "nudNguoiCaoTuoi";
            nudNguoiCaoTuoi.Size = new Size(60, 27);
            nudNguoiCaoTuoi.TabIndex = 5;
            nudNguoiCaoTuoi.ValueChanged += nudNguoiCaoTuoi_ValueChanged;
            // 
            // nudTreEm
            // 
            nudTreEm.Location = new Point(505, 70);
            nudTreEm.Name = "nudTreEm";
            nudTreEm.Size = new Size(60, 27);
            nudTreEm.TabIndex = 4;
            nudTreEm.ValueChanged += nudTreEm_ValueChanged;
            // 
            // nudNguoiLon
            // 
            nudNguoiLon.Location = new Point(505, 30);
            nudNguoiLon.Name = "nudNguoiLon";
            nudNguoiLon.Size = new Size(60, 27);
            nudNguoiLon.TabIndex = 3;
            nudNguoiLon.ValueChanged += nudNguoiLon_ValueChanged;
            // 
            // lblNguoiCaoTuoi
            // 
            lblNguoiCaoTuoi.AutoSize = true;
            lblNguoiCaoTuoi.Location = new Point(16, 112);
            lblNguoiCaoTuoi.Name = "lblNguoiCaoTuoi";
            lblNguoiCaoTuoi.Size = new Size(109, 20);
            lblNguoiCaoTuoi.TabIndex = 2;
            lblNguoiCaoTuoi.Text = "Người cao tuổi";
            // 
            // lblTreEm
            // 
            lblTreEm.AutoSize = true;
            lblTreEm.Location = new Point(16, 72);
            lblTreEm.Name = "lblTreEm";
            lblTreEm.Size = new Size(54, 20);
            lblTreEm.TabIndex = 1;
            lblTreEm.Text = "Trẻ em";
            // 
            // lblNguoiLon
            // 
            lblNguoiLon.AutoSize = true;
            lblNguoiLon.Location = new Point(16, 32);
            lblNguoiLon.Name = "lblNguoiLon";
            lblNguoiLon.Size = new Size(76, 20);
            lblNguoiLon.TabIndex = 0;
            lblNguoiLon.Text = "Người lớn";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.Location = new Point(24, 276);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(74, 28);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "0 VNĐ";
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.Location = new Point(536, 328);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(120, 32);
            btnThemGioHang.TabIndex = 5;
            btnThemGioHang.Text = "Thêm giỏ hàng";
            btnThemGioHang.UseVisualStyleBackColor = true;
            btnThemGioHang.Click += btnThemGioHang_Click;
            // 
            // btnDatNgay
            // 
            btnDatNgay.Location = new Point(672, 328);
            btnDatNgay.Name = "btnDatNgay";
            btnDatNgay.Size = new Size(120, 32);
            btnDatNgay.TabIndex = 6;
            btnDatNgay.Text = "Đặt ngay";
            btnDatNgay.UseVisualStyleBackColor = true;
            btnDatNgay.Click += btnDatNgay_Click;
            // 
            // frmChonVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 430);
            Controls.Add(btnDatNgay);
            Controls.Add(btnThemGioHang);
            Controls.Add(lblTongTien);
            Controls.Add(grpSoLuong);
            Controls.Add(dtpNgaySuDung);
            Controls.Add(lblNgaySuDung);
            Controls.Add(lblTenVe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmChonVe";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn vé";
            Load += frmChonVe_Load;
            grpSoLuong.ResumeLayout(false);
            grpSoLuong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNguoiCaoTuoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTreEm).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNguoiLon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
