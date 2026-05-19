namespace doanbanve.Forms
{
    partial class ucQuanLyVoucher
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachVoucher;
        private Button btnThemVoucher;
        private Button btnSuaVoucher;
        private Button btnXoaVoucher;

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
            flpDanhSachVoucher = new FlowLayoutPanel();
            btnThemVoucher = new Button();
            btnSuaVoucher = new Button();
            btnXoaVoucher = new Button();
            SuspendLayout();
            // 
            // flpDanhSachVoucher
            // 
            flpDanhSachVoucher.AutoScroll = true;
            flpDanhSachVoucher.FlowDirection = FlowDirection.TopDown;
            flpDanhSachVoucher.Location = new Point(0, 0);
            flpDanhSachVoucher.Name = "flpDanhSachVoucher";
            flpDanhSachVoucher.Padding = new Padding(8);
            flpDanhSachVoucher.Size = new Size(968, 533);
            flpDanhSachVoucher.TabIndex = 0;
            flpDanhSachVoucher.WrapContents = false;
            // 
            // btnThemVoucher
            // 
            btnThemVoucher.Location = new Point(3, 560);
            btnThemVoucher.Name = "btnThemVoucher";
            btnThemVoucher.Size = new Size(90, 28);
            btnThemVoucher.TabIndex = 1;
            btnThemVoucher.Text = "Thêm";
            btnThemVoucher.UseVisualStyleBackColor = true;
            btnThemVoucher.Click += btnThemVoucher_Click;
            // 
            // btnSuaVoucher
            // 
            btnSuaVoucher.Location = new Point(103, 560);
            btnSuaVoucher.Name = "btnSuaVoucher";
            btnSuaVoucher.Size = new Size(90, 28);
            btnSuaVoucher.TabIndex = 2;
            btnSuaVoucher.Text = "Sửa";
            btnSuaVoucher.UseVisualStyleBackColor = true;
            btnSuaVoucher.Click += btnSuaVoucher_Click;
            // 
            // btnXoaVoucher
            // 
            btnXoaVoucher.Location = new Point(203, 560);
            btnXoaVoucher.Name = "btnXoaVoucher";
            btnXoaVoucher.Size = new Size(90, 28);
            btnXoaVoucher.TabIndex = 3;
            btnXoaVoucher.Text = "Xóa";
            btnXoaVoucher.UseVisualStyleBackColor = true;
            btnXoaVoucher.Click += btnXoaVoucher_Click;
            // 
            // ucQuanLyVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaVoucher);
            Controls.Add(btnSuaVoucher);
            Controls.Add(btnThemVoucher);
            Controls.Add(flpDanhSachVoucher);
            Name = "ucQuanLyVoucher";
            Size = new Size(968, 608);
            ResumeLayout(false);
        }
    }
}
