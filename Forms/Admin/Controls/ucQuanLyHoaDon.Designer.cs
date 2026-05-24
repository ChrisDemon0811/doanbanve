namespace doanbanve.Forms
{
    partial class ucQuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachHoaDon;
        private Button btnChiTietHoaDon;
        private Label lblTimKiemHoaDon;
        private TextBox txtTimKiemHoaDon;
        private Button btnXoaLocHoaDon;

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
            flpDanhSachHoaDon = new FlowLayoutPanel();
            btnChiTietHoaDon = new Button();
            lblTimKiemHoaDon = new Label();
            txtTimKiemHoaDon = new TextBox();
            btnXoaLocHoaDon = new Button();
            SuspendLayout();
            // 
            // flpDanhSachHoaDon
            // 
            flpDanhSachHoaDon.AutoScroll = true;
            flpDanhSachHoaDon.FlowDirection = FlowDirection.TopDown;
            flpDanhSachHoaDon.Location = new Point(0, 44);
            flpDanhSachHoaDon.Name = "flpDanhSachHoaDon";
            flpDanhSachHoaDon.Padding = new Padding(8);
            flpDanhSachHoaDon.Size = new Size(968, 488);
            flpDanhSachHoaDon.TabIndex = 0;
            flpDanhSachHoaDon.WrapContents = false;
            // 
            // btnChiTietHoaDon
            // 
            btnChiTietHoaDon.Location = new Point(0, 558);
            btnChiTietHoaDon.Name = "btnChiTietHoaDon";
            btnChiTietHoaDon.Size = new Size(140, 28);
            btnChiTietHoaDon.TabIndex = 1;
            btnChiTietHoaDon.Text = "Chi tiết hóa đơn";
            btnChiTietHoaDon.UseVisualStyleBackColor = true;
            btnChiTietHoaDon.Click += btnChiTietHoaDon_Click;
            // 
            // lblTimKiemHoaDon
            // 
            lblTimKiemHoaDon.AutoSize = true;
            lblTimKiemHoaDon.Location = new Point(0, 12);
            lblTimKiemHoaDon.Name = "lblTimKiemHoaDon";
            lblTimKiemHoaDon.Size = new Size(73, 20);
            lblTimKiemHoaDon.TabIndex = 2;
            lblTimKiemHoaDon.Text = "Tìm kiếm:";
            // 
            // txtTimKiemHoaDon
            // 
            txtTimKiemHoaDon.Location = new Point(74, 8);
            txtTimKiemHoaDon.Name = "txtTimKiemHoaDon";
            txtTimKiemHoaDon.Size = new Size(300, 27);
            txtTimKiemHoaDon.TabIndex = 3;
            txtTimKiemHoaDon.TextChanged += txtTimKiemHoaDon_TextChanged;
            // 
            // btnXoaLocHoaDon
            // 
            btnXoaLocHoaDon.Location = new Point(382, 8);
            btnXoaLocHoaDon.Name = "btnXoaLocHoaDon";
            btnXoaLocHoaDon.Size = new Size(96, 27);
            btnXoaLocHoaDon.TabIndex = 4;
            btnXoaLocHoaDon.Text = "Xóa lọc";
            btnXoaLocHoaDon.UseVisualStyleBackColor = true;
            btnXoaLocHoaDon.Click += btnXoaLocHoaDon_Click;
            // 
            // ucQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaLocHoaDon);
            Controls.Add(txtTimKiemHoaDon);
            Controls.Add(lblTimKiemHoaDon);
            Controls.Add(btnChiTietHoaDon);
            Controls.Add(flpDanhSachHoaDon);
            Name = "ucQuanLyHoaDon";
            Size = new Size(968, 608);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
