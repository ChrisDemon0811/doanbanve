using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmDashboardQuanLy : Form
    {
        private readonly NguoiDungController nguoiDungController = new();
        private readonly VeController veController = new();
        private readonly LoaiVeController loaiVeController = new();
        private readonly VoucherController voucherController = new();
        private readonly HoaDonController hoaDonController = new();

        public frmDashboardQuanLy()
        {
            InitializeComponent();
        }

        private async void frmDashboardQuanLy_Load(object sender, EventArgs e)
        {
            CauHinhBang(dgvNguoiDung);
            CauHinhBang(dgvVe);
            CauHinhBang(dgvLoaiVe);
            CauHinhBang(dgvVoucher);
            CauHinhBang(dgvHoaDon);
            CauHinhBang(dgvThongKeLoaiVe);
            await TaiDanhSachNguoiDung();
            await TaiDanhSachVe();
            await TaiDanhSachLoaiVeQuanLy();
            await TaiDanhSachVoucher();
            await TaiDanhSachHoaDon();
            await TaiThongKe();
            HienThiManHinhNguoiDung();
        }

        private void HienThiManHinhNguoiDung()
        {
            pnlNguoiDung.Visible = true;
            pnlQuanLyVe.Visible = false;
            pnlQuanLyLoaiVe.Visible = false;
            pnlQuanLyVoucher.Visible = false;
            pnlQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhVe()
        {
            pnlNguoiDung.Visible = false;
            pnlQuanLyVe.Visible = true;
            pnlQuanLyLoaiVe.Visible = false;
            pnlQuanLyVoucher.Visible = false;
            pnlQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhLoaiVe()
        {
            pnlNguoiDung.Visible = false;
            pnlQuanLyVe.Visible = false;
            pnlQuanLyLoaiVe.Visible = true;
            pnlQuanLyVoucher.Visible = false;
            pnlQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhVoucher()
        {
            pnlNguoiDung.Visible = false;
            pnlQuanLyVe.Visible = false;
            pnlQuanLyLoaiVe.Visible = false;
            pnlQuanLyVoucher.Visible = true;
            pnlQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhHoaDon()
        {
            pnlNguoiDung.Visible = false;
            pnlQuanLyVe.Visible = false;
            pnlQuanLyLoaiVe.Visible = false;
            pnlQuanLyVoucher.Visible = false;
            pnlQuanLyHoaDon.Visible = true;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhThongKe()
        {
            pnlNguoiDung.Visible = false;
            pnlQuanLyVe.Visible = false;
            pnlQuanLyLoaiVe.Visible = false;
            pnlQuanLyVoucher.Visible = false;
            pnlQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = true;
        }

        private void CauHinhBang(DataGridView bang)
        {
            bang.BackgroundColor = Color.White;
            bang.EnableHeadersVisualStyles = false;
            bang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
            bang.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            bang.RowTemplate.Height = 28;
            bang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bang.MultiSelect = false;
        }

        private async Task TaiDanhSachNguoiDung()
        {
            dgvNguoiDung.Rows.Clear();
            if (dgvNguoiDung.Columns.Count > 0)
            {
                dgvNguoiDung.Columns.Clear();
            }

            dgvNguoiDung.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaNguoiDung", HeaderText = "Mã" },
                new DataGridViewTextBoxColumn { Name = "colTaiKhoan", HeaderText = "Tài khoản" },
                new DataGridViewTextBoxColumn { Name = "colHoTen", HeaderText = "Họ tên" },
                new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "Email" },
                new DataGridViewTextBoxColumn { Name = "colSoDienThoai", HeaderText = "Số điện thoại" },
                new DataGridViewTextBoxColumn { Name = "colVaiTro", HeaderText = "Vai trò" }
            });

            dgvNguoiDung.Rows.Clear();
            var danhSach = await nguoiDungController.LayDanhSachNguoiDung();
            foreach (var nguoiDung in danhSach)
            {
                dgvNguoiDung.Rows.Add(
                    nguoiDung.MaNguoiDung,
                    nguoiDung.TaiKhoan,
                    nguoiDung.HoTen,
                    nguoiDung.Email,
                    nguoiDung.SoDienThoai,
                    nguoiDung.VaiTro);
            }

            dgvNguoiDung.ClearSelection();
        }

        private async Task TaiDanhSachVe()
        {
            dgvVe.Rows.Clear();
            if (dgvVe.Columns.Count > 0)
            {
                dgvVe.Columns.Clear();
            }

            dgvVe.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaVe", HeaderText = "Mã" },
                new DataGridViewTextBoxColumn { Name = "colTenVe", HeaderText = "Tên vé" },
                new DataGridViewTextBoxColumn { Name = "colMaLoaiVe", HeaderText = "Loại" },
                new DataGridViewTextBoxColumn { Name = "colGiaVe", HeaderText = "Giá vé" },
                new DataGridViewTextBoxColumn { Name = "colGiaNguoiLon", HeaderText = "Giá NL" },
                new DataGridViewTextBoxColumn { Name = "colGiaTreEm", HeaderText = "Giá TE" },
                new DataGridViewTextBoxColumn { Name = "colGiaNguoiCaoTuoi", HeaderText = "Giá NCT" },
                new DataGridViewTextBoxColumn { Name = "colSoLuong", HeaderText = "Số lượng" },
                new DataGridViewTextBoxColumn { Name = "colMoTa", HeaderText = "Mô tả" },
                new DataGridViewButtonColumn { Name = "colThongTinVe", HeaderText = "Thông tin", Text = "Xem", UseColumnTextForButtonValue = true }
            });

            var danhSach = await veController.LayDanhSachVeQuanLy();
            foreach (var ve in danhSach)
            {
                var dong = dgvVe.Rows.Add(
                    ve.MaVe,
                    ve.TenVe,
                    ve.MaLoaiVe,
                    ve.GiaVe,
                    ve.GiaNguoiLon,
                    ve.GiaTreEm,
                    ve.GiaNguoiCaoTuoi,
                    ve.SoLuong,
                    ve.MoTa);
                dgvVe.Rows[dong].Tag = ve;
            }

            if (dgvVe.Columns.Count > 0)
            {
                dgvVe.ClearSelection();
            }
        }

        private async Task TaiDanhSachLoaiVeQuanLy()
        {
            dgvLoaiVe.Rows.Clear();
            if (dgvLoaiVe.Columns.Count > 0)
            {
                dgvLoaiVe.Columns.Clear();
            }

            dgvLoaiVe.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaLoaiVe", HeaderText = "Mã" },
                new DataGridViewTextBoxColumn { Name = "colTenLoaiVe", HeaderText = "Tên loại vé" },
                new DataGridViewTextBoxColumn { Name = "colMoTaLoaiVe", HeaderText = "Mô tả" }
            });

            var danhSach = await loaiVeController.LayDanhSachLoaiVeQuanLy();
            foreach (var loaiVe in danhSach)
            {
                dgvLoaiVe.Rows.Add(
                    loaiVe.MaLoaiVe,
                    loaiVe.TenLoaiVe,
                    loaiVe.MoTa);
            }

            dgvLoaiVe.ClearSelection();
        }

        private async Task TaiDanhSachVoucher()
        {
            dgvVoucher.Rows.Clear();
            if (dgvVoucher.Columns.Count > 0)
            {
                dgvVoucher.Columns.Clear();
            }

            dgvVoucher.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaVoucher", HeaderText = "Mã" },
                new DataGridViewTextBoxColumn { Name = "colMaGiamGia", HeaderText = "Mã giảm giá" },
                new DataGridViewTextBoxColumn { Name = "colTenVoucher", HeaderText = "Tên voucher" },
                new DataGridViewTextBoxColumn { Name = "colKieuGiamGia", HeaderText = "Kiểu" },
                new DataGridViewTextBoxColumn { Name = "colGiaTriGiam", HeaderText = "Giá trị" },
                new DataGridViewTextBoxColumn { Name = "colNgayBatDau", HeaderText = "Bắt đầu" },
                new DataGridViewTextBoxColumn { Name = "colNgayKetThuc", HeaderText = "Kết thúc" },
                new DataGridViewTextBoxColumn { Name = "colSoLuong", HeaderText = "Số lượng" }
            });

            var danhSach = await voucherController.LayDanhSachVoucher();
            foreach (var voucher in danhSach)
            {
                dgvVoucher.Rows.Add(
                    voucher.MaVoucher,
                    voucher.MaGiamGia,
                    voucher.TenVoucher,
                    voucher.KieuGiamGia,
                    voucher.GiaTriGiam,
                    voucher.NgayBatDau.ToString("dd/MM/yyyy"),
                    voucher.NgayKetThuc.ToString("dd/MM/yyyy"),
                    voucher.SoLuong);
            }

            dgvVoucher.ClearSelection();
        }

        private async Task TaiDanhSachHoaDon()
        {
            dgvHoaDon.Rows.Clear();
            if (dgvHoaDon.Columns.Count > 0)
            {
                dgvHoaDon.Columns.Clear();
            }

            dgvHoaDon.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaHoaDon", HeaderText = "Mã" },
                new DataGridViewTextBoxColumn { Name = "colNguoiDat", HeaderText = "Người đặt" },
                new DataGridViewTextBoxColumn { Name = "colNgayLap", HeaderText = "Ngày lập" },
                new DataGridViewTextBoxColumn { Name = "colTongTien", HeaderText = "Tổng tiền" },
                new DataGridViewTextBoxColumn { Name = "colGiamGia", HeaderText = "Giảm giá" },
                new DataGridViewTextBoxColumn { Name = "colThanhTien", HeaderText = "Thành tiền" },
                new DataGridViewTextBoxColumn { Name = "colThanhToan", HeaderText = "Thanh toán" },
                new DataGridViewTextBoxColumn { Name = "colTrangThai", HeaderText = "Trạng thái" }
            });

            var danhSach = await hoaDonController.LayDanhSachHoaDonQuanLy();
            foreach (var hoaDon in danhSach)
            {
                dgvHoaDon.Rows.Add(
                    hoaDon.MaHoaDon,
                    hoaDon.HoTenNguoiDat,
                    hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                    hoaDon.TongTien.ToString("N0") + " VNĐ",
                    hoaDon.TienGiam.ToString("N0") + " VNĐ",
                    hoaDon.ThanhTien.ToString("N0") + " VNĐ",
                    hoaDon.ThanhToan,
                    hoaDon.TrangThai);
            }

            dgvHoaDon.ClearSelection();
        }

        private async Task TaiThongKe()
        {
            var thongKe = await hoaDonController.LayThongKeDuLieu();
            var tongVe = await hoaDonController.LayTongVeDaBan();

            lblThongKeTongHoaDon.Text = $"Tổng hóa đơn: {thongKe.TongHoaDon}";
            lblThongKeTongTien.Text = $"Tổng tiền: {thongKe.TongTien.ToString("N0")} VNĐ";
            lblThongKeTongGiam.Text = $"Tổng giảm giá: {thongKe.TongTienGiam.ToString("N0")} VNĐ";
            lblThongKeThanhTien.Text = $"Thành tiền: {thongKe.TongThanhTien.ToString("N0")} VNĐ";
            lblThongKeTongVe.Text = $"Tổng vé bán: {tongVe}";

            dgvThongKeLoaiVe.Rows.Clear();
            if (dgvThongKeLoaiVe.Columns.Count > 0)
            {
                dgvThongKeLoaiVe.Columns.Clear();
            }

            dgvThongKeLoaiVe.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "colMaLoaiVeThongKe", HeaderText = "Mã loại" },
                new DataGridViewTextBoxColumn { Name = "colTenLoaiVeThongKe", HeaderText = "Tên loại vé" },
                new DataGridViewTextBoxColumn { Name = "colSoVeThongKe", HeaderText = "Số vé bán" },
                new DataGridViewTextBoxColumn { Name = "colThanhTienThongKe", HeaderText = "Thành tiền" }
            });

            var danhSachLoaiVe = await hoaDonController.LayThongKeTheoLoaiVe();
            foreach (var muc in danhSachLoaiVe)
            {
                dgvThongKeLoaiVe.Rows.Add(
                    muc.MaLoaiVe,
                    muc.TenLoaiVe,
                    muc.SoVeDaBan,
                    muc.TongThanhTien.ToString("N0") + " VNĐ");
            }

            dgvThongKeLoaiVe.ClearSelection();
        }

        private Ve? LayVeDangChon()
        {
            if (dgvVe.CurrentRow == null || dgvVe.CurrentRow.Index < 0)
            {
                return null;
            }

            if (dgvVe.CurrentRow.Cells.Count < 9)
            {
                return null;
            }

            var veDangChon = dgvVe.CurrentRow.Tag as Ve;

            return new Ve
            {
                MaVe = Convert.ToInt32(dgvVe.CurrentRow.Cells[0].Value ?? 0),
                TenVe = dgvVe.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty,
                MaLoaiVe = Convert.ToInt32(dgvVe.CurrentRow.Cells[2].Value ?? 0),
                GiaVe = Convert.ToDecimal(dgvVe.CurrentRow.Cells[3].Value ?? 0),
                GiaNguoiLon = Convert.ToDecimal(dgvVe.CurrentRow.Cells[4].Value ?? 0),
                GiaTreEm = Convert.ToDecimal(dgvVe.CurrentRow.Cells[5].Value ?? 0),
                GiaNguoiCaoTuoi = Convert.ToDecimal(dgvVe.CurrentRow.Cells[6].Value ?? 0),
                SoLuong = Convert.ToInt32(dgvVe.CurrentRow.Cells[7].Value ?? 0),
                MoTa = dgvVe.CurrentRow.Cells[8].Value?.ToString(),
                ThongTinVe = veDangChon?.ThongTinVe,
                TrangThai = true
            };
        }

        private void dgvVe_ThongTinVe_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (dgvVe.Columns[e.ColumnIndex].Name != "colThongTinVe")
            {
                return;
            }

            var ve = dgvVe.Rows[e.RowIndex].Tag as Ve;
            if (ve == null)
            {
                return;
            }

            using var formThongTin = new frmThongTinVe(ve.TenVe, ve.ThongTinVe);
            formThongTin.ShowDialog();
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                return;
            }

            var hoTen = dgvNguoiDung.CurrentRow.Cells[2].Value?.ToString() ?? "";
            var taiKhoan = dgvNguoiDung.CurrentRow.Cells[1].Value?.ToString() ?? "";
            var email = dgvNguoiDung.CurrentRow.Cells[3].Value?.ToString() ?? "";
            var soDienThoai = dgvNguoiDung.CurrentRow.Cells[4].Value?.ToString() ?? "";
            var vaiTro = dgvNguoiDung.CurrentRow.Cells[5].Value?.ToString() ?? "";

            MessageBox.Show($"Họ tên: {hoTen}\nTài khoản: {taiKhoan}\nEmail: {email}\nSố điện thoại: {soDienThoai}\nVai trò: {vaiTro}",
                "Thông tin người dùng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (dgvNguoiDung.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvNguoiDung.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maNguoiDung))
            {
                return;
            }

            var taiKhoan = dgvNguoiDung.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty;
            using var formDatMatKhau = new frmDatMatKhauNguoiDung(maNguoiDung, taiKhoan);
            formDatMatKhau.ShowDialog();
        }


        private void btnMenuNguoiDung_Click(object sender, EventArgs e)
        {
            HienThiManHinhNguoiDung();
        }

        private void btnMenuVe_Click(object sender, EventArgs e)
        {
            HienThiManHinhVe();
        }

        private void btnMenuLoaiVe_Click(object sender, EventArgs e)
        {
            HienThiManHinhLoaiVe();
        }

        private void btnMenuVoucher_Click(object sender, EventArgs e)
        {
            HienThiManHinhVoucher();
        }

        private void btnMenuHoaDon_Click(object sender, EventArgs e)
        {
            HienThiManHinhHoaDon();
        }

        private void btnMenuThongKe_Click(object sender, EventArgs e)
        {
            HienThiManHinhThongKe();
        }

        private void btnDangXuatQuanLy_Click(object sender, EventArgs e)
        {
            var xacNhan = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            Session.DangXuat();
            Tag = "DangXuat";
            Close();
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvHoaDon.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maHoaDon))
            {
                return;
            }

            using var formChiTiet = new frmChiTietHoaDonQuanLy(maHoaDon);
            formChiTiet.ShowDialog();
        }

        private void dgvVe_SelectionChanged(object sender, EventArgs e)
        {
        }

        private async void btnThemVe_Click(object sender, EventArgs e)
        {
            var formNhapVe = new frmNhapVe(null);
            var ketQua = formNhapVe.ShowDialog();
            if (ketQua != DialogResult.OK || formNhapVe.VeHienTai == null)
            {
                return;
            }

            try
            {
                await veController.ThemVe(formNhapVe.VeHienTai);
                await TaiDanhSachVe();
                MessageBox.Show("Đã thêm vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnThemVoucher_Click(object sender, EventArgs e)
        {
            var formNhap = new frmNhapVoucher(null);
            if (formNhap.ShowDialog() != DialogResult.OK || formNhap.VoucherHienTai == null)
            {
                return;
            }

            try
            {
                var v = formNhap.VoucherHienTai.Value;
                await voucherController.ThemVoucher(v.MaGiamGia, v.TenVoucher, v.KieuGiamGia, v.GiaTriGiam, v.NgayBatDau, v.NgayKetThuc, v.SoLuong);
                await TaiDanhSachVoucher();
                MessageBox.Show("Đã thêm voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaVoucher_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvVoucher.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maVoucher))
            {
                return;
            }

            var voucher = (
                maVoucher,
                dgvVoucher.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty,
                dgvVoucher.CurrentRow.Cells[2].Value?.ToString() ?? string.Empty,
                dgvVoucher.CurrentRow.Cells[3].Value?.ToString() ?? "PhanTram",
                Convert.ToDecimal(dgvVoucher.CurrentRow.Cells[4].Value ?? 0),
                DateTime.Parse(dgvVoucher.CurrentRow.Cells[5].Value?.ToString() ?? DateTime.Today.ToString()),
                DateTime.Parse(dgvVoucher.CurrentRow.Cells[6].Value?.ToString() ?? DateTime.Today.ToString()),
                Convert.ToInt32(dgvVoucher.CurrentRow.Cells[7].Value ?? 0)
            );

            var formNhap = new frmNhapVoucher(voucher);
            if (formNhap.ShowDialog() != DialogResult.OK || formNhap.VoucherHienTai == null)
            {
                return;
            }

            try
            {
                var v = formNhap.VoucherHienTai.Value;
                await voucherController.SuaVoucher(maVoucher, v.MaGiamGia, v.TenVoucher, v.KieuGiamGia, v.GiaTriGiam, v.NgayBatDau, v.NgayKetThuc, v.SoLuong);
                await TaiDanhSachVoucher();
                MessageBox.Show("Đã cập nhật voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaVoucher_Click(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvVoucher.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maVoucher))
            {
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa voucher này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await voucherController.XoaVoucher(maVoucher);
                await TaiDanhSachVoucher();
                MessageBox.Show("Đã xóa voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaVe_Click(object sender, EventArgs e)
        {
            var veHienTai = LayVeDangChon();
            if (veHienTai == null)
            {
                return;
            }

            var formNhapVe = new frmNhapVe(veHienTai);
            var ketQua = formNhapVe.ShowDialog();
            if (ketQua != DialogResult.OK || formNhapVe.VeHienTai == null)
            {
                return;
            }

            try
            {
                formNhapVe.VeHienTai.MaVe = veHienTai.MaVe;
                await veController.SuaVe(formNhapVe.VeHienTai);
                await TaiDanhSachVe();
                MessageBox.Show("Đã cập nhật vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaVe_Click(object sender, EventArgs e)
        {
            if (dgvVe.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvVe.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maVe))
            {
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa vé này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await veController.XoaVe(maVe);
                await TaiDanhSachVe();
                MessageBox.Show("Đã xóa vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiVe_Click(object sender, EventArgs e)
        {
            dgvVe.ClearSelection();
        }

        private async void btnThemLoaiVe_Click(object sender, EventArgs e)
        {
            var formNhap = new frmNhapLoaiVe(null);
            var ketQua = formNhap.ShowDialog();
            if (ketQua != DialogResult.OK || formNhap.LoaiVeHienTai == null)
            {
                return;
            }

            try
            {
                await loaiVeController.ThemLoaiVe(formNhap.LoaiVeHienTai);
                await TaiDanhSachLoaiVeQuanLy();
                MessageBox.Show("Đã thêm loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSuaLoaiVe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiVe.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvLoaiVe.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maLoaiVe))
            {
                return;
            }

            var loaiVe = new LoaiVe
            {
                MaLoaiVe = maLoaiVe,
                TenLoaiVe = dgvLoaiVe.CurrentRow.Cells[1].Value?.ToString() ?? string.Empty,
                MoTa = dgvLoaiVe.CurrentRow.Cells[2].Value?.ToString(),
                TrangThai = true
            };

            var formNhap = new frmNhapLoaiVe(loaiVe);
            var ketQua = formNhap.ShowDialog();
            if (ketQua != DialogResult.OK || formNhap.LoaiVeHienTai == null)
            {
                return;
            }

            formNhap.LoaiVeHienTai.MaLoaiVe = maLoaiVe;
            try
            {
                await loaiVeController.SuaLoaiVe(formNhap.LoaiVeHienTai);
                await TaiDanhSachLoaiVeQuanLy();
                MessageBox.Show("Đã cập nhật loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaLoaiVe_Click(object sender, EventArgs e)
        {
            if (dgvLoaiVe.CurrentRow == null)
            {
                return;
            }

            var giaTri = dgvLoaiVe.CurrentRow.Cells[0].Value?.ToString();
            if (!int.TryParse(giaTri, out var maLoaiVe))
            {
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa loại vé này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await loaiVeController.XoaLoaiVe(maLoaiVe);
                await TaiDanhSachLoaiVeQuanLy();
                MessageBox.Show("Đã xóa loại vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
