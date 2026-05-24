using doanbanve.Controllers;
using doanbanve.Models;

namespace doanbanve.Forms
{
    public partial class ucQuanLyVe : UserControl
    {
        private readonly VeController veController = new();
        private readonly LoaiVeController loaiVeController = new();
        private readonly Color mauNenMacDinh = Color.White;
        private readonly Color mauNenChon = Color.FromArgb(230, 243, 255);
        private Panel? theVeDangChon;
        private List<VeHienThi> danhSachVeHienThi = new();

        private sealed record VeHienThi(Ve Ve, string TenLoaiVe);

        public ucQuanLyVe()
        {
            InitializeComponent();
            flpDanhSachVe.SizeChanged += FlpDanhSachVe_SizeChanged;
        }

        public async Task TaiDuLieu()
        {
            var danhSachLoaiVe = await loaiVeController.LayDanhSachLoaiVeQuanLy();
            var mapLoaiVe = danhSachLoaiVe.ToDictionary(x => x.MaLoaiVe, x => x.TenLoaiVe);
            var danhSach = await veController.LayDanhSachVeQuanLy();

            danhSachVeHienThi = danhSach
                .Select(ve =>
                {
                    mapLoaiVe.TryGetValue(ve.MaLoaiVe, out var tenLoaiVe);
                    return new VeHienThi(ve, tenLoaiVe ?? ve.MaLoaiVe.ToString());
                })
                .ToList();

            HienThiDanhSachVe();
        }

        private void HienThiDanhSachVe()
        {
            flpDanhSachVe.SuspendLayout();
            flpDanhSachVe.Controls.Clear();
            theVeDangChon = null;

            var tuKhoa = txtTimKiemVe.Text.Trim();
            IEnumerable<VeHienThi> danhSachLoc = danhSachVeHienThi;
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                danhSachLoc = danhSachLoc.Where(x => KhopTuKhoaTimKiem(x, tuKhoa));
            }

            foreach (var muc in danhSachLoc)
            {
                flpDanhSachVe.Controls.Add(TaoTheVe(muc.Ve, muc.TenLoaiVe));
            }

            if (flpDanhSachVe.Controls.Count == 0)
            {
                flpDanhSachVe.Controls.Add(new Label
                {
                    Text = "Không tìm thấy vé phù hợp.",
                    AutoSize = true,
                    Margin = new Padding(12),
                    ForeColor = Color.FromArgb(90, 90, 90)
                });
            }

            flpDanhSachVe.ResumeLayout();
        }

        private static bool KhopTuKhoaTimKiem(VeHienThi muc, string tuKhoa)
        {
            return CoChua(muc.Ve.TenVe, tuKhoa)
                || CoChua(muc.TenLoaiVe, tuKhoa)
                || CoChua(muc.Ve.MoTa, tuKhoa)
                || CoChua(muc.Ve.ThongTinVe, tuKhoa);
        }

        private static bool CoChua(string? noiDung, string tuKhoa)
        {
            return !string.IsNullOrWhiteSpace(noiDung)
                && noiDung.Contains(tuKhoa, StringComparison.CurrentCultureIgnoreCase);
        }

        private void FlpDanhSachVe_SizeChanged(object? sender, EventArgs e)
        {
            foreach (Control control in flpDanhSachVe.Controls)
            {
                if (control is Panel theVe)
                {
                    theVe.Width = flpDanhSachVe.ClientSize.Width - flpDanhSachVe.Padding.Horizontal - 24;
                }
            }
        }

        private Panel TaoTheVe(Ve ve, string tenLoaiVe)
        {
            var theVe = new Panel
            {
                Width = flpDanhSachVe.ClientSize.Width - flpDanhSachVe.Padding.Horizontal - 24,
                Height = 200,
                BackColor = mauNenMacDinh,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(8),
                Tag = ve
            };

            var lblTenVe = new Label
            {
                Text = ve.TenVe,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(12, 12),
                AutoSize = true
            };

            var lblLoaiVe = new Label
            {
                Text = "Loại vé: " + tenLoaiVe,
                Location = new Point(12, 44),
                AutoSize = true
            };

            var lblGia = new Label
            {
                Text = "Giá vé: " + ve.GiaVe.ToString("N0") + " VNĐ",
                Location = new Point(12, 68),
                AutoSize = true
            };

            var lblGiaChiTiet = new Label
            {
                Text = $"NL: {ve.GiaNguoiLon:N0} (người lớn) | TE: {ve.GiaTreEm:N0} (trẻ em) | NCT: {ve.GiaNguoiCaoTuoi:N0} (người cao tuổi)",
                Location = new Point(12, 92),
                AutoSize = true
            };

            var lblSoLuong = new Label
            {
                Text = "Số lượng: " + ve.SoLuong,
                Location = new Point(12, 116),
                AutoSize = true
            };

            var lblMoTa = new Label
            {
                Text = string.IsNullOrWhiteSpace(ve.MoTa) ? "Mô tả: Đang cập nhật" : "Mô tả: " + ve.MoTa,
                Location = new Point(12, 140),
                AutoSize = false,
                Size = new Size(Math.Max(200, theVe.Width - 24), 40)
            };

            var btnThongTin = new Button
            {
                Text = "Xem thông tin",
                Size = new Size(140, 28)
            };
            btnThongTin.Location = new Point(theVe.Width - btnThongTin.Width - 12, (theVe.Height - btnThongTin.Height) / 2);
            btnThongTin.Click += (_, _) => MoThongTinVe(ve);

            theVe.Controls.Add(lblTenVe);
            theVe.Controls.Add(lblLoaiVe);
            theVe.Controls.Add(lblGia);
            theVe.Controls.Add(lblGiaChiTiet);
            theVe.Controls.Add(lblSoLuong);
            theVe.Controls.Add(lblMoTa);
            theVe.Controls.Add(btnThongTin);

            GanSuKienChonThe(theVe);
            return theVe;
        }

        private void GanSuKienChonThe(Control control)
        {
            control.Click += TheVe_Click;
            foreach (Control con in control.Controls)
            {
                con.Click += TheVe_Click;
            }
        }

        private void TheVe_Click(object? sender, EventArgs e)
        {
            var the = LayTheTuControl(sender as Control);
            if (the == null)
            {
                return;
            }

            if (theVeDangChon != null)
            {
                theVeDangChon.BackColor = mauNenMacDinh;
            }

            the.BackColor = mauNenChon;
            theVeDangChon = the;
        }

        private static Panel? LayTheTuControl(Control? control)
        {
            while (control != null && control is not Panel)
            {
                control = control.Parent;
            }

            return control as Panel;
        }

        private Ve? LayVeDangChon()
        {
            return theVeDangChon?.Tag as Ve;
        }

        private void MoThongTinVe(Ve ve)
        {
            using var formThongTin = new frmThongTinVe(ve);
            formThongTin.ShowDialog();
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
                await TaiDuLieu();
                MessageBox.Show("Đã thêm vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Vui lòng chọn vé cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                await TaiDuLieu();
                MessageBox.Show("Đã cập nhật vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoaVe_Click(object sender, EventArgs e)
        {
            var ve = LayVeDangChon();
            if (ve == null)
            {
                MessageBox.Show("Vui lòng chọn vé cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var xacNhan = MessageBox.Show("Bạn có chắc muốn xóa vé này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (xacNhan != DialogResult.Yes)
            {
                return;
            }

            try
            {
                await veController.XoaVe(ve.MaVe);
                await TaiDuLieu();
                MessageBox.Show("Đã xóa vé.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoiVe_Click(object sender, EventArgs e)
        {
            if (theVeDangChon != null)
            {
                theVeDangChon.BackColor = mauNenMacDinh;
            }

            theVeDangChon = null;
        }

        private void txtTimKiemVe_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSachVe();
        }

        private void btnXoaLocVe_Click(object sender, EventArgs e)
        {
            txtTimKiemVe.Clear();
            txtTimKiemVe.Focus();
        }
    }
}
