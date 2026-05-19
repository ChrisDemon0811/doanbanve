namespace doanbanve.Forms
{
    partial class ucQuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachHoaDon;
        private Button btnChiTietHoaDon;

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
            SuspendLayout();
            // 
            // flpDanhSachHoaDon
            // 
            flpDanhSachHoaDon.AutoScroll = true;
            flpDanhSachHoaDon.FlowDirection = FlowDirection.TopDown;
            flpDanhSachHoaDon.Location = new Point(0, 0);
            flpDanhSachHoaDon.Name = "flpDanhSachHoaDon";
            flpDanhSachHoaDon.Padding = new Padding(8);
            flpDanhSachHoaDon.Size = new Size(968, 532);
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
            // ucQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnChiTietHoaDon);
            Controls.Add(flpDanhSachHoaDon);
            Name = "ucQuanLyHoaDon";
            Size = new Size(968, 608);
            ResumeLayout(false);
        }
    }
}
