using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Services;
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
        private readonly TroLyAIService troLyAIService = new();
        private DateTime? tuNgayThongKe;
        private DateTime? denNgayThongKe;
        private List<ThongKeDoanhThuNgay> danhSachBieuDo = new();
        private readonly Button btnAIPhanTichDoanhThu = new();
        private Button? btnReportDoanhThu;
        private Button? btnReportVeBanChay;

        public frmDashboardQuanLy()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            CauHinhGiaoDienQuanLy();
        }

        private async void frmDashboardQuanLy_Load(object sender, EventArgs e)
        {
            CauHinhBang(dgvThongKeLoaiVe);
            CaiDatThongKeMacDinh();
            await ucNguoiDung.TaiDuLieu();
            await ucQuanLyVe.TaiDuLieu();
            await ucPhanLoaiVe.TaiDuLieu();
            await ucQuanLyVoucher.TaiDuLieu();
            await ucQuanLyHoaDon.TaiDuLieu();
            await TaiThongKe();
            HienThiManHinhNguoiDung();
        }

        private void CauHinhGiaoDienQuanLy()
        {
            pnlMenu.BackColor = Color.FromArgb(242, 244, 247);
            pnlNoiDung.BackColor = GiaoDienHelper.MauNen;
            pnlBoLocThongKe.BackColor = Color.White;
            GiaoDienHelper.ApDungThe(pnlBieuDo);
            GiaoDienHelper.ApDungNutChinh(btnApDungThongKe);
            GiaoDienHelper.ApDungNutPhu(btnDangXuatQuanLy);
            ThemNutAIPhanTichDoanhThu();
            ThemNutBaoCao();

            foreach (var nut in LayDanhSachNutMenu())
            {
                GiaoDienHelper.ApDungNutMenu(nut);
            }
        }

        private void ThemNutBaoCao()
        {
            if (btnReportDoanhThu != null || btnReportVeBanChay != null)
            {
                return;
            }

            btnReportDoanhThu = new Button
            {
                Dock = DockStyle.Top,
                Height = 44,
                Text = "Report doanh thu",
                Name = "btnReportDoanhThu"
            };
            btnReportDoanhThu.Click += btnReportDoanhThu_Click;

            btnReportVeBanChay = new Button
            {
                Dock = DockStyle.Top,
                Height = 44,
                Text = "Report vé bán chạy",
                Name = "btnReportVeBanChay"
            };
            btnReportVeBanChay.Click += btnReportVeBanChay_Click;

            pnlMenu.Controls.Add(btnReportVeBanChay);
            pnlMenu.Controls.Add(btnReportDoanhThu);
            pnlMenu.Controls.SetChildIndex(btnReportDoanhThu, 1);
            pnlMenu.Controls.SetChildIndex(btnReportVeBanChay, 1);
        }

        private void ThemNutAIPhanTichDoanhThu()
        {
            btnAIPhanTichDoanhThu.Name = "btnAIPhanTichDoanhThu";
            btnAIPhanTichDoanhThu.Text = "AI phân tích doanh thu";
            btnAIPhanTichDoanhThu.Location = new Point(12, 276);
            btnAIPhanTichDoanhThu.Size = new Size(236, 36);
            btnAIPhanTichDoanhThu.Click += btnAIPhanTichDoanhThu_Click;
            GiaoDienHelper.ApDungNutPhu(btnAIPhanTichDoanhThu);

            if (!pnlThongKe.Controls.Contains(btnAIPhanTichDoanhThu))
            {
                pnlThongKe.Controls.Add(btnAIPhanTichDoanhThu);
            }

            btnAIPhanTichDoanhThu.BringToFront();
        }

        private void CaiDatThongKeMacDinh()
        {
            cboLoaiThongKe.Items.Clear();
            cboLoaiThongKe.Items.AddRange(new object[] { "Theo ngày", "Theo tháng", "Tùy chọn" });
            cboLoaiThongKe.SelectedIndex = 0;

            dtpTuNgay.ValueChanged -= DtpThongKe_ValueChanged;
            dtpDenNgay.ValueChanged -= DtpThongKe_ValueChanged;
            dtpTuNgay.ValueChanged += DtpThongKe_ValueChanged;
            dtpDenNgay.ValueChanged += DtpThongKe_ValueChanged;

            dtpTuNgay.Value = DateTime.Today.AddDays(-6);
            dtpDenNgay.Value = DateTime.Today;
            tuNgayThongKe = dtpTuNgay.Value.Date;
            denNgayThongKe = dtpDenNgay.Value.Date;
            CapNhatBoLocTheoLoai();
            KhoiTaoBieuDo();
        }

        private void CapNhatBoLocTheoLoai()
        {
            if (cboLoaiThongKe.SelectedIndex == 1)
            {
                dtpTuNgay.Format = DateTimePickerFormat.Custom;
                dtpTuNgay.CustomFormat = "MM/yyyy";
                dtpTuNgay.ShowUpDown = true;
                dtpDenNgay.Format = DateTimePickerFormat.Custom;
                dtpDenNgay.CustomFormat = "MM/yyyy";
                dtpDenNgay.ShowUpDown = true;
                return;
            }

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.ShowUpDown = false;
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.ShowUpDown = false;
            ApDungDinhDangNgayTiengViet(dtpTuNgay);
            ApDungDinhDangNgayTiengViet(dtpDenNgay);
        }

        private void DtpThongKe_ValueChanged(object? sender, EventArgs e)
        {
            if (cboLoaiThongKe.SelectedIndex == 1 || sender is not DateTimePicker picker)
            {
                return;
            }

            ApDungDinhDangNgayTiengViet(picker);
        }

        private void ApDungDinhDangNgayTiengViet(DateTimePicker picker)
        {
            var tenThu = picker.Value.DayOfWeek switch
            {
                DayOfWeek.Monday => "Th\u1ee9 hai",
                DayOfWeek.Tuesday => "Th\u1ee9 ba",
                DayOfWeek.Wednesday => "Th\u1ee9 t\u01b0",
                DayOfWeek.Thursday => "Th\u1ee9 n\u0103m",
                DayOfWeek.Friday => "Th\u1ee9 s\u00e1u",
                DayOfWeek.Saturday => "Th\u1ee9 b\u1ea3y",
                _ => "Ch\u1ee7 nh\u1eadt"
            };

            picker.CustomFormat = $"'{tenThu}', dd/MM/yyyy";
        }
        private void KhoiTaoBieuDo()
        {
            pnlBieuDo.Paint += pnlBieuDo_Paint;
            pnlBieuDo.Resize += pnlBieuDo_Resize;
        }

        private void HienThiManHinhNguoiDung()
        {
            CapNhatMenuDangChon(btnMenuNguoiDung);
            ucNguoiDung.Visible = true;
            ucQuanLyVe.Visible = false;
            ucPhanLoaiVe.Visible = false;
            ucQuanLyVoucher.Visible = false;
            ucQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhVe()
        {
            CapNhatMenuDangChon(btnMenuVe);
            ucNguoiDung.Visible = false;
            ucQuanLyVe.Visible = true;
            ucPhanLoaiVe.Visible = false;
            ucQuanLyVoucher.Visible = false;
            ucQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhLoaiVe()
        {
            CapNhatMenuDangChon(btnMenuLoaiVe);
            ucNguoiDung.Visible = false;
            ucQuanLyVe.Visible = false;
            ucPhanLoaiVe.Visible = true;
            ucQuanLyVoucher.Visible = false;
            ucQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhVoucher()
        {
            CapNhatMenuDangChon(btnMenuVoucher);
            ucNguoiDung.Visible = false;
            ucQuanLyVe.Visible = false;
            ucPhanLoaiVe.Visible = false;
            ucQuanLyVoucher.Visible = true;
            ucQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhHoaDon()
        {
            CapNhatMenuDangChon(btnMenuHoaDon);
            ucNguoiDung.Visible = false;
            ucQuanLyVe.Visible = false;
            ucPhanLoaiVe.Visible = false;
            ucQuanLyVoucher.Visible = false;
            ucQuanLyHoaDon.Visible = true;
            pnlThongKe.Visible = false;
        }

        private void HienThiManHinhThongKe()
        {
            CapNhatMenuDangChon(btnMenuThongKe);
            ucNguoiDung.Visible = false;
            ucQuanLyVe.Visible = false;
            ucPhanLoaiVe.Visible = false;
            ucQuanLyVoucher.Visible = false;
            ucQuanLyHoaDon.Visible = false;
            pnlThongKe.Visible = true;
        }

        private void btnMenuQuanLyAI_Click(object sender, EventArgs e)
        {
            using var formQuanLyAI = new Admin.Forms.frmQuanLyAI();
            formQuanLyAI.ShowDialog();
        }

        private IEnumerable<Button> LayDanhSachNutMenu()
        {
            return new[]
            {
                btnMenuNguoiDung,
                btnMenuVe,
                btnMenuLoaiVe,
                btnMenuQuanLyAI,
                btnMenuVoucher,
                btnMenuHoaDon,
                btnMenuThongKe,
                btnReportDoanhThu,
                btnReportVeBanChay
            }.Where(nut => nut != null)!;
        }

        private void CapNhatMenuDangChon(Button nutDangChon)
        {
            foreach (var nut in LayDanhSachNutMenu())
            {
                GiaoDienHelper.ApDungNutMenu(nut, nut == nutDangChon);
            }
        }

        private void CauHinhBang(DataGridView bang)
        {
            GiaoDienHelper.ApDungBang(bang);
        }


        private async Task TaiThongKe()
        {
            var thongKe = await hoaDonController.LayThongKeDuLieu(tuNgayThongKe, denNgayThongKe);
            var tongVe = await hoaDonController.LayTongVeDaBan(tuNgayThongKe, denNgayThongKe);
            var danhSachLoaiVe = await hoaDonController.LayThongKeTheoLoaiVe(tuNgayThongKe, denNgayThongKe);

            lblThongKeTongHoaDon.Text = $"T\u1ed5ng h\u00f3a \u0111\u01a1n: {thongKe.TongHoaDon}";
            lblThongKeTongTien.Text = $"T\u1ed5ng ti\u1ec1n: {thongKe.TongTien:N0} VN\u0110";
            lblThongKeTongGiam.Text = $"T\u1ed5ng gi\u1ea3m gi\u00e1: {thongKe.TongTienGiam:N0} VN\u0110";
            lblThongKeThanhTien.Text = $"Th\u00e0nh ti\u1ec1n: {thongKe.TongThanhTien:N0} VN\u0110";
            lblThongKeTongVe.Text = $"T\u1ed5ng v\u00e9 b\u00e1n: {tongVe}";

            var giaTriTrungBinh = thongKe.TongHoaDon > 0 ? thongKe.TongThanhTien / thongKe.TongHoaDon : 0;
            lblThongKeTrungBinhHoaDon.Text = $"TB/h\u00f3a \u0111\u01a1n: {giaTriTrungBinh:N0} VN\u0110";

            var loaiVeBanChay = danhSachLoaiVe
                .OrderByDescending(x => x.SoVeDaBan)
                .ThenByDescending(x => x.TongThanhTien)
                .FirstOrDefault();
            lblThongKeLoaiVeBanChay.Text = loaiVeBanChay == null
                ? "Lo\u1ea1i v\u00e9 b\u00e1n ch\u1ea1y: -"
                : $"Lo\u1ea1i v\u00e9 b\u00e1n ch\u1ea1y: {loaiVeBanChay.TenLoaiVe} ({loaiVeBanChay.SoVeDaBan} v\u00e9)";

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

            foreach (var muc in danhSachLoaiVe)
            {
                dgvThongKeLoaiVe.Rows.Add(
                    muc.MaLoaiVe,
                    muc.TenLoaiVe,
                    muc.SoVeDaBan,
                    muc.TongThanhTien.ToString("N0") + " VN\u0110");
            }

            dgvThongKeLoaiVe.ClearSelection();

            await TaiBieuDo();
        }

        private async Task TaiBieuDo()
        {
            if (cboLoaiThongKe.SelectedIndex == 1)
            {
                danhSachBieuDo = await hoaDonController.LayThongKeDoanhThuTheoThang(tuNgayThongKe, denNgayThongKe);
            }
            else
            {
                danhSachBieuDo = await hoaDonController.LayThongKeDoanhThuTheoNgay(tuNgayThongKe, denNgayThongKe);
            }

            pnlBieuDo.Invalidate();
        }

        private void pnlBieuDo_Resize(object? sender, EventArgs e)
        {
            pnlBieuDo.Invalidate();
        }

        private void pnlBieuDo_Paint(object? sender, PaintEventArgs e)
        {
            var danhSach = danhSachBieuDo ?? new List<ThongKeDoanhThuNgay>();
            var khuVuc = pnlBieuDo.ClientRectangle;
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (khuVuc.Width <= 0 || khuVuc.Height <= 0)
            {
                return;
            }

            using var butTruc = new Pen(Color.FromArgb(170, 170, 170), 1.2f);
            using var butLuoi = new Pen(Color.FromArgb(235, 235, 235), 1f);
            using var butChu = new SolidBrush(Color.FromArgb(70, 70, 70));
            using var butNenCot = new SolidBrush(Color.FromArgb(88, 138, 197));
            using var butVienCot = new Pen(Color.FromArgb(57, 107, 166), 1f);
            using var fontChu = new Font("Segoe UI", 8.5F);
            using var fontGiaTri = new Font("Segoe UI", 8F, FontStyle.Bold);

            var leTrai = 66;
            var leDuoi = 46;
            var leTren = 18;
            var lePhai = 18;

            var khungRong = khuVuc.Width - leTrai - lePhai;
            var khungCao = khuVuc.Height - leTren - leDuoi;
            if (khungRong <= 0 || khungCao <= 0)
            {
                return;
            }

            if (!danhSach.Any())
            {
                var text = "Ch\u01b0a c\u00f3 d\u1eef li\u1ec7u";
                var size = e.Graphics.MeasureString(text, fontChu);
                e.Graphics.DrawString(text, fontChu, butChu,
                    leTrai + (khungRong - size.Width) / 2,
                    leTren + (khungCao - size.Height) / 2);
                return;
            }

            var giaTriMax = danhSach.Max(x => x.TongThanhTien);
            if (giaTriMax <= 0)
            {
                giaTriMax = 1;
            }

            const int soMocY = 4;
            for (int i = 0; i <= soMocY; i++)
            {
                var tyLe = i / (float)soMocY;
                var y = leTren + khungCao - (tyLe * khungCao);
                e.Graphics.DrawLine(butLuoi, leTrai, y, leTrai + khungRong, y);

                var giaTriMoc = giaTriMax * (decimal)tyLe;
                var nhanY = DinhDangGiaTriTrucY(giaTriMoc);
                var sizeY = e.Graphics.MeasureString(nhanY, fontChu);
                e.Graphics.DrawString(nhanY, fontChu, butChu, leTrai - sizeY.Width - 6, y - sizeY.Height / 2);
            }

            e.Graphics.DrawLine(butTruc, leTrai, leTren, leTrai, leTren + khungCao);
            e.Graphics.DrawLine(butTruc, leTrai, leTren + khungCao, leTrai + khungRong, leTren + khungCao);

            var soCot = danhSach.Count;
            var beRongKhe = khungRong / (float)soCot;
            var doRongCot = MathF.Min(56f, beRongKhe * 0.65f);
            var buocNhanX = Math.Max(1, (int)Math.Ceiling(soCot / 12f));

            for (int i = 0; i < soCot; i++)
            {
                var muc = danhSach[i];
                var chieuCao = giaTriMax <= 0 ? 0f : (float)(muc.TongThanhTien / giaTriMax) * khungCao;
                var tamKhe = leTrai + (i * beRongKhe) + (beRongKhe / 2f);
                var x = tamKhe - (doRongCot / 2f);
                var y = leTren + khungCao - chieuCao;

                var hinhCot = new RectangleF(x, y, doRongCot, Math.Max(chieuCao, 1f));
                e.Graphics.FillRectangle(butNenCot, hinhCot);
                e.Graphics.DrawRectangle(butVienCot, x, y, doRongCot, Math.Max(chieuCao, 1f));

                var nhanGiaTri = DinhDangGiaTriTrucY(muc.TongThanhTien);
                var sizeGiaTri = e.Graphics.MeasureString(nhanGiaTri, fontGiaTri);
                var yGiaTri = Math.Max(leTren + 2, y - sizeGiaTri.Height - 2);
                e.Graphics.DrawString(nhanGiaTri, fontGiaTri, butChu, x + (doRongCot - sizeGiaTri.Width) / 2f, yGiaTri);

                if (i % buocNhanX != 0 && i != soCot - 1)
                {
                    continue;
                }

                var nhanX = cboLoaiThongKe.SelectedIndex == 1
                    ? muc.Ngay.ToString("MM/yyyy", CultureInfo.CurrentCulture)
                    : muc.Ngay.ToString("dd/MM", CultureInfo.CurrentCulture);
                var sizeX = e.Graphics.MeasureString(nhanX, fontChu);
                e.Graphics.DrawString(nhanX, fontChu, butChu, tamKhe - sizeX.Width / 2f, leTren + khungCao + 6);
            }
        }

        private static string DinhDangGiaTriTrucY(decimal giaTri)
        {
            if (giaTri >= 1_000_000_000m)
            {
                return $"{giaTri / 1_000_000_000m:0.#} T\u1ef7";
            }

            if (giaTri >= 1_000_000m)
            {
                return $"{giaTri / 1_000_000m:0.#} Tr";
            }

            if (giaTri >= 1_000m)
            {
                return $"{giaTri / 1_000m:0.#} K";
            }

            return giaTri.ToString("N0", CultureInfo.CurrentCulture);
        }

        private async void btnAIPhanTichDoanhThu_Click(object? sender, EventArgs e)
        {
            var tuNgay = tuNgayThongKe ?? dtpTuNgay.Value.Date;
            var denNgay = denNgayThongKe ?? dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnAIPhanTichDoanhThu.Enabled = false;
            var textCu = btnAIPhanTichDoanhThu.Text;
            btnAIPhanTichDoanhThu.Text = "AI đang phân tích...";

            try
            {
                var thongKe = await hoaDonController.LayThongKeDuLieu(tuNgay, denNgay);
                var tongVe = await hoaDonController.LayTongVeDaBan(tuNgay, denNgay);
                var danhSachDoanhThu = cboLoaiThongKe.SelectedIndex == 1
                    ? await hoaDonController.LayThongKeDoanhThuTheoThang(tuNgay, denNgay)
                    : await hoaDonController.LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);
                var danhSachLoaiVe = await hoaDonController.LayThongKeTheoLoaiVe(tuNgay, denNgay);

                if (thongKe.TongHoaDon <= 0 && tongVe <= 0 && danhSachDoanhThu.Count == 0 && danhSachLoaiVe.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu để phân tích", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var prompt = TaoPromptPhanTichDoanhThu(tuNgay, denNgay, thongKe, tongVe, danhSachDoanhThu, danhSachLoaiVe);
                var maNguoiDung = Session.NguoiDungHienTai?.MaNguoiDung ?? 0;
                var nhanXet = await troLyAIService.PhanTichDoanhThu(maNguoiDung, prompt);

                using var formPhanTich = new frmPhanTichDoanhThuAI(nhanXet);
                formPhanTich.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAIPhanTichDoanhThu.Text = textCu;
                btnAIPhanTichDoanhThu.Enabled = true;
            }
        }

        private string TaoPromptPhanTichDoanhThu(
            DateTime tuNgay,
            DateTime denNgay,
            ThongKeDuLieu thongKe,
            int tongVe,
            List<ThongKeDoanhThuNgay> danhSachDoanhThu,
            List<ThongKeTheoLoaiVe> danhSachLoaiVe)
        {
            var trungBinhHoaDon = thongKe.TongHoaDon > 0 ? thongKe.TongThanhTien / thongKe.TongHoaDon : 0;
            var duLieuDoanhThu = TaoDuLieuDoanhThuChoAI(danhSachDoanhThu);
            var duLieuLoaiVe = TaoDuLieuLoaiVeChoAI(danhSachLoaiVe);

            return $@"Bạn là trợ lý phân tích kinh doanh cho khu du lịch.
Chỉ phân tích dựa trên số liệu được cung cấp, không tự tạo thêm số liệu.
Không được tự bịa số liệu, doanh thu, loại vé hoặc gợi ý không dựa trên dữ liệu dưới đây.

THỜI GIAN:
Từ ngày: {tuNgay:dd/MM/yyyy}
Đến ngày: {denNgay:dd/MM/yyyy}

TỔNG QUAN:
- Tổng hóa đơn: {thongKe.TongHoaDon}
- Tổng tiền: {thongKe.TongTien:N0} VNĐ
- Tổng giảm giá: {thongKe.TongTienGiam:N0} VNĐ
- Thành tiền: {thongKe.TongThanhTien:N0} VNĐ
- Tổng vé bán: {tongVe}
- Trung bình mỗi hóa đơn: {trungBinhHoaDon:N0} VNĐ

DOANH THU THEO NGÀY/THÁNG:
{duLieuDoanhThu}

THỐNG KÊ THEO LOẠI VÉ:
{duLieuLoaiVe}

Hãy trả lời ngắn gọn bằng tiếng Việt theo 4 mục:
1. Nhận xét doanh thu
2. Loại vé bán tốt
3. Điểm cần chú ý
4. Gợi ý quản lý";
        }

        private string TaoDuLieuDoanhThuChoAI(List<ThongKeDoanhThuNgay> danhSachDoanhThu)
        {
            if (danhSachDoanhThu.Count == 0)
            {
                return "Không có dữ liệu doanh thu theo thời gian.";
            }

            var dinhDangNgay = cboLoaiThongKe.SelectedIndex == 1 ? "MM/yyyy" : "dd/MM/yyyy";
            var sb = new StringBuilder();
            foreach (var muc in danhSachDoanhThu)
            {
                sb.AppendLine($"- {muc.Ngay.ToString(dinhDangNgay, CultureInfo.CurrentCulture)}: {muc.TongThanhTien:N0} VNĐ");
            }

            return sb.ToString();
        }

        private static string TaoDuLieuLoaiVeChoAI(List<ThongKeTheoLoaiVe> danhSachLoaiVe)
        {
            if (danhSachLoaiVe.Count == 0)
            {
                return "Không có dữ liệu thống kê theo loại vé.";
            }

            var sb = new StringBuilder();
            foreach (var muc in danhSachLoaiVe.OrderByDescending(x => x.SoVeDaBan).ThenByDescending(x => x.TongThanhTien))
            {
                sb.AppendLine($"- Mã loại {muc.MaLoaiVe}, {muc.TenLoaiVe}: {muc.SoVeDaBan} vé, {muc.TongThanhTien:N0} VNĐ");
            }

            return sb.ToString();
        }

        private void btnApDungThongKe_Click(object sender, EventArgs e)
        {
            if (cboLoaiThongKe.SelectedIndex == 1)
            {
                var tuNgay = new DateTime(dtpTuNgay.Value.Year, dtpTuNgay.Value.Month, 1);
                var denNgay = new DateTime(dtpDenNgay.Value.Year, dtpDenNgay.Value.Month, 1).AddMonths(1).AddDays(-1);
                tuNgayThongKe = tuNgay;
                denNgayThongKe = denNgay;
            }
            else
            {
                tuNgayThongKe = dtpTuNgay.Value.Date;
                denNgayThongKe = dtpDenNgay.Value.Date;
            }

            if (tuNgayThongKe > denNgayThongKe)
            {
                MessageBox.Show("T\u1eeb ng\u00e0y kh\u00f4ng \u0111\u01b0\u1ee3c l\u1edbn h\u01a1n \u0111\u1ebfn ng\u00e0y.", "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ = TaiThongKe();
        }


        private void btnMenuNguoiDung_Click(object sender, EventArgs e)
        {
            HienThiManHinhNguoiDung();
            _ = ucNguoiDung.TaiDuLieu();
        }

        private void btnMenuVe_Click(object sender, EventArgs e)
        {
            HienThiManHinhVe();
            _ = ucQuanLyVe.TaiDuLieu();
        }

        private void btnMenuLoaiVe_Click(object sender, EventArgs e)
        {
            HienThiManHinhLoaiVe();
            _ = ucPhanLoaiVe.TaiDuLieu();
        }

        private void btnMenuVoucher_Click(object sender, EventArgs e)
        {
            HienThiManHinhVoucher();
            _ = ucQuanLyVoucher.TaiDuLieu();
        }

        private void btnMenuHoaDon_Click(object sender, EventArgs e)
        {
            HienThiManHinhHoaDon();
            _ = ucQuanLyHoaDon.TaiDuLieu();
        }

        private void btnMenuThongKe_Click(object sender, EventArgs e)
        {
            HienThiManHinhThongKe();
            _ = TaiThongKe();
        }

        private void btnReportDoanhThu_Click(object? sender, EventArgs e)
        {
            using var formReport = new frmReportDoanhThu();
            formReport.ShowDialog(this);
        }

        private void btnReportVeBanChay_Click(object? sender, EventArgs e)
        {
            using var formReport = new frmReportVeBanChayTheoLoai();
            formReport.ShowDialog(this);
        }

        private void cboLoaiThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatBoLocTheoLoai();
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

    }
}
