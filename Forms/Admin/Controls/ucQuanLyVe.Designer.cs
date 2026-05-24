namespace doanbanve.Forms
{
    partial class ucQuanLyVe
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flpDanhSachVe;
        private Button btnThemVe;
        private Button btnSuaVe;
        private Button btnXoaVe;
        private Button btnLamMoiVe;
        private Label lblTimKiemVe;
        private TextBox txtTimKiemVe;
        private Button btnXoaLocVe;

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
            flpDanhSachVe = new FlowLayoutPanel();
            btnThemVe = new Button();
            btnSuaVe = new Button();
            btnXoaVe = new Button();
            btnLamMoiVe = new Button();
            lblTimKiemVe = new Label();
            txtTimKiemVe = new TextBox();
            btnXoaLocVe = new Button();
            SuspendLayout();
            // 
            // flpDanhSachVe
            // 
            flpDanhSachVe.AutoScroll = true;
            flpDanhSachVe.FlowDirection = FlowDirection.TopDown;
            flpDanhSachVe.Location = new Point(0, 44);
            flpDanhSachVe.Name = "flpDanhSachVe";
            flpDanhSachVe.Padding = new Padding(8);
            flpDanhSachVe.Size = new Size(968, 496);
            flpDanhSachVe.TabIndex = 0;
            flpDanhSachVe.WrapContents = false;
            // 
            // btnThemVe
            // 
            btnThemVe.Location = new Point(2, 564);
            btnThemVe.Name = "btnThemVe";
            btnThemVe.Size = new Size(90, 28);
            btnThemVe.TabIndex = 1;
            btnThemVe.Text = "Thêm";
            btnThemVe.UseVisualStyleBackColor = true;
            btnThemVe.Click += btnThemVe_Click;
            // 
            // btnSuaVe
            // 
            btnSuaVe.Location = new Point(102, 564);
            btnSuaVe.Name = "btnSuaVe";
            btnSuaVe.Size = new Size(90, 28);
            btnSuaVe.TabIndex = 2;
            btnSuaVe.Text = "Sửa";
            btnSuaVe.UseVisualStyleBackColor = true;
            btnSuaVe.Click += btnSuaVe_Click;
            // 
            // btnXoaVe
            // 
            btnXoaVe.Location = new Point(202, 564);
            btnXoaVe.Name = "btnXoaVe";
            btnXoaVe.Size = new Size(90, 28);
            btnXoaVe.TabIndex = 3;
            btnXoaVe.Text = "Xóa";
            btnXoaVe.UseVisualStyleBackColor = true;
            btnXoaVe.Click += btnXoaVe_Click;
            // 
            // btnLamMoiVe
            // 
            btnLamMoiVe.Location = new Point(302, 564);
            btnLamMoiVe.Name = "btnLamMoiVe";
            btnLamMoiVe.Size = new Size(90, 28);
            btnLamMoiVe.TabIndex = 4;
            btnLamMoiVe.Text = "Làm mới";
            btnLamMoiVe.UseVisualStyleBackColor = true;
            btnLamMoiVe.Click += btnLamMoiVe_Click;
            // 
            // lblTimKiemVe
            // 
            lblTimKiemVe.AutoSize = true;
            lblTimKiemVe.Location = new Point(0, 12);
            lblTimKiemVe.Name = "lblTimKiemVe";
            lblTimKiemVe.Size = new Size(73, 20);
            lblTimKiemVe.TabIndex = 5;
            lblTimKiemVe.Text = "Tìm kiếm:";
            // 
            // txtTimKiemVe
            // 
            txtTimKiemVe.Location = new Point(74, 8);
            txtTimKiemVe.Name = "txtTimKiemVe";
            txtTimKiemVe.Size = new Size(300, 27);
            txtTimKiemVe.TabIndex = 6;
            txtTimKiemVe.TextChanged += txtTimKiemVe_TextChanged;
            // 
            // btnXoaLocVe
            // 
            btnXoaLocVe.Location = new Point(382, 8);
            btnXoaLocVe.Name = "btnXoaLocVe";
            btnXoaLocVe.Size = new Size(96, 27);
            btnXoaLocVe.TabIndex = 7;
            btnXoaLocVe.Text = "Xóa lọc";
            btnXoaLocVe.UseVisualStyleBackColor = true;
            btnXoaLocVe.Click += btnXoaLocVe_Click;
            // 
            // ucQuanLyVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnXoaLocVe);
            Controls.Add(txtTimKiemVe);
            Controls.Add(lblTimKiemVe);
            Controls.Add(btnLamMoiVe);
            Controls.Add(btnXoaVe);
            Controls.Add(btnSuaVe);
            Controls.Add(btnThemVe);
            Controls.Add(flpDanhSachVe);
            Name = "ucQuanLyVe";
            Size = new Size(968, 608);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
