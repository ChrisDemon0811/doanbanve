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
        private Panel pnlNguoiDung;
        private DataGridView dgvNguoiDung;
        private Button btnResetMatKhau;
        private Button btnXemThongTin;
        private Panel pnlNhapMatKhau;
        private Label lblMatKhauMoi;
        private TextBox txtMatKhauMoi;
        private Button btnXacNhanMatKhau;
        private Button btnHuyMatKhau;
        private Panel pnlQuanLyVe;
        private DataGridView dgvVe;
        private Button btnThemVe;
        private Button btnSuaVe;
        private Button btnXoaVe;
        private Button btnLamMoiVe;
        private Panel pnlQuanLyLoaiVe;
        private DataGridView dgvLoaiVe;
        private Button btnThemLoaiVe;
        private Button btnSuaLoaiVe;
        private Button btnXoaLoaiVe;
        private Panel pnlQuanLyVoucher;
        private Panel pnlQuanLyHoaDon;
        private Panel pnlThongKe;
        private Label lblThongKeTongHoaDon;
        private Label lblThongKeTongTien;
        private Label lblThongKeTongGiam;
        private Label lblThongKeThanhTien;
        private Label lblThongKeTongVe;
        private DataGridView dgvThongKeLoaiVe;
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
            btnMenuNguoiDung = new Button();
            btnMenuVe = new Button();
            btnMenuLoaiVe = new Button();
            btnMenuVoucher = new Button();
            btnMenuHoaDon = new Button();
            btnMenuThongKe = new Button();
            pnlNoiDung = new Panel();
            pnlQuanLyLoaiVe = new Panel();
            btnXoaLoaiVe = new Button();
            btnSuaLoaiVe = new Button();
            btnThemLoaiVe = new Button();
            dgvLoaiVe = new DataGridView();
            pnlQuanLyVe = new Panel();
            btnLamMoiVe = new Button();
            btnXoaVe = new Button();
            btnSuaVe = new Button();
            btnThemVe = new Button();
            dgvVe = new DataGridView();
            pnlNguoiDung = new Panel();
            pnlNhapMatKhau = new Panel();
            btnHuyMatKhau = new Button();
            btnXacNhanMatKhau = new Button();
            txtMatKhauMoi = new TextBox();
            lblMatKhauMoi = new Label();
            btnXemThongTin = new Button();
            btnResetMatKhau = new Button();
            dgvNguoiDung = new DataGridView();
            pnlQuanLyVoucher = new Panel();
            pnlQuanLyHoaDon = new Panel();
            pnlThongKe = new Panel();
            lblThongKeTongHoaDon = new Label();
            lblThongKeTongTien = new Label();
            lblThongKeTongGiam = new Label();
            lblThongKeThanhTien = new Label();
            lblThongKeTongVe = new Label();
            dgvThongKeLoaiVe = new DataGridView();
            dgvHoaDon = new DataGridView();
            btnChiTietHoaDon = new Button();
            dgvVoucher = new DataGridView();
            btnThemVoucher = new Button();
            btnSuaVoucher = new Button();
            btnXoaVoucher = new Button();
            btnDangXuatQuanLy = new Button();
            pnlMenu.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            pnlQuanLyLoaiVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiVe).BeginInit();
            pnlQuanLyVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVe).BeginInit();
            pnlQuanLyVoucher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVoucher).BeginInit();
            pnlQuanLyHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            pnlThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeLoaiVe).BeginInit();
            pnlNguoiDung.SuspendLayout();
            pnlNhapMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).BeginInit();
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
            pnlMenu.Size = new Size(180, 500);
            pnlMenu.TabIndex = 0;
            // 
            // btnMenuNguoiDung
            // 
            btnMenuNguoiDung.Dock = DockStyle.Top;
            btnMenuNguoiDung.Location = new Point(0, 0);
            btnMenuNguoiDung.Name = "btnMenuNguoiDung";
            btnMenuNguoiDung.Size = new Size(180, 44);
            btnMenuNguoiDung.TabIndex = 0;
            btnMenuNguoiDung.Text = "Quản lý người dùng";
            btnMenuNguoiDung.UseVisualStyleBackColor = true;
            btnMenuNguoiDung.Click += btnMenuNguoiDung_Click;
            // 
            // btnMenuVe
            // 
            btnMenuVe.Dock = DockStyle.Top;
            btnMenuVe.Location = new Point(0, 44);
            btnMenuVe.Name = "btnMenuVe";
            btnMenuVe.Size = new Size(180, 44);
            btnMenuVe.TabIndex = 1;
            btnMenuVe.Text = "Quản lý vé";
            btnMenuVe.UseVisualStyleBackColor = true;
            btnMenuVe.Click += btnMenuVe_Click;
            // 
            // btnMenuLoaiVe
            // 
            btnMenuLoaiVe.Dock = DockStyle.Top;
            btnMenuLoaiVe.Location = new Point(0, 88);
            btnMenuLoaiVe.Name = "btnMenuLoaiVe";
            btnMenuLoaiVe.Size = new Size(180, 44);
            btnMenuLoaiVe.TabIndex = 2;
            btnMenuLoaiVe.Text = "Phân loại vé";
            btnMenuLoaiVe.UseVisualStyleBackColor = true;
            btnMenuLoaiVe.Click += btnMenuLoaiVe_Click;
            // 
            // btnMenuVoucher
            // 
            btnMenuVoucher.Dock = DockStyle.Top;
            btnMenuVoucher.Location = new Point(0, 132);
            btnMenuVoucher.Name = "btnMenuVoucher";
            btnMenuVoucher.Size = new Size(180, 44);
            btnMenuVoucher.TabIndex = 3;
            btnMenuVoucher.Text = "Quản lý voucher";
            btnMenuVoucher.UseVisualStyleBackColor = true;
            btnMenuVoucher.Click += btnMenuVoucher_Click;
            // 
            // btnMenuHoaDon
            // 
            btnMenuHoaDon.Dock = DockStyle.Top;
            btnMenuHoaDon.Location = new Point(0, 176);
            btnMenuHoaDon.Name = "btnMenuHoaDon";
            btnMenuHoaDon.Size = new Size(180, 44);
            btnMenuHoaDon.TabIndex = 4;
            btnMenuHoaDon.Text = "Quản lý hóa đơn";
            btnMenuHoaDon.UseVisualStyleBackColor = true;
            btnMenuHoaDon.Click += btnMenuHoaDon_Click;
            // 
            // btnDangXuatQuanLy
            // 
            btnDangXuatQuanLy.Dock = DockStyle.Bottom;
            btnDangXuatQuanLy.Location = new Point(0, 456);
            btnDangXuatQuanLy.Name = "btnDangXuatQuanLy";
            btnDangXuatQuanLy.Size = new Size(180, 44);
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
            btnMenuThongKe.Size = new Size(180, 44);
            btnMenuThongKe.TabIndex = 5;
            btnMenuThongKe.Text = "Thống kê";
            btnMenuThongKe.UseVisualStyleBackColor = true;
            btnMenuThongKe.Click += btnMenuThongKe_Click;
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(pnlThongKe);
            pnlNoiDung.Controls.Add(pnlQuanLyHoaDon);
            pnlNoiDung.Controls.Add(pnlQuanLyVoucher);
            pnlNoiDung.Controls.Add(pnlQuanLyLoaiVe);
            pnlNoiDung.Controls.Add(pnlQuanLyVe);
            pnlNoiDung.Controls.Add(pnlNguoiDung);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(180, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(820, 500);
            pnlNoiDung.TabIndex = 1;
            // 
            // pnlThongKe
            // 
            pnlThongKe.Controls.Add(dgvThongKeLoaiVe);
            pnlThongKe.Controls.Add(lblThongKeTongVe);
            pnlThongKe.Controls.Add(lblThongKeThanhTien);
            pnlThongKe.Controls.Add(lblThongKeTongGiam);
            pnlThongKe.Controls.Add(lblThongKeTongTien);
            pnlThongKe.Controls.Add(lblThongKeTongHoaDon);
            pnlThongKe.Dock = DockStyle.Fill;
            pnlThongKe.Location = new Point(16, 16);
            pnlThongKe.Name = "pnlThongKe";
            pnlThongKe.Size = new Size(788, 468);
            pnlThongKe.TabIndex = 5;
            pnlThongKe.Visible = false;
            // 
            // lblThongKeTongHoaDon
            // 
            lblThongKeTongHoaDon.AutoSize = true;
            lblThongKeTongHoaDon.Location = new Point(0, 0);
            lblThongKeTongHoaDon.Name = "lblThongKeTongHoaDon";
            lblThongKeTongHoaDon.Size = new Size(108, 20);
            lblThongKeTongHoaDon.TabIndex = 0;
            lblThongKeTongHoaDon.Text = "Tổng hóa đơn:";
            // 
            // lblThongKeTongTien
            // 
            lblThongKeTongTien.AutoSize = true;
            lblThongKeTongTien.Location = new Point(0, 28);
            lblThongKeTongTien.Name = "lblThongKeTongTien";
            lblThongKeTongTien.Size = new Size(74, 20);
            lblThongKeTongTien.TabIndex = 1;
            lblThongKeTongTien.Text = "Tổng tiền:";
            // 
            // lblThongKeTongGiam
            // 
            lblThongKeTongGiam.AutoSize = true;
            lblThongKeTongGiam.Location = new Point(0, 56);
            lblThongKeTongGiam.Name = "lblThongKeTongGiam";
            lblThongKeTongGiam.Size = new Size(104, 20);
            lblThongKeTongGiam.TabIndex = 2;
            lblThongKeTongGiam.Text = "Tổng giảm giá:";
            // 
            // lblThongKeThanhTien
            // 
            lblThongKeThanhTien.AutoSize = true;
            lblThongKeThanhTien.Location = new Point(0, 84);
            lblThongKeThanhTien.Name = "lblThongKeThanhTien";
            lblThongKeThanhTien.Size = new Size(90, 20);
            lblThongKeThanhTien.TabIndex = 3;
            lblThongKeThanhTien.Text = "Thành tiền:";
            // 
            // lblThongKeTongVe
            // 
            lblThongKeTongVe.AutoSize = true;
            lblThongKeTongVe.Location = new Point(0, 112);
            lblThongKeTongVe.Name = "lblThongKeTongVe";
            lblThongKeTongVe.Size = new Size(88, 20);
            lblThongKeTongVe.TabIndex = 4;
            lblThongKeTongVe.Text = "Tổng vé bán:";
            // 
            // dgvThongKeLoaiVe
            // 
            dgvThongKeLoaiVe.AllowUserToAddRows = false;
            dgvThongKeLoaiVe.AllowUserToDeleteRows = false;
            dgvThongKeLoaiVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKeLoaiVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvThongKeLoaiVe.Location = new Point(0, 148);
            dgvThongKeLoaiVe.Name = "dgvThongKeLoaiVe";
            dgvThongKeLoaiVe.ReadOnly = true;
            dgvThongKeLoaiVe.RowHeadersVisible = false;
            dgvThongKeLoaiVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThongKeLoaiVe.Size = new Size(788, 320);
            dgvThongKeLoaiVe.TabIndex = 5;
            // 
            // pnlQuanLyHoaDon
            // 
            pnlQuanLyHoaDon.Controls.Add(btnChiTietHoaDon);
            pnlQuanLyHoaDon.Controls.Add(dgvHoaDon);
            pnlQuanLyHoaDon.Dock = DockStyle.Fill;
            pnlQuanLyHoaDon.Location = new Point(16, 16);
            pnlQuanLyHoaDon.Name = "pnlQuanLyHoaDon";
            pnlQuanLyHoaDon.Size = new Size(788, 468);
            pnlQuanLyHoaDon.TabIndex = 4;
            pnlQuanLyHoaDon.Visible = false;
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHoaDon.Location = new Point(0, 0);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersVisible = false;
            dgvHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoaDon.Size = new Size(788, 412);
            dgvHoaDon.TabIndex = 0;
            // 
            // btnChiTietHoaDon
            // 
            btnChiTietHoaDon.Location = new Point(0, 430);
            btnChiTietHoaDon.Name = "btnChiTietHoaDon";
            btnChiTietHoaDon.Size = new Size(140, 28);
            btnChiTietHoaDon.TabIndex = 1;
            btnChiTietHoaDon.Text = "Chi tiết hóa đơn";
            btnChiTietHoaDon.UseVisualStyleBackColor = true;
            btnChiTietHoaDon.Click += btnChiTietHoaDon_Click;
            // 
            // pnlQuanLyLoaiVe
            // 
            pnlQuanLyLoaiVe.Controls.Add(btnXoaLoaiVe);
            pnlQuanLyLoaiVe.Controls.Add(btnSuaLoaiVe);
            pnlQuanLyLoaiVe.Controls.Add(btnThemLoaiVe);
            pnlQuanLyLoaiVe.Controls.Add(dgvLoaiVe);
            pnlQuanLyLoaiVe.Dock = DockStyle.Fill;
            pnlQuanLyLoaiVe.Location = new Point(16, 16);
            pnlQuanLyLoaiVe.Name = "pnlQuanLyLoaiVe";
            pnlQuanLyLoaiVe.Size = new Size(788, 468);
            pnlQuanLyLoaiVe.TabIndex = 2;
            pnlQuanLyLoaiVe.Visible = false;
            // btnXoaLoaiVe
            // 
            btnXoaLoaiVe.Location = new Point(206, 437);
            btnXoaLoaiVe.Name = "btnXoaLoaiVe";
            btnXoaLoaiVe.Size = new Size(90, 28);
            btnXoaLoaiVe.TabIndex = 3;
            btnXoaLoaiVe.Text = "Xóa";
            btnXoaLoaiVe.UseVisualStyleBackColor = true;
            btnXoaLoaiVe.Click += btnXoaLoaiVe_Click;
            // 
            // btnSuaLoaiVe
            // 
            btnSuaLoaiVe.Location = new Point(106, 437);
            btnSuaLoaiVe.Name = "btnSuaLoaiVe";
            btnSuaLoaiVe.Size = new Size(90, 28);
            btnSuaLoaiVe.TabIndex = 2;
            btnSuaLoaiVe.Text = "Sửa";
            btnSuaLoaiVe.UseVisualStyleBackColor = true;
            btnSuaLoaiVe.Click += btnSuaLoaiVe_Click;
            // 
            // btnThemLoaiVe
            // 
            btnThemLoaiVe.Location = new Point(6, 437);
            btnThemLoaiVe.Name = "btnThemLoaiVe";
            btnThemLoaiVe.Size = new Size(90, 28);
            btnThemLoaiVe.TabIndex = 1;
            btnThemLoaiVe.Text = "Thêm";
            btnThemLoaiVe.UseVisualStyleBackColor = true;
            btnThemLoaiVe.Click += btnThemLoaiVe_Click;
            // 
            // dgvLoaiVe
            // 
            dgvLoaiVe.AllowUserToAddRows = false;
            dgvLoaiVe.AllowUserToDeleteRows = false;
            dgvLoaiVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLoaiVe.Location = new Point(0, 0);
            dgvLoaiVe.Name = "dgvLoaiVe";
            dgvLoaiVe.ReadOnly = true;
            dgvLoaiVe.RowHeadersVisible = false;
            dgvLoaiVe.RowHeadersWidth = 51;
            dgvLoaiVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiVe.Size = new Size(788, 424);
            dgvLoaiVe.TabIndex = 0;
            // 
            // pnlQuanLyVe
            // 
            pnlQuanLyVe.Controls.Add(btnLamMoiVe);
            pnlQuanLyVe.Controls.Add(btnXoaVe);
            pnlQuanLyVe.Controls.Add(btnSuaVe);
            pnlQuanLyVe.Controls.Add(btnThemVe);
            pnlQuanLyVe.Controls.Add(dgvVe);
            pnlQuanLyVe.Dock = DockStyle.Fill;
            pnlQuanLyVe.Location = new Point(16, 16);
            pnlQuanLyVe.Name = "pnlQuanLyVe";
            pnlQuanLyVe.Size = new Size(788, 468);
            pnlQuanLyVe.TabIndex = 1;
            pnlQuanLyVe.Visible = false;
            // 
            // pnlQuanLyVoucher
            // 
            pnlQuanLyVoucher.Controls.Add(btnXoaVoucher);
            pnlQuanLyVoucher.Controls.Add(btnSuaVoucher);
            pnlQuanLyVoucher.Controls.Add(btnThemVoucher);
            pnlQuanLyVoucher.Controls.Add(dgvVoucher);
            pnlQuanLyVoucher.Dock = DockStyle.Fill;
            pnlQuanLyVoucher.Location = new Point(16, 16);
            pnlQuanLyVoucher.Name = "pnlQuanLyVoucher";
            pnlQuanLyVoucher.Size = new Size(788, 468);
            pnlQuanLyVoucher.TabIndex = 3;
            pnlQuanLyVoucher.Visible = false;
            // 
            // dgvVoucher
            // 
            dgvVoucher.AllowUserToAddRows = false;
            dgvVoucher.AllowUserToDeleteRows = false;
            dgvVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVoucher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVoucher.Location = new Point(0, 0);
            dgvVoucher.Name = "dgvVoucher";
            dgvVoucher.ReadOnly = true;
            dgvVoucher.RowHeadersVisible = false;
            dgvVoucher.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVoucher.Size = new Size(788, 300);
            dgvVoucher.TabIndex = 0;
            // 
            // btnThemVoucher
            // 
            btnThemVoucher.Location = new Point(0, 316);
            btnThemVoucher.Name = "btnThemVoucher";
            btnThemVoucher.Size = new Size(90, 28);
            btnThemVoucher.TabIndex = 1;
            btnThemVoucher.Text = "Thêm";
            btnThemVoucher.UseVisualStyleBackColor = true;
            btnThemVoucher.Click += btnThemVoucher_Click;
            // 
            // btnSuaVoucher
            // 
            btnSuaVoucher.Location = new Point(100, 316);
            btnSuaVoucher.Name = "btnSuaVoucher";
            btnSuaVoucher.Size = new Size(90, 28);
            btnSuaVoucher.TabIndex = 2;
            btnSuaVoucher.Text = "Sửa";
            btnSuaVoucher.UseVisualStyleBackColor = true;
            btnSuaVoucher.Click += btnSuaVoucher_Click;
            // 
            // btnXoaVoucher
            // 
            btnXoaVoucher.Location = new Point(200, 316);
            btnXoaVoucher.Name = "btnXoaVoucher";
            btnXoaVoucher.Size = new Size(90, 28);
            btnXoaVoucher.TabIndex = 3;
            btnXoaVoucher.Text = "Xóa";
            btnXoaVoucher.UseVisualStyleBackColor = true;
            btnXoaVoucher.Click += btnXoaVoucher_Click;
            // 
            // btnLamMoiVe
            // 
            btnLamMoiVe.Location = new Point(302, 430);
            btnLamMoiVe.Name = "btnLamMoiVe";
            btnLamMoiVe.Size = new Size(90, 28);
            btnLamMoiVe.TabIndex = 22;
            btnLamMoiVe.Text = "Làm mới";
            btnLamMoiVe.UseVisualStyleBackColor = true;
            btnLamMoiVe.Click += btnLamMoiVe_Click;
            // 
            // btnXoaVe
            // 
            btnXoaVe.Location = new Point(202, 430);
            btnXoaVe.Name = "btnXoaVe";
            btnXoaVe.Size = new Size(90, 28);
            btnXoaVe.TabIndex = 21;
            btnXoaVe.Text = "Xóa";
            btnXoaVe.UseVisualStyleBackColor = true;
            btnXoaVe.Click += btnXoaVe_Click;
            // 
            // btnSuaVe
            // 
            btnSuaVe.Location = new Point(102, 430);
            btnSuaVe.Name = "btnSuaVe";
            btnSuaVe.Size = new Size(90, 28);
            btnSuaVe.TabIndex = 20;
            btnSuaVe.Text = "Sửa";
            btnSuaVe.UseVisualStyleBackColor = true;
            btnSuaVe.Click += btnSuaVe_Click;
            // 
            // btnThemVe
            // 
            btnThemVe.Location = new Point(2, 430);
            btnThemVe.Name = "btnThemVe";
            btnThemVe.Size = new Size(90, 28);
            btnThemVe.TabIndex = 19;
            btnThemVe.Text = "Thêm";
            btnThemVe.UseVisualStyleBackColor = true;
            btnThemVe.Click += btnThemVe_Click;
            // 
            // dgvVe
            // 
            dgvVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = false;
            dgvVe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVe.Location = new Point(0, 0);
            dgvVe.Name = "dgvVe";
            dgvVe.ReadOnly = true;
            dgvVe.RowHeadersVisible = false;
            dgvVe.RowHeadersWidth = 51;
            dgvVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVe.Size = new Size(788, 421);
            dgvVe.TabIndex = 0;
            // 
            // 
            // pnlNguoiDung
            // 
            pnlNguoiDung.Controls.Add(btnXemThongTin);
            pnlNguoiDung.Controls.Add(btnResetMatKhau);
            pnlNguoiDung.Controls.Add(dgvNguoiDung);
            pnlNguoiDung.Dock = DockStyle.Fill;
            pnlNguoiDung.Location = new Point(16, 16);
            pnlNguoiDung.Name = "pnlNguoiDung";
            pnlNguoiDung.Size = new Size(788, 468);
            pnlNguoiDung.TabIndex = 0;
            // 
            // btnXemThongTin
            // 
            btnXemThongTin.Location = new Point(156, 336);
            btnXemThongTin.Name = "btnXemThongTin";
            btnXemThongTin.Size = new Size(140, 32);
            btnXemThongTin.TabIndex = 2;
            btnXemThongTin.Text = "Xem thông tin";
            btnXemThongTin.UseVisualStyleBackColor = true;
            btnXemThongTin.Click += btnXemThongTin_Click;
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.Location = new Point(0, 336);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(140, 32);
            btnResetMatKhau.TabIndex = 1;
            btnResetMatKhau.Text = "Reset mật khẩu";
            btnResetMatKhau.UseVisualStyleBackColor = true;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // dgvNguoiDung
            // 
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.ColumnHeadersHeight = 29;
            dgvNguoiDung.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNguoiDung.Location = new Point(0, 0);
            dgvNguoiDung.Name = "dgvNguoiDung";
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.RowHeadersVisible = false;
            dgvNguoiDung.RowHeadersWidth = 51;
            dgvNguoiDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguoiDung.Size = new Size(788, 320);
            dgvNguoiDung.TabIndex = 0;
            // 
            // 
            // frmDashboardQuanLy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
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
            pnlQuanLyLoaiVe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLoaiVe).EndInit();
            pnlQuanLyVe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVe).EndInit();
            pnlQuanLyVoucher.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVoucher).EndInit();
            pnlQuanLyHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            pnlThongKe.ResumeLayout(false);
            pnlThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongKeLoaiVe).EndInit();
            pnlNguoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNguoiDung).EndInit();
            ResumeLayout(false);
        }

    }
}
