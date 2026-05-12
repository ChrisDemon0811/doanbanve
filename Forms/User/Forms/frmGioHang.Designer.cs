namespace doanbanve.Forms
{
    partial class frmGioHang
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlTongQuan;
        private FlowLayoutPanel pnlDanhSach;
        private Label lblTieuDe;
        private Label lblTongSoLuongText;
        private Label lblTongSoLuong;
        private Label lblTongTienText;
        private Label lblTongTien;
        private Button btnMuaHang;

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
            pnlTongQuan = new Panel();
            lblTieuDe = new Label();
            lblTongSoLuongText = new Label();
            lblTongSoLuong = new Label();
            lblTongTienText = new Label();
            lblTongTien = new Label();
            btnMuaHang = new Button();
            pnlDanhSach = new FlowLayoutPanel();
            pnlTongQuan.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTongQuan
            // 
            pnlTongQuan.BackColor = Color.White;
            pnlTongQuan.Controls.Add(btnMuaHang);
            pnlTongQuan.Controls.Add(lblTongTien);
            pnlTongQuan.Controls.Add(lblTongTienText);
            pnlTongQuan.Controls.Add(lblTongSoLuong);
            pnlTongQuan.Controls.Add(lblTongSoLuongText);
            pnlTongQuan.Controls.Add(lblTieuDe);
            pnlTongQuan.Dock = DockStyle.Bottom;
            pnlTongQuan.Location = new Point(0, 420);
            pnlTongQuan.Name = "pnlTongQuan";
            pnlTongQuan.Size = new Size(880, 80);
            pnlTongQuan.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTieuDe.Location = new Point(20, 28);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(139, 21);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tổng cộng";
            // 
            // lblTongSoLuongText
            // 
            lblTongSoLuongText.AutoSize = true;
            lblTongSoLuongText.Location = new Point(180, 32);
            lblTongSoLuongText.Name = "lblTongSoLuongText";
            lblTongSoLuongText.Size = new Size(106, 15);
            lblTongSoLuongText.TabIndex = 1;
            lblTongSoLuongText.Text = "Số lượng:";
            // 
            // lblTongSoLuong
            // 
            lblTongSoLuong.AutoSize = true;
            lblTongSoLuong.Location = new Point(290, 32);
            lblTongSoLuong.Name = "lblTongSoLuong";
            lblTongSoLuong.Size = new Size(13, 15);
            lblTongSoLuong.TabIndex = 2;
            lblTongSoLuong.Text = "0";
            // 
            // lblTongTienText
            // 
            lblTongTienText.AutoSize = true;
            lblTongTienText.Location = new Point(360, 32);
            lblTongTienText.Name = "lblTongTienText";
            lblTongTienText.Size = new Size(64, 15);
            lblTongTienText.TabIndex = 3;
            lblTongTienText.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongTien.ForeColor = Color.FromArgb(210, 85, 30);
            lblTongTien.Location = new Point(430, 28);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(56, 20);
            lblTongTien.TabIndex = 4;
            lblTongTien.Text = "0 VNĐ";
            // 
            // btnMuaHang
            // 
            btnMuaHang.BackColor = Color.FromArgb(210, 85, 30);
            btnMuaHang.ForeColor = Color.White;
            btnMuaHang.Location = new Point(720, 22);
            btnMuaHang.Name = "btnMuaHang";
            btnMuaHang.Size = new Size(130, 36);
            btnMuaHang.TabIndex = 5;
            btnMuaHang.Text = "Mua hàng";
            btnMuaHang.UseVisualStyleBackColor = false;
            btnMuaHang.Click += btnMuaHang_Click;
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.AutoScroll = true;
            pnlDanhSach.BackColor = Color.FromArgb(245, 245, 245);
            pnlDanhSach.Dock = DockStyle.Fill;
            pnlDanhSach.Location = new Point(0, 0);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Padding = new Padding(12);
            pnlDanhSach.Size = new Size(880, 420);
            pnlDanhSach.TabIndex = 1;
            // 
            // frmGioHang
            // 
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 500);
            Controls.Add(pnlDanhSach);
            Controls.Add(pnlTongQuan);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmGioHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Giỏ hàng";
            Load += frmGioHang_Load;
            pnlTongQuan.ResumeLayout(false);
            pnlTongQuan.PerformLayout();
            ResumeLayout(false);
        }
    }
}
