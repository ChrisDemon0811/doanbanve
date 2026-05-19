namespace doanbanve.Forms
{
    partial class ucPhanLoaiVe
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachLoaiVe;
        private Button btnThemLoaiVe;
        private Button btnSuaLoaiVe;
        private Button btnXoaLoaiVe;

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
            flpDanhSachLoaiVe = new FlowLayoutPanel();
            btnThemLoaiVe = new Button();
            btnSuaLoaiVe = new Button();
            btnXoaLoaiVe = new Button();
            SuspendLayout();
            // 
            // flpDanhSachLoaiVe
            // 
            flpDanhSachLoaiVe.AutoScroll = true;
            flpDanhSachLoaiVe.FlowDirection = FlowDirection.TopDown;
            flpDanhSachLoaiVe.Location = new Point(0, 0);
            flpDanhSachLoaiVe.Name = "flpDanhSachLoaiVe";
            flpDanhSachLoaiVe.Padding = new Padding(8);
            flpDanhSachLoaiVe.Size = new Size(968, 540);
            flpDanhSachLoaiVe.TabIndex = 0;
            flpDanhSachLoaiVe.WrapContents = false;
            // 
            // btnThemLoaiVe
            // 
            btnThemLoaiVe.Location = new Point(6, 564);
            btnThemLoaiVe.Name = "btnThemLoaiVe";
            btnThemLoaiVe.Size = new Size(90, 28);
            btnThemLoaiVe.TabIndex = 1;
            btnThemLoaiVe.Text = "Thêm";
            btnThemLoaiVe.UseVisualStyleBackColor = true;
            btnThemLoaiVe.Click += btnThemLoaiVe_Click;
            // 
            // btnSuaLoaiVe
            // 
            btnSuaLoaiVe.Location = new Point(106, 564);
            btnSuaLoaiVe.Name = "btnSuaLoaiVe";
            btnSuaLoaiVe.Size = new Size(90, 28);
            btnSuaLoaiVe.TabIndex = 2;
            btnSuaLoaiVe.Text = "Sửa";
            btnSuaLoaiVe.UseVisualStyleBackColor = true;
            btnSuaLoaiVe.Click += btnSuaLoaiVe_Click;
            // 
            // btnXoaLoaiVe
            // 
            btnXoaLoaiVe.Location = new Point(206, 564);
            btnXoaLoaiVe.Name = "btnXoaLoaiVe";
            btnXoaLoaiVe.Size = new Size(90, 28);
            btnXoaLoaiVe.TabIndex = 3;
            btnXoaLoaiVe.Text = "Xóa";
            btnXoaLoaiVe.UseVisualStyleBackColor = true;
            btnXoaLoaiVe.Click += btnXoaLoaiVe_Click;
            // 
            // ucPhanLoaiVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaLoaiVe);
            Controls.Add(btnSuaLoaiVe);
            Controls.Add(btnThemLoaiVe);
            Controls.Add(flpDanhSachLoaiVe);
            Name = "ucPhanLoaiVe";
            Size = new Size(968, 608);
            ResumeLayout(false);
        }
    }
}
