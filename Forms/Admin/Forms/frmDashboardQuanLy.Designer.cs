namespace doanbanve.Forms
{
    partial class frmDashboardQuanLy
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMenu;
        private Button btnMenuNguoiDung;
        private Button btnMenuVe;
        private Button btnMenuLoaiVe;
        private Button btnMenuVoucher;
        private Button btnMenuHoaDon;
        private Button btnMenuThongKe;
        private Panel pnlNoiDung;
        private ucQuanLyNguoiDung ucNguoiDung;
        private ucQuanLyVe ucQuanLyVe;
        private ucPhanLoaiVe ucPhanLoaiVe;
        private ucQuanLyVoucher ucQuanLyVoucher;
        private ucQuanLyHoaDon ucQuanLyHoaDon;
        private Panel pnlThongKe;
        private Panel pnlBoLocThongKe;
        private ComboBox cboLoaiThongKe;
        private Label lblLoaiThongKe;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Button btnApDungThongKe;
        private Label lblThongKeTongHoaDon;
        private Label lblThongKeTongTien;
        private Label lblThongKeTongGiam;
        private Label lblThongKeThanhTien;
        private Label lblThongKeTongVe;
        private Label lblThongKeTrungBinhHoaDon;
        private Label lblThongKeLoaiVeBanChay;
        private DataGridView dgvThongKeLoaiVe;
        private Panel pnlBieuDo;
        private DataGridView dgvHoaDon;
        private Button btnChiTietHoaDon;
        private DataGridView dgvVoucher;
        private Button btnThemVoucher;
        private Button btnSuaVoucher;
        private Button btnXoaVoucher;
        private Button btnDangXuatQuanLy;

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
            pnlMenu = new Panel();
            btnDangXuatQuanLy = new Button();
            btnMenuThongKe = new Button();
            btnMenuHoaDon = new Button();
            btnMenuVoucher = new Button();
            btnMenuLoaiVe = new Button();
            btnMenuVe = new Button();
            btnMenuNguoiDung = new Button();
            pnlNoiDung = new Panel();
            pnlThongKe = new Panel();
            pnlBieuDo = new Panel();
            dgvThongKeLoaiVe = new DataGridView();
            lblThongKeTongVe = new Label();
            lblThongKeThanhTien = new Label();
            lblThongKeTongGiam = new Label();
            lblThongKeTongTien = new Label();
            lblThongKeTongHoaDon = new Label();
            lblThongKeTrungBinhHoaDon = new Label();
            lblThongKeLoaiVeBanChay = new Label();
            pnlBoLocThongKe = new Panel();
            btnApDungThongKe = new Button();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblLoaiThongKe = new Label();
            cboLoaiThongKe = new ComboBox();
            ucQuanLyHoaDon = new ucQuanLyHoaDon();
            ucQuanLyVoucher = new ucQuanLyVoucher();
            ucPhanLoaiVe = new ucPhanLoaiVe();
            ucQuanLyVe = new ucQuanLyVe();
            ucNguoiDung = new ucQuanLyNguoiDung();
            pnlMenu.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            pnlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeLoaiVe).BeginInit();
            pnlBoLocThongKe.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(245, 245, 245);
            pnlMenu.Controls.Add(btnDangXuatQuanLy);
            pnlMenu.Controls.Add(btnMenuThongKe);
            pnlMenu.Controls.Add(btnMenuHoaDon);
            pnlMenu.Controls.Add(btnMenuVoucher);
            pnlMenu.Controls.Add(btnMenuLoaiVe);
            pnlMenu.Controls.Add(btnMenuVe);
            pnlMenu.Controls.Add(btnMenuNguoiDung);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 640);
            pnlMenu.TabIndex = 0;
            // 
            // btnDangXuatQuanLy
            // 
            btnDangXuatQuanLy.Dock = DockStyle.Bottom;
            btnDangXuatQuanLy.Location = new Point(0, 596);
            btnDangXuatQuanLy.Name = "btnDangXuatQuanLy";
            btnDangXuatQuanLy.Size = new Size(200, 44);
            btnDangXuatQuanLy.TabIndex = 6;
            btnDangXuatQuanLy.Text = "Đăng xuất";
            btnDangXuatQuanLy.UseVisualStyleBackColor = true;
            btnDangXuatQuanLy.Click += btnDangXuatQuanLy_Click;
            // 
            // btnMenuThongKe
            // 
            btnMenuThongKe.Dock = DockStyle.Top;
            btnMenuThongKe.Location = new Point(0, 220);
            btnMenuThongKe.Name = "btnMenuThongKe";
            btnMenuThongKe.Size = new Size(200, 44);
            btnMenuThongKe.TabIndex = 5;
            btnMenuThongKe.Text = "Thống kê";
            btnMenuThongKe.UseVisualStyleBackColor = true;
            btnMenuThongKe.Click += btnMenuThongKe_Click;
            // 
            // btnMenuHoaDon
            // 
            btnMenuHoaDon.Dock = DockStyle.Top;
            btnMenuHoaDon.Location = new Point(0, 176);
            btnMenuHoaDon.Name = "btnMenuHoaDon";
            btnMenuHoaDon.Size = new Size(200, 44);
            btnMenuHoaDon.TabIndex = 4;
            btnMenuHoaDon.Text = "Quản lý hóa đơn";
            btnMenuHoaDon.UseVisualStyleBackColor = true;
            btnMenuHoaDon.Click += btnMenuHoaDon_Click;
            // 
            // btnMenuVoucher
            // 
            btnMenuVoucher.Dock = DockStyle.Top;
            btnMenuVoucher.Location = new Point(0, 132);
            btnMenuVoucher.Name = "btnMenuVoucher";
            btnMenuVoucher.Size = new Size(200, 44);
            btnMenuVoucher.TabIndex = 3;
            btnMenuVoucher.Text = "Quản lý voucher";
            btnMenuVoucher.UseVisualStyleBackColor = true;
            btnMenuVoucher.Click += btnMenuVoucher_Click;
            // 
            // btnMenuLoaiVe
            // 
            btnMenuLoaiVe.Dock = DockStyle.Top;
            btnMenuLoaiVe.Location = new Point(0, 88);
            btnMenuLoaiVe.Name = "btnMenuLoaiVe";
            btnMenuLoaiVe.Size = new Size(200, 44);
            btnMenuLoaiVe.TabIndex = 2;
            btnMenuLoaiVe.Text = "Phân loại vé";
            btnMenuLoaiVe.UseVisualStyleBackColor = true;
            btnMenuLoaiVe.Click += btnMenuLoaiVe_Click;
            // 
            // btnMenuVe
            // 
            btnMenuVe.Dock = DockStyle.Top;
            btnMenuVe.Location = new Point(0, 44);
            btnMenuVe.Name = "btnMenuVe";
            btnMenuVe.Size = new Size(200, 44);
            btnMenuVe.TabIndex = 1;
            btnMenuVe.Text = "Quản lý vé";
            btnMenuVe.UseVisualStyleBackColor = true;
            btnMenuVe.Click += btnMenuVe_Click;
            // 
            // btnMenuNguoiDung
            // 
            btnMenuNguoiDung.Dock = DockStyle.Top;
            btnMenuNguoiDung.Location = new Point(0, 0);
            btnMenuNguoiDung.Name = "btnMenuNguoiDung";
            btnMenuNguoiDung.Size = new Size(200, 44);
            btnMenuNguoiDung.TabIndex = 0;
            btnMenuNguoiDung.Text = "Quản lý người dùng";
            btnMenuNguoiDung.UseVisualStyleBackColor = true;
            btnMenuNguoiDung.Click += btnMenuNguoiDung_Click;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(pnlThongKe);
            pnlNoiDung.Controls.Add(ucQuanLyHoaDon);
            pnlNoiDung.Controls.Add(ucQuanLyVoucher);
            pnlNoiDung.Controls.Add(ucPhanLoaiVe);
            pnlNoiDung.Controls.Add(ucQuanLyVe);
            pnlNoiDung.Controls.Add(ucNguoiDung);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(200, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(1000, 640);
            pnlNoiDung.TabIndex = 1;
            // 
            // ucQuanLyHoaDon
            // 
            ucQuanLyHoaDon.Dock = DockStyle.Fill;
            ucQuanLyHoaDon.Location = new Point(16, 16);
            ucQuanLyHoaDon.Name = "ucQuanLyHoaDon";
            ucQuanLyHoaDon.Size = new Size(968, 608);
            ucQuanLyHoaDon.TabIndex = 4;
            ucQuanLyHoaDon.Visible = false;
            // 
            // ucQuanLyVoucher
            // 
            ucQuanLyVoucher.Dock = DockStyle.Fill;
            ucQuanLyVoucher.Location = new Point(16, 16);
            ucQuanLyVoucher.Name = "ucQuanLyVoucher";
            ucQuanLyVoucher.Size = new Size(968, 608);
            ucQuanLyVoucher.TabIndex = 3;
            ucQuanLyVoucher.Visible = false;
            // 
            // ucPhanLoaiVe
            // 
            ucPhanLoaiVe.Dock = DockStyle.Fill;
            ucPhanLoaiVe.Location = new Point(16, 16);
            ucPhanLoaiVe.Name = "ucPhanLoaiVe";
            ucPhanLoaiVe.Size = new Size(968, 608);
            ucPhanLoaiVe.TabIndex = 2;
            ucPhanLoaiVe.Visible = false;
            // 
            // ucQuanLyVe
            // 
            ucQuanLyVe.Dock = DockStyle.Fill;
            ucQuanLyVe.Location = new Point(16, 16);
            ucQuanLyVe.Name = "ucQuanLyVe";
            ucQuanLyVe.Size = new Size(968, 608);
            ucQuanLyVe.TabIndex = 1;
            ucQuanLyVe.Visible = false;
            // 
            // ucNguoiDung
            // 
            ucNguoiDung.Dock = DockStyle.Fill;
            ucNguoiDung.Location = new Point(16, 16);
            ucNguoiDung.Name = "ucNguoiDung";
            ucNguoiDung.Size = new Size(968, 608);
            ucNguoiDung.TabIndex = 0;
            // 
            // pnlThongKe
            // 
            pnlThongKe.Controls.Add(pnlBieuDo);
            pnlThongKe.Controls.Add(dgvThongKeLoaiVe);
            pnlThongKe.Controls.Add(lblThongKeTongVe);
            pnlThongKe.Controls.Add(lblThongKeThanhTien);
            pnlThongKe.Controls.Add(lblThongKeTongGiam);
            pnlThongKe.Controls.Add(lblThongKeTongTien);
            pnlThongKe.Controls.Add(lblThongKeTongHoaDon);
            pnlThongKe.Controls.Add(lblThongKeTrungBinhHoaDon);
            pnlThongKe.Controls.Add(lblThongKeLoaiVeBanChay);
            pnlThongKe.Controls.Add(pnlBoLocThongKe);
            pnlThongKe.Dock = DockStyle.Fill;
            pnlThongKe.Location = new Point(16, 16);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.Size = new Size(968, 608);
            pnlThongKe.TabIndex = 5;
            pnlThongKe.Visible = false;
            // 
            // pnlBieuDo
            // 
            pnlBieuDo.BackColor = Color.White;
            pnlBieuDo.BorderStyle = BorderStyle.FixedSingle;
            pnlBieuDo.Location = new Point(280, 64);
            pnlBieuDo.Name = "pnlBieuDo";
            pnlBieuDo.Size = new Size(680, 324);
            pnlBieuDo.TabIndex = 6;
            // 
            // dgvThongKeLoaiVe
            // 
            dgvThongKeLoaiVe.AllowUserToAddRows = false;
            dgvThongKeLoaiVe.AllowUserToDeleteRows = false;
            dgvThongKeLoaiVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKeLoaiVe.ColumnHeadersHeight = 29;
            dgvThongKeLoaiVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThongKeLoaiVe.Location = new Point(0, 400);
            dgvThongKeLoaiVe.Name = "dgvThongKeLoaiVe";
            dgvThongKeLoaiVe.ReadOnly = true;
            dgvThongKeLoaiVe.RowHeadersVisible = false;
            dgvThongKeLoaiVe.RowHeadersWidth = 51;
            dgvThongKeLoaiVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKeLoaiVe.Size = new Size(968, 208);
            dgvThongKeLoaiVe.TabIndex = 5;
            // 
            // lblThongKeTongVe
            // 
            lblThongKeTongVe.AutoSize = true;
            lblThongKeTongVe.Location = new Point(12, 172);
            lblThongKeTongVe.Name = "lblThongKeTongVe";
            lblThongKeTongVe.Size = new Size(94, 20);
            lblThongKeTongVe.TabIndex = 4;
            lblThongKeTongVe.Text = "Tổng vé bán:";
            // 
            // lblThongKeThanhTien
            // 
            lblThongKeThanhTien.AutoSize = true;
            lblThongKeThanhTien.Location = new Point(12, 144);
            lblThongKeThanhTien.Name = "lblThongKeThanhTien";
            lblThongKeThanhTien.Size = new Size(81, 20);
            lblThongKeThanhTien.TabIndex = 3;
            lblThongKeThanhTien.Text = "Thành tiền:";
            // 
            // lblThongKeTongGiam
            // 
            lblThongKeTongGiam.AutoSize = true;
            lblThongKeTongGiam.Location = new Point(12, 116);
            lblThongKeTongGiam.Name = "lblThongKeTongGiam";
            lblThongKeTongGiam.Size = new Size(109, 20);
            lblThongKeTongGiam.TabIndex = 2;
            lblThongKeTongGiam.Text = "Tổng giảm giá:";
            // 
            // lblThongKeTongTien
            // 
            lblThongKeTongTien.AutoSize = true;
            lblThongKeTongTien.Location = new Point(12, 88);
            lblThongKeTongTien.Name = "lblThongKeTongTien";
            lblThongKeTongTien.Size = new Size(75, 20);
            lblThongKeTongTien.TabIndex = 1;
            lblThongKeTongTien.Text = "Tổng tiền:";
            // 
            // lblThongKeTongHoaDon
            // 
            lblThongKeTongHoaDon.AutoSize = true;
            lblThongKeTongHoaDon.Location = new Point(12, 60);
            lblThongKeTongHoaDon.Name = "lblThongKeTongHoaDon";
            lblThongKeTongHoaDon.Size = new Size(105, 20);
            lblThongKeTongHoaDon.TabIndex = 0;
            lblThongKeTongHoaDon.Text = "Tổng hóa đơn:";
            // 
            // lblThongKeTrungBinhHoaDon
            // 
            lblThongKeTrungBinhHoaDon.AutoSize = true;
            lblThongKeTrungBinhHoaDon.Location = new Point(12, 200);
            lblThongKeTrungBinhHoaDon.Name = "lblThongKeTrungBinhHoaDon";
            lblThongKeTrungBinhHoaDon.Size = new Size(90, 20);
            lblThongKeTrungBinhHoaDon.TabIndex = 7;
            lblThongKeTrungBinhHoaDon.Text = "TB/hóa đơn:";
            // 
            // lblThongKeLoaiVeBanChay
            // 
            lblThongKeLoaiVeBanChay.AutoSize = true;
            lblThongKeLoaiVeBanChay.Location = new Point(12, 228);
            lblThongKeLoaiVeBanChay.Name = "lblThongKeLoaiVeBanChay";
            lblThongKeLoaiVeBanChay.Size = new Size(122, 20);
            lblThongKeLoaiVeBanChay.TabIndex = 8;
            lblThongKeLoaiVeBanChay.Text = "Loại vé bán chạy:";
            // 
            // pnlBoLocThongKe
            // 
            pnlBoLocThongKe.BackColor = Color.FromArgb(245, 245, 245);
            pnlBoLocThongKe.BorderStyle = BorderStyle.FixedSingle;
            pnlBoLocThongKe.Controls.Add(btnApDungThongKe);
            pnlBoLocThongKe.Controls.Add(lblDenNgay);
            pnlBoLocThongKe.Controls.Add(dtpDenNgay);
            pnlBoLocThongKe.Controls.Add(lblTuNgay);
            pnlBoLocThongKe.Controls.Add(dtpTuNgay);
            pnlBoLocThongKe.Controls.Add(lblLoaiThongKe);
            pnlBoLocThongKe.Controls.Add(cboLoaiThongKe);
            pnlBoLocThongKe.Location = new Point(0, 0);
            pnlBoLocThongKe.Name = "pnlBoLocThongKe";
            pnlBoLocThongKe.Size = new Size(968, 56);
            pnlBoLocThongKe.TabIndex = 0;
            // 
            // btnApDungThongKe
            // 
            btnApDungThongKe.Location = new Point(806, 11);
            btnApDungThongKe.Name = "btnApDungThongKe";
            btnApDungThongKe.Size = new Size(140, 32);
            btnApDungThongKe.TabIndex = 6;
            btnApDungThongKe.Text = "Áp dụng";
            btnApDungThongKe.UseVisualStyleBackColor = true;
            btnApDungThongKe.Click += btnApDungThongKe_Click;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Location = new Point(529, 18);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(75, 20);
            lblDenNgay.TabIndex = 5;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(610, 13);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(190, 27);
            dtpDenNgay.TabIndex = 4;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Location = new Point(268, 15);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(65, 20);
            lblTuNgay.TabIndex = 3;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(339, 13);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(184, 27);
            dtpTuNgay.TabIndex = 2;
            // 
            // lblLoaiThongKe
            // 
            lblLoaiThongKe.AutoSize = true;
            lblLoaiThongKe.Location = new Point(16, 16);
            lblLoaiThongKe.Name = "lblLoaiThongKe";
            lblLoaiThongKe.Size = new Size(102, 20);
            lblLoaiThongKe.TabIndex = 1;
            lblLoaiThongKe.Text = "Loại thống kê:";
            // 
            // cboLoaiThongKe
            // 
            cboLoaiThongKe.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiThongKe.Location = new Point(124, 12);
            cboLoaiThongKe.Name = "cboLoaiThongKe";
            cboLoaiThongKe.Size = new Size(125, 28);
            cboLoaiThongKe.TabIndex = 0;
            cboLoaiThongKe.SelectedIndexChanged += cboLoaiThongKe_SelectedIndexChanged;
            // 
            // 
            // frmDashboardQuanLy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 640);
            Controls.Add(pnlNoiDung);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "frmDashboardQuanLy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard Quản lý";
            Load += frmDashboardQuanLy_Load;
            pnlMenu.ResumeLayout(false);
            pnlNoiDung.ResumeLayout(false);
            pnlThongKe.ResumeLayout(false);
            pnlThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeLoaiVe).EndInit();
            pnlBoLocThongKe.ResumeLayout(false);
            pnlBoLocThongKe.PerformLayout();
            ResumeLayout(false);
        }

    }
}
