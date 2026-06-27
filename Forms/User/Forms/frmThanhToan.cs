using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmThanhToan : Form
    {
        private readonly GioHangController gioHangController = new();
        private readonly ThanhToanController thanhToanController = new();
        private List<MucGioHang> danhSachMuc = new();
        private decimal tienGiam;
        private int? maVoucher;

        public frmThanhToan()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutChinh(btnThanhToan);
            GiaoDienHelper.ApDungNutPhu(btnApDungVoucher);
        }

        private async void frmThanhToan_Load(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            lblNguoiDat.Text = Session.NguoiDungHienTai.HoTen;
            lblNgayDat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            cboThanhToan.SelectedIndex = 0;

            await TaiDanhSach();
        }

        private async Task TaiDanhSach()
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            danhSachMuc = await gioHangController.LayDanhSach(Session.NguoiDungHienTai.MaNguoiDung);
            pnlDanhSach.Controls.Clear();
            foreach (var muc in danhSachMuc)
            {
                pnlDanhSach.Controls.Add(TaoTheThanhToan(muc));
            }

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            var tongTien = danhSachMuc.Sum(m => m.TinhTongTien());
            lblTongTien.Text = tongTien.ToString("N0") + " VN\u0110";
            lblTienGiam.Text = tienGiam.ToString("N0") + " VN\u0110";
            lblThanhTien.Text = (tongTien - tienGiam).ToString("N0") + " VN\u0110";
        }

        private Panel TaoTheThanhToan(MucGioHang muc)
        {
            var doRongThe = Math.Max(820, pnlDanhSach.ClientSize.Width - pnlDanhSach.Padding.Horizontal - 32);
            var doRongNoiDung = Math.Max(470, doRongThe - 270);
            var fontTenVe = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            var tenVe = GiaoDienHelper.ChuanHoaNoiDungHienThi(muc.Ve.TenVe);
            var chieuCaoTen = GiaoDienHelper.TinhChieuCaoVanBan(tenVe, fontTenVe, doRongNoiDung, 32);
            var yNgaySuDung = 16 + chieuCaoTen + 8;
            var ySoLuongCon = yNgaySuDung + 24;
            var yNguoiLon = ySoLuongCon + 24;
            var yTreEm = yNguoiLon + 24;
            var yNut = Math.Max(yTreEm, yNgaySuDung + 56);
            var chieuCaoThe = yTreEm + 44;

            var theMuc = new Panel
            {
                Width = doRongThe,
                Height = chieuCaoThe,
                BackColor = Color.White,
                Margin = new Padding(8),
                BorderStyle = BorderStyle.FixedSingle
            };
            GiaoDienHelper.ApDungThe(theMuc);

            var lblTenVe = new Label
            {
                Text = tenVe,
                Font = fontTenVe,
                Location = new Point(16, 16),
                AutoSize = false,
                Size = new Size(doRongNoiDung, chieuCaoTen),
                UseMnemonic = false
            };

            var lblNgaySuDung = new Label
            {
                Text = "Ngày sử dụng: " + muc.NgaySuDung.ToString("dd/MM/yyyy"),
                Location = new Point(16, yNgaySuDung),
                AutoSize = true
            };

            var lblSoLuongCon = new Label
            {
                Text = $"Còn lại ngày {muc.NgaySuDung:dd/MM/yyyy}: {muc.Ve.SoLuong} vé",
                Location = new Point(16, ySoLuongCon),
                AutoSize = true
            };

            var lblNguoiLon = new Label
            {
                Text = $"Người lớn: {muc.SoLuongNguoiLon} x {muc.Ve.GiaNguoiLon.ToString("N0")} VNĐ",
                Location = new Point(16, yNguoiLon),
                AutoSize = true
            };

            var lblTreEm = new Label
            {
                Text = $"Trẻ em: {muc.SoLuongTreEm} x {muc.Ve.GiaTreEm.ToString("N0")} VNĐ",
                Location = new Point(16, yTreEm),
                AutoSize = true
            };

            var lblNguoiCaoTuoi = new Label
            {
                Text = $"Người cao tuổi: {muc.SoLuongNguoiCaoTuoi} x {muc.Ve.GiaNguoiCaoTuoi.ToString("N0")} VNĐ",
                Location = new Point(300, yTreEm),
                AutoSize = true
            };

            var lblGia = new Label
            {
                Text = muc.TinhTongTien().ToString("N0") + " VNĐ",
                ForeColor = GiaoDienHelper.MauNhan,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(doRongThe - 210, yNgaySuDung),
                AutoSize = false,
                Size = new Size(170, 28),
                TextAlign = ContentAlignment.MiddleRight
            };

            var btnThongTinVe = new Button
            {
                Text = "Thông tin vé",
                Location = new Point(doRongThe - 150, yNut),
                Size = new Size(110, 28)
            };
            GiaoDienHelper.ApDungNutPhu(btnThongTinVe);
            btnThongTinVe.Click += (_, _) => MoThongTinVe(muc.Ve);

            theMuc.Controls.Add(lblTenVe);
            theMuc.Controls.Add(lblNgaySuDung);
            theMuc.Controls.Add(lblSoLuongCon);
            theMuc.Controls.Add(lblNguoiLon);
            theMuc.Controls.Add(lblTreEm);
            theMuc.Controls.Add(lblNguoiCaoTuoi);
            theMuc.Controls.Add(lblGia);
            theMuc.Controls.Add(btnThongTinVe);
            return theMuc;
        }
        private void MoThongTinVe(Ve ve)
        {
            var formThongTin = new frmThongTinVe(ve);
            formThongTin.ShowDialog();
        }

        private async void btnApDungVoucher_Click(object sender, EventArgs e)
        {
            var maGiamGia = txtMaVoucher.Text.Trim();
            if (string.IsNullOrWhiteSpace(maGiamGia))
            {
                MessageBox.Show("Vui lòng nhập mã voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tongTien = danhSachMuc.Sum(m => m.TinhTongTien());
            var ketQua = await thanhToanController.ApDungVoucher(maGiamGia, tongTien);
            if (!ketQua.HopLe)
            {
                MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maVoucher = ketQua.MaVoucher;
            tienGiam = ketQua.TienGiam;
            CapNhatTongTien();
            MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            if (!danhSachMuc.Any())
            {
                MessageBox.Show("Giỏ hàng đang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var phuongThuc = LayGiaTriThanhToan();
                await thanhToanController.LuuHoaDon(
                    Session.NguoiDungHienTai.MaNguoiDung,
                    danhSachMuc,
                    maVoucher,
                    tienGiam,
                    phuongThuc);

                MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string LayGiaTriThanhToan()
        {
            return cboThanhToan.SelectedIndex switch
            {
                0 => "TheNganHang",
                1 => "TheQuocTe",
                2 => "ViDienTu",
                _ => "Khac"
            };
        }
    }
}

