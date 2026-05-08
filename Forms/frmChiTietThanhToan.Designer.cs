namespace doanbanve.Forms
{
    partial class frmChiTietThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel pnlDanhSach;
        private Label lblTieuDe;
        private Panel pnlThongTin;
        private Label lblMaHoaDon;
        private Label lblNguoiDat;
        private Label lblNgayDat;
        private Label lblThanhToan;
        private Label lblGiamGia;
        private Label lblTrangThai;

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
            lblTieuDe = new Label();
            pnlThongTin = new Panel();
            lblTrangThai = new Label();
            lblGiamGia = new Label();
            lblThanhToan = new Label();
            lblNgayDat = new Label();
            lblNguoiDat = new Label();
            lblMaHoaDon = new Label();
            pnlThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.AutoScroll = true;
            pnlDanhSach.BackColor = Color.FromArgb(245, 245, 245);
            pnlDanhSach.Location = new Point(16, 170);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Padding = new Padding(12);
            pnlDanhSach.Size = new Size(668, 384);
            pnlDanhSach.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.Location = new Point(16, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(165, 25);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "Chi tiết đơn hàng";
            // 
            // pnlThongTin
            // 
            pnlThongTin.BackColor = Color.FromArgb(240, 248, 240);
            pnlThongTin.BorderStyle = BorderStyle.FixedSingle;
            pnlThongTin.Controls.Add(lblTrangThai);
            pnlThongTin.Controls.Add(lblGiamGia);
            pnlThongTin.Controls.Add(lblThanhToan);
            pnlThongTin.Controls.Add(lblNgayDat);
            pnlThongTin.Controls.Add(lblNguoiDat);
            pnlThongTin.Controls.Add(lblMaHoaDon);
            pnlThongTin.Location = new Point(16, 44);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(668, 110);
            pnlThongTin.TabIndex = 2;
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Location = new Point(320, 56);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(78, 20);
            lblTrangThai.TabIndex = 5;
            lblTrangThai.Text = "Trạng thái:";
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.Location = new Point(320, 34);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(72, 20);
            lblGiamGia.TabIndex = 4;
            lblGiamGia.Text = "Giảm giá:";
            // 
            // lblThanhToan
            // 
            lblThanhToan.AutoSize = true;
            lblThanhToan.Location = new Point(320, 12);
            lblThanhToan.Name = "lblThanhToan";
            lblThanhToan.Size = new Size(151, 20);
            lblThanhToan.TabIndex = 3;
            lblThanhToan.Text = "Hình thức thanh toán:";
            // 
            // lblNgayDat
            // 
            lblNgayDat.AutoSize = true;
            lblNgayDat.Location = new Point(12, 56);
            lblNgayDat.Name = "lblNgayDat";
            lblNgayDat.Size = new Size(73, 20);
            lblNgayDat.TabIndex = 2;
            lblNgayDat.Text = "Ngày đặt:";
            // 
            // lblNguoiDat
            // 
            lblNguoiDat.AutoSize = true;
            lblNguoiDat.Location = new Point(12, 34);
            lblNguoiDat.Name = "lblNguoiDat";
            lblNguoiDat.Size = new Size(80, 20);
            lblNguoiDat.TabIndex = 1;
            lblNguoiDat.Text = "Người đặt:";
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new Point(12, 12);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(92, 20);
            lblMaHoaDon.TabIndex = 0;
            lblMaHoaDon.Text = "Mã hóa đơn:";
            // 
            // frmChiTietThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 566);
            Controls.Add(pnlThongTin);
            Controls.Add(lblTieuDe);
            Controls.Add(pnlDanhSach);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmChiTietThanhToan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết thanh toán";
            Load += frmChiTietThanhToan_Load;
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
