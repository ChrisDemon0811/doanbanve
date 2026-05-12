namespace doanbanve.Forms
{
    partial class frmThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel pnlDanhSach;
        private Label lblNguoiDatText;
        private Label lblNguoiDat;
        private Label lblNgayDatText;
        private Label lblNgayDat;
        private Label lblVoucherText;
        private TextBox txtMaVoucher;
        private Button btnApDungVoucher;
        private Label lblTienGiamText;
        private Label lblTienGiam;
        private Label lblTongTienText;
        private Label lblTongTien;
        private Label lblThanhTienText;
        private Label lblThanhTien;
        private ComboBox cboThanhToan;
        private Label lblThanhToanText;
        private Button btnThanhToan;

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
            pnlDanhSach = new FlowLayoutPanel();
            lblNguoiDatText = new Label();
            lblNguoiDat = new Label();
            lblNgayDatText = new Label();
            lblNgayDat = new Label();
            lblVoucherText = new Label();
            txtMaVoucher = new TextBox();
            btnApDungVoucher = new Button();
            lblTienGiamText = new Label();
            lblTienGiam = new Label();
            lblTongTienText = new Label();
            lblTongTien = new Label();
            lblThanhTienText = new Label();
            lblThanhTien = new Label();
            cboThanhToan = new ComboBox();
            lblThanhToanText = new Label();
            btnThanhToan = new Button();
            SuspendLayout();
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.AutoScroll = true;
            pnlDanhSach.BackColor = Color.FromArgb(245, 245, 245);
            pnlDanhSach.Location = new Point(24, 24);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Padding = new Padding(12);
            pnlDanhSach.Size = new Size(760, 303);
            pnlDanhSach.TabIndex = 0;
            // 
            // lblNguoiDatText
            // 
            lblNguoiDatText.AutoSize = true;
            lblNguoiDatText.Location = new Point(24, 330);
            lblNguoiDatText.Name = "lblNguoiDatText";
            lblNguoiDatText.Size = new Size(80, 20);
            lblNguoiDatText.TabIndex = 1;
            lblNguoiDatText.Text = "Người đặt:";
            // 
            // lblNguoiDat
            // 
            lblNguoiDat.AutoSize = true;
            lblNguoiDat.Location = new Point(100, 330);
            lblNguoiDat.Name = "lblNguoiDat";
            lblNguoiDat.Size = new Size(15, 20);
            lblNguoiDat.TabIndex = 2;
            lblNguoiDat.Text = "-";
            // 
            // lblNgayDatText
            // 
            lblNgayDatText.AutoSize = true;
            lblNgayDatText.Location = new Point(24, 356);
            lblNgayDatText.Name = "lblNgayDatText";
            lblNgayDatText.Size = new Size(73, 20);
            lblNgayDatText.TabIndex = 3;
            lblNgayDatText.Text = "Ngày đặt:";
            // 
            // lblNgayDat
            // 
            lblNgayDat.AutoSize = true;
            lblNgayDat.Location = new Point(100, 356);
            lblNgayDat.Name = "lblNgayDat";
            lblNgayDat.Size = new Size(15, 20);
            lblNgayDat.TabIndex = 4;
            lblNgayDat.Text = "-";
            // 
            // lblVoucherText
            // 
            lblVoucherText.AutoSize = true;
            lblVoucherText.Location = new Point(24, 390);
            lblVoucherText.Name = "lblVoucherText";
            lblVoucherText.Size = new Size(89, 20);
            lblVoucherText.TabIndex = 5;
            lblVoucherText.Text = "Mã voucher:";
            // 
            // txtMaVoucher
            // 
            txtMaVoucher.Location = new Point(110, 386);
            txtMaVoucher.Name = "txtMaVoucher";
            txtMaVoucher.Size = new Size(180, 27);
            txtMaVoucher.TabIndex = 6;
            // 
            // btnApDungVoucher
            // 
            btnApDungVoucher.Location = new Point(300, 384);
            btnApDungVoucher.Name = "btnApDungVoucher";
            btnApDungVoucher.Size = new Size(96, 26);
            btnApDungVoucher.TabIndex = 7;
            btnApDungVoucher.Text = "Áp dụng";
            btnApDungVoucher.UseVisualStyleBackColor = true;
            btnApDungVoucher.Click += btnApDungVoucher_Click;
            // 
            // lblTienGiamText
            // 
            lblTienGiamText.AutoSize = true;
            lblTienGiamText.Location = new Point(24, 422);
            lblTienGiamText.Name = "lblTienGiamText";
            lblTienGiamText.Size = new Size(72, 20);
            lblTienGiamText.TabIndex = 8;
            lblTienGiamText.Text = "Giảm giá:";
            // 
            // lblTienGiam
            // 
            lblTienGiam.AutoSize = true;
            lblTienGiam.Location = new Point(110, 422);
            lblTienGiam.Name = "lblTienGiam";
            lblTienGiam.Size = new Size(52, 20);
            lblTienGiam.TabIndex = 9;
            lblTienGiam.Text = "0 VNĐ";
            // 
            // lblTongTienText
            // 
            lblTongTienText.AutoSize = true;
            lblTongTienText.Location = new Point(24, 448);
            lblTongTienText.Name = "lblTongTienText";
            lblTongTienText.Size = new Size(75, 20);
            lblTongTienText.TabIndex = 10;
            lblTongTienText.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(110, 448);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(52, 20);
            lblTongTien.TabIndex = 11;
            lblTongTien.Text = "0 VNĐ";
            // 
            // lblThanhTienText
            // 
            lblThanhTienText.AutoSize = true;
            lblThanhTienText.Location = new Point(24, 474);
            lblThanhTienText.Name = "lblThanhTienText";
            lblThanhTienText.Size = new Size(81, 20);
            lblThanhTienText.TabIndex = 12;
            lblThanhTienText.Text = "Thành tiền:";
            // 
            // lblThanhTien
            // 
            lblThanhTien.AutoSize = true;
            lblThanhTien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblThanhTien.ForeColor = Color.FromArgb(210, 85, 30);
            lblThanhTien.Location = new Point(110, 472);
            lblThanhTien.Name = "lblThanhTien";
            lblThanhTien.Size = new Size(62, 23);
            lblThanhTien.TabIndex = 13;
            lblThanhTien.Text = "0 VNĐ";
            // 
            // cboThanhToan
            // 
            cboThanhToan.DropDownStyle = ComboBoxStyle.DropDownList;
            cboThanhToan.FormattingEnabled = true;
            cboThanhToan.Items.AddRange(new object[] { "Thẻ ngân hàng", "Thẻ tín dụng/Ghi nợ quốc tế", "Ví điện tử" });
            cboThanhToan.Location = new Point(420, 352);
            cboThanhToan.Name = "cboThanhToan";
            cboThanhToan.Size = new Size(260, 28);
            cboThanhToan.TabIndex = 15;
            // 
            // lblThanhToanText
            // 
            lblThanhToanText.AutoSize = true;
            lblThanhToanText.Location = new Point(420, 330);
            lblThanhToanText.Name = "lblThanhToanText";
            lblThanhToanText.Size = new Size(171, 20);
            lblThanhToanText.TabIndex = 14;
            lblThanhToanText.Text = "Phương thức thanh toán:";
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.FromArgb(210, 85, 30);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(420, 398);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(160, 36);
            btnThanhToan.TabIndex = 16;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 510);
            Controls.Add(btnThanhToan);
            Controls.Add(cboThanhToan);
            Controls.Add(lblThanhToanText);
            Controls.Add(lblThanhTien);
            Controls.Add(lblThanhTienText);
            Controls.Add(lblTongTien);
            Controls.Add(lblTongTienText);
            Controls.Add(lblTienGiam);
            Controls.Add(lblTienGiamText);
            Controls.Add(btnApDungVoucher);
            Controls.Add(txtMaVoucher);
            Controls.Add(lblVoucherText);
            Controls.Add(lblNgayDat);
            Controls.Add(lblNgayDatText);
            Controls.Add(lblNguoiDat);
            Controls.Add(lblNguoiDatText);
            Controls.Add(pnlDanhSach);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmThanhToan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thanh toán";
            Load += frmThanhToan_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
