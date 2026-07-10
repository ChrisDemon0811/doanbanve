using System.Drawing.Drawing2D;
using System.Globalization;
using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public class frmBaoCao : Form
    {
        private readonly BaoCaoController baoCaoController = new();
        private readonly HoaDonController hoaDonController = new();

        private readonly TabControl tabBaoCao = new();
        private readonly DataGridView dgvDanhSachVe = new();
        private readonly DataGridView dgvVeTheoLoai = new();
        private readonly DataGridView dgvHoaDon = new();
        private readonly DataGridView dgvChiTietHoaDon = new();
        private readonly DataGridView dgvDoanhThuTheoLoai = new();
        private readonly DataGridView dgvDoanhThuTheoThoiGian = new();

        private readonly Label lblTongHopVeTheoLoai = new();
        private readonly Label lblThongTinHoaDon = new();
        private readonly Label lblTongHoaDonDoanhThu = new();
        private readonly Label lblTongVeDoanhThu = new();
        private readonly Label lblTongTienDoanhThu = new();
        private readonly Label lblTongGiamDoanhThu = new();
        private readonly Label lblThanhTienDoanhThu = new();
        private readonly Label lblTrungBinhHoaDon = new();

        private readonly DateTimePicker dtpTuNgayDoanhThu = new();
        private readonly DateTimePicker dtpDenNgayDoanhThu = new();
        private readonly ComboBox cboKieuDoanhThu = new();
        private readonly Button btnXemDoanhThu = new();
        private readonly Panel pnlBieuDoDoanhThu = new();

        private List<ThongKeDoanhThuNgay> danhSachBieuDoDoanhThu = new();
        private bool dangTaiHoaDon;
        private bool hienThiDoanhThuTheoThang;

        public frmBaoCao()
        {
            KhoiTaoGiaoDien();
            GiaoDienHelper.ApDungGiaoDien(this);
            ApDungGiaoDienRieng();
        }

        private void KhoiTaoGiaoDien()
        {
            Text = "Báo cáo";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(1180, 760);
            Size = new Size(1240, 800);
            Load += frmBaoCao_Load;

            var pnlTieuDe = new Panel
            {
                Dock = DockStyle.Top,
                Height = 58,
                Padding = new Padding(18, 12, 18, 8),
                BackColor = Color.White
            };

            var lblTieuDe = new Label
            {
                Text = "BÁO CÁO QUẢN LÝ BÁN VÉ KHU DU LỊCH",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = GiaoDienHelper.MauChu,
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnlTieuDe.Controls.Add(lblTieuDe);

            tabBaoCao.Dock = DockStyle.Fill;
            tabBaoCao.TabPages.Add(TaoTabDanhSachVe());
            tabBaoCao.TabPages.Add(TaoTabVeTheoLoai());
            tabBaoCao.TabPages.Add(TaoTabHoaDon());
            tabBaoCao.TabPages.Add(TaoTabDoanhThu());

            Controls.Add(tabBaoCao);
            Controls.Add(pnlTieuDe);
        }

        private TabPage TaoTabDanhSachVe()
        {
            var tab = new TabPage("Danh sách vé");

            var pnlTren = new Panel
            {
                Dock = DockStyle.Top,
                Height = 54,
                Padding = new Padding(12),
                BackColor = GiaoDienHelper.MauNen
            };

            var lblMoTa = new Label
            {
                Text = "Danh sách toàn bộ vé đang bán trong hệ thống.",
                AutoSize = true,
                Location = new Point(12, 18)
            };

            var btnLamMoi = new Button
            {
                Text = "Làm mới",
                Name = "btnLamMoiDanhSachVe",
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(980, 11),
                Size = new Size(120, 32)
            };
            btnLamMoi.Click += async (_, _) => await TaiBaoCaoVe();

            pnlTren.Controls.Add(lblMoTa);
            pnlTren.Controls.Add(btnLamMoi);

            CauHinhBang(dgvDanhSachVe);
            dgvDanhSachVe.Dock = DockStyle.Fill;
            dgvDanhSachVe.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colMaVe", "Mã vé", 58),
                TaoCot("colTenVe", "Tên vé", 230),
                TaoCot("colTenLoaiVe", "Tên loại vé", 120),
                TaoCot("colGiaNguoiLon", "Giá người lớn", 95),
                TaoCot("colGiaTreEm", "Giá trẻ em", 90),
                TaoCot("colGiaNguoiCaoTuoi", "Giá người cao tuổi", 115),
                TaoCot("colSoLuongConLai", "Số lượng còn lại", 95),
                TaoCot("colTrangThai", "Trạng thái", 90)
            });

            tab.Controls.Add(dgvDanhSachVe);
            tab.Controls.Add(pnlTren);
            return tab;
        }

        private TabPage TaoTabVeTheoLoai()
        {
            var tab = new TabPage("Vé theo loại");

            var pnlTongHop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                Padding = new Padding(12),
                BackColor = GiaoDienHelper.MauNen
            };

            lblTongHopVeTheoLoai.Dock = DockStyle.Fill;
            lblTongHopVeTheoLoai.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblTongHopVeTheoLoai.TextAlign = ContentAlignment.MiddleLeft;

            pnlTongHop.Controls.Add(lblTongHopVeTheoLoai);

            CauHinhBang(dgvVeTheoLoai);
            dgvVeTheoLoai.Dock = DockStyle.Fill;
            dgvVeTheoLoai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVeTheoLoai.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvVeTheoLoai.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colNoiDung", "Nội dung", 140),
                TaoCot("colMaVeLoai", "Mã vé", 55),
                TaoCot("colTenVeLoai", "Tên vé", 260),
                TaoCot("colGiaNguoiLonLoai", "Giá người lớn", 90),
                TaoCot("colGiaTreEmLoai", "Giá trẻ em", 85),
                TaoCot("colGiaNguoiCaoTuoiLoai", "Giá người cao tuổi", 110),
                TaoCot("colSoLuongLoai", "Số lượng còn lại", 92),
                TaoCot("colGiaTriLoai", "Giá trị ước tính", 105)
            });

            tab.Controls.Add(dgvVeTheoLoai);
            tab.Controls.Add(pnlTongHop);
            return tab;
        }

        private TabPage TaoTabHoaDon()
        {
            var tab = new TabPage("Hóa đơn đặt vé");

            var split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                Padding = new Padding(8),
                Size = new Size(1100, 620)
            };
            split.SplitterDistance = 300;

            var pnlHoaDon = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 34, 0, 0) };
            var lblHoaDon = TaoNhanMuc("Danh sách hóa đơn");
            lblHoaDon.Location = new Point(0, 4);

            CauHinhBang(dgvHoaDon);
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.SelectionChanged += dgvHoaDon_SelectionChanged;
            dgvHoaDon.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colMaHoaDon", "Mã hóa đơn", 70),
                TaoCot("colNguoiDat", "Người đặt", 130),
                TaoCot("colNgayLap", "Ngày lập", 115),
                TaoCot("colThanhToan", "Thanh toán", 120),
                TaoCot("colTongTien", "Tổng tiền", 95),
                TaoCot("colTienGiam", "Tiền giảm", 90),
                TaoCot("colThanhTienHoaDon", "Thành tiền", 95),
                TaoCot("colTrangThaiHoaDon", "Trạng thái", 100)
            });

            pnlHoaDon.Controls.Add(dgvHoaDon);
            pnlHoaDon.Controls.Add(lblHoaDon);

            var pnlChiTiet = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 62, 0, 0) };
            var lblChiTiet = TaoNhanMuc("Chi tiết hóa đơn");
            lblChiTiet.Location = new Point(0, 4);

            lblThongTinHoaDon.Location = new Point(0, 34);
            lblThongTinHoaDon.AutoSize = true;
            lblThongTinHoaDon.ForeColor = GiaoDienHelper.MauChuPhu;

            CauHinhBang(dgvChiTietHoaDon);
            dgvChiTietHoaDon.Dock = DockStyle.Fill;
            dgvChiTietHoaDon.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colTenVeChiTiet", "Tên vé", 220),
                TaoCot("colNgaySuDung", "Ngày sử dụng", 90),
                TaoCot("colSoNguoiLon", "Người lớn", 70),
                TaoCot("colSoTreEm", "Trẻ em", 65),
                TaoCot("colSoNguoiCaoTuoi", "Người cao tuổi", 80),
                TaoCot("colDonGiaNguoiLon", "Đơn giá người lớn", 105),
                TaoCot("colDonGiaTreEm", "Đơn giá trẻ em", 95),
                TaoCot("colDonGiaNguoiCaoTuoi", "Đơn giá người cao tuổi", 120),
                TaoCot("colThanhTienChiTiet", "Thành tiền", 100)
            });

            pnlChiTiet.Controls.Add(dgvChiTietHoaDon);
            pnlChiTiet.Controls.Add(lblThongTinHoaDon);
            pnlChiTiet.Controls.Add(lblChiTiet);

            split.Panel1.Controls.Add(pnlHoaDon);
            split.Panel2.Controls.Add(pnlChiTiet);
            tab.Controls.Add(split);
            return tab;
        }

        private TabPage TaoTabDoanhThu()
        {
            var tab = new TabPage("Doanh thu bán vé");

            var pnlBoLoc = new Panel
            {
                Dock = DockStyle.Top,
                Height = 62,
                Padding = new Padding(12),
                BackColor = GiaoDienHelper.MauNen
            };

            var lblTuNgay = new Label
            {
                Text = "Từ ngày:",
                AutoSize = true,
                Location = new Point(12, 20)
            };

            dtpTuNgayDoanhThu.Name = "dtpTuNgayDoanhThu";
            dtpTuNgayDoanhThu.Format = DateTimePickerFormat.Custom;
            dtpTuNgayDoanhThu.CustomFormat = "dd/MM/yyyy";
            dtpTuNgayDoanhThu.Value = DateTime.Today.AddDays(-30);
            dtpTuNgayDoanhThu.Location = new Point(82, 16);
            dtpTuNgayDoanhThu.Size = new Size(140, 28);

            var lblDenNgay = new Label
            {
                Text = "Đến ngày:",
                AutoSize = true,
                Location = new Point(244, 20)
            };

            dtpDenNgayDoanhThu.Name = "dtpDenNgayDoanhThu";
            dtpDenNgayDoanhThu.Format = DateTimePickerFormat.Custom;
            dtpDenNgayDoanhThu.CustomFormat = "dd/MM/yyyy";
            dtpDenNgayDoanhThu.Value = DateTime.Today;
            dtpDenNgayDoanhThu.Location = new Point(324, 16);
            dtpDenNgayDoanhThu.Size = new Size(140, 28);

            var lblKieu = new Label
            {
                Text = "Hiển thị:",
                AutoSize = true,
                Location = new Point(486, 20)
            };

            cboKieuDoanhThu.Name = "cboKieuDoanhThu";
            cboKieuDoanhThu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKieuDoanhThu.Items.AddRange(new object[] { "Theo ngày", "Theo tháng" });
            cboKieuDoanhThu.SelectedIndex = 0;
            cboKieuDoanhThu.Location = new Point(560, 16);
            cboKieuDoanhThu.Size = new Size(140, 28);

            btnXemDoanhThu.Name = "btnXemDoanhThu";
            btnXemDoanhThu.Text = "Xem báo cáo";
            btnXemDoanhThu.Location = new Point(724, 14);
            btnXemDoanhThu.Size = new Size(132, 32);
            btnXemDoanhThu.Click += async (_, _) => await TaiBaoCaoDoanhThu();

            pnlBoLoc.Controls.Add(lblTuNgay);
            pnlBoLoc.Controls.Add(dtpTuNgayDoanhThu);
            pnlBoLoc.Controls.Add(lblDenNgay);
            pnlBoLoc.Controls.Add(dtpDenNgayDoanhThu);
            pnlBoLoc.Controls.Add(lblKieu);
            pnlBoLoc.Controls.Add(cboKieuDoanhThu);
            pnlBoLoc.Controls.Add(btnXemDoanhThu);

            var flpTongQuan = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 88,
                Padding = new Padding(8),
                WrapContents = false,
                AutoScroll = true,
                BackColor = GiaoDienHelper.MauNen
            };

            foreach (var nhan in new[]
            {
                lblTongHoaDonDoanhThu,
                lblTongVeDoanhThu,
                lblTongTienDoanhThu,
                lblTongGiamDoanhThu,
                lblThanhTienDoanhThu,
                lblTrungBinhHoaDon
            })
            {
                CauHinhNhanTongQuan(nhan);
                flpTongQuan.Controls.Add(nhan);
            }

            var splitChinh = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                Padding = new Padding(8),
                Size = new Size(1100, 520)
            };
            splitChinh.SplitterDistance = 300;

            var splitTren = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                Size = new Size(1100, 300)
            };
            splitTren.SplitterDistance = 520;

            var pnlTheoLoai = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 34, 8, 0) };
            var lblTheoLoai = TaoNhanMuc("Doanh thu theo loại vé");
            lblTheoLoai.Location = new Point(0, 4);

            CauHinhBang(dgvDoanhThuTheoLoai);
            dgvDoanhThuTheoLoai.Dock = DockStyle.Fill;
            dgvDoanhThuTheoLoai.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colTenLoaiDoanhThu", "Tên loại vé", 180),
                TaoCot("colSoVeDaBan", "Số vé đã bán", 90),
                TaoCot("colTongDoanhThuLoai", "Tổng doanh thu", 110)
            });

            pnlTheoLoai.Controls.Add(dgvDoanhThuTheoLoai);
            pnlTheoLoai.Controls.Add(lblTheoLoai);

            var pnlBieuDo = new Panel { Dock = DockStyle.Fill, Padding = new Padding(8, 34, 0, 0) };
            var lblBieuDo = TaoNhanMuc("Biểu đồ doanh thu");
            lblBieuDo.Location = new Point(8, 4);

            pnlBieuDoDoanhThu.Dock = DockStyle.Fill;
            pnlBieuDoDoanhThu.BackColor = Color.White;
            pnlBieuDoDoanhThu.BorderStyle = BorderStyle.FixedSingle;
            pnlBieuDoDoanhThu.Paint += pnlBieuDoDoanhThu_Paint;
            pnlBieuDoDoanhThu.Resize += (_, _) => pnlBieuDoDoanhThu.Invalidate();

            pnlBieuDo.Controls.Add(pnlBieuDoDoanhThu);
            pnlBieuDo.Controls.Add(lblBieuDo);

            splitTren.Panel1.Controls.Add(pnlTheoLoai);
            splitTren.Panel2.Controls.Add(pnlBieuDo);

            var pnlTheoThoiGian = new Panel { Dock = DockStyle.Fill, Padding = new Padding(0, 34, 0, 0) };
            var lblTheoThoiGian = TaoNhanMuc("Doanh thu theo ngày/tháng");
            lblTheoThoiGian.Location = new Point(0, 4);

            CauHinhBang(dgvDoanhThuTheoThoiGian);
            dgvDoanhThuTheoThoiGian.Dock = DockStyle.Fill;
            dgvDoanhThuTheoThoiGian.Columns.AddRange(new DataGridViewColumn[]
            {
                TaoCot("colThoiGianDoanhThu", "Thời gian", 120),
                TaoCot("colTongDoanhThuThoiGian", "Tổng doanh thu", 160)
            });

            pnlTheoThoiGian.Controls.Add(dgvDoanhThuTheoThoiGian);
            pnlTheoThoiGian.Controls.Add(lblTheoThoiGian);

            splitChinh.Panel1.Controls.Add(splitTren);
            splitChinh.Panel2.Controls.Add(pnlTheoThoiGian);

            tab.Controls.Add(splitChinh);
            tab.Controls.Add(flpTongQuan);
            tab.Controls.Add(pnlBoLoc);
            return tab;
        }

        private async void frmBaoCao_Load(object? sender, EventArgs e)
        {
            await TaiBaoCaoVe();
            await TaiBaoCaoHoaDon();
            await TaiBaoCaoDoanhThu();
        }

        private async Task TaiBaoCaoVe()
        {
            try
            {
                var danhSachVe = await baoCaoController.LayDanhSachVe();
                HienThiDanhSachVe(danhSachVe);
                HienThiVeTheoLoai(danhSachVe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSachVe(List<BaoCaoVeDTO> danhSachVe)
        {
            dgvDanhSachVe.Rows.Clear();
            foreach (var ve in danhSachVe)
            {
                dgvDanhSachVe.Rows.Add(
                    ve.MaVe,
                    ve.TenVe,
                    ve.TenLoaiVe,
                    DinhDangTien(ve.GiaNguoiLon),
                    DinhDangTien(ve.GiaTreEm),
                    DinhDangTien(ve.GiaNguoiCaoTuoi),
                    ve.SoLuongConLai,
                    ve.TrangThaiHienThi);
            }

            dgvDanhSachVe.ClearSelection();
        }

        private void HienThiVeTheoLoai(List<BaoCaoVeDTO> danhSachVe)
        {
            dgvVeTheoLoai.Rows.Clear();

            var tongSoVe = danhSachVe.Count;
            var tongSoLuong = danhSachVe.Sum(x => x.SoLuongConLai);
            var tongGiaTri = danhSachVe.Sum(x => x.GiaTriUocTinh);
            lblTongHopVeTheoLoai.Text =
                $"Tổng số vé: {tongSoVe}     Tổng số lượng còn lại: {tongSoLuong:N0}     Tổng giá trị vé ước tính: {DinhDangTien(tongGiaTri)}";

            foreach (var nhom in danhSachVe.GroupBy(x => new { x.MaLoaiVe, x.TenLoaiVe }).OrderBy(x => x.Key.TenLoaiVe))
            {
                var dongNhom = dgvVeTheoLoai.Rows[dgvVeTheoLoai.Rows.Add(
                    $"LOẠI VÉ: {nhom.Key.TenLoaiVe} ({nhom.Count()} vé)",
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty)];
                DinhDangDongNhom(dongNhom);

                foreach (var ve in nhom.OrderBy(x => x.TenVe))
                {
                    dgvVeTheoLoai.Rows.Add(
                        "Vé",
                        ve.MaVe,
                        ve.TenVe,
                        DinhDangTien(ve.GiaNguoiLon),
                        DinhDangTien(ve.GiaTreEm),
                        DinhDangTien(ve.GiaNguoiCaoTuoi),
                        ve.SoLuongConLai,
                        DinhDangTien(ve.GiaTriUocTinh));
                }

                var tongSoLuongLoai = nhom.Sum(x => x.SoLuongConLai);
                var tongGiaTriLoai = nhom.Sum(x => x.GiaTriUocTinh);
                var dongTong = dgvVeTheoLoai.Rows[dgvVeTheoLoai.Rows.Add(
                    $"Tổng loại {nhom.Key.TenLoaiVe}",
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    tongSoLuongLoai,
                    DinhDangTien(tongGiaTriLoai))];
                DinhDangDongTong(dongTong);
            }

            var dongTongTatCa = dgvVeTheoLoai.Rows[dgvVeTheoLoai.Rows.Add(
                "TỔNG TOÀN BỘ",
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                tongSoLuong,
                DinhDangTien(tongGiaTri))];
            DinhDangDongTong(dongTongTatCa);
            dgvVeTheoLoai.ClearSelection();
        }

        private async Task TaiBaoCaoHoaDon()
        {
            try
            {
                dangTaiHoaDon = true;
                dgvHoaDon.Rows.Clear();
                dgvChiTietHoaDon.Rows.Clear();
                lblThongTinHoaDon.Text = "Chọn một hóa đơn để xem chi tiết.";

                var danhSachHoaDon = await hoaDonController.LayDanhSachHoaDonQuanLy();
                foreach (var hoaDon in danhSachHoaDon)
                {
                    var chiSoDong = dgvHoaDon.Rows.Add(
                        hoaDon.MaHoaDon,
                        hoaDon.HoTenNguoiDat,
                        hoaDon.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                        GiaoDienHelper.DinhDangThanhToan(hoaDon.ThanhToan),
                        DinhDangTien(hoaDon.TongTien),
                        DinhDangTien(hoaDon.TienGiam),
                        DinhDangTien(hoaDon.ThanhTien),
                        GiaoDienHelper.DinhDangTrangThaiHoaDon(hoaDon.TrangThai));
                    dgvHoaDon.Rows[chiSoDong].Tag = hoaDon;
                }

                dangTaiHoaDon = false;
                dgvHoaDon.ClearSelection();

                if (dgvHoaDon.Rows.Count > 0)
                {
                    dgvHoaDon.Rows[0].Selected = true;
                    if (dgvHoaDon.Rows[0].Tag is ThongTinHoaDon hoaDonDau)
                    {
                        await TaiChiTietHoaDon(hoaDonDau);
                    }
                }
            }
            catch (Exception ex)
            {
                dangTaiHoaDon = false;
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvHoaDon_SelectionChanged(object? sender, EventArgs e)
        {
            if (dangTaiHoaDon)
            {
                return;
            }

            var hoaDon = LayHoaDonDangChon();
            if (hoaDon != null)
            {
                await TaiChiTietHoaDon(hoaDon);
            }
        }

        private ThongTinHoaDon? LayHoaDonDangChon()
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                return null;
            }

            return dgvHoaDon.SelectedRows[0].Tag as ThongTinHoaDon;
        }

        private async Task TaiChiTietHoaDon(ThongTinHoaDon hoaDon)
        {
            try
            {
                dgvChiTietHoaDon.Rows.Clear();
                lblThongTinHoaDon.Text =
                    $"Hóa đơn #{hoaDon.MaHoaDon} | Người đặt: {hoaDon.HoTenNguoiDat} | Ngày lập: {hoaDon.NgayLap:dd/MM/yyyy HH:mm} | Thành tiền: {DinhDangTien(hoaDon.ThanhTien)}";

                var danhSachChiTiet = await hoaDonController.LayChiTietHoaDon(hoaDon.MaHoaDon);
                foreach (var muc in danhSachChiTiet)
                {
                    dgvChiTietHoaDon.Rows.Add(
                        muc.Ve.TenVe,
                        muc.NgaySuDung.ToString("dd/MM/yyyy"),
                        muc.SoLuongNguoiLon,
                        muc.SoLuongTreEm,
                        muc.SoLuongNguoiCaoTuoi,
                        DinhDangTien(muc.Ve.GiaNguoiLon),
                        DinhDangTien(muc.Ve.GiaTreEm),
                        DinhDangTien(muc.Ve.GiaNguoiCaoTuoi),
                        DinhDangTien(muc.TinhTongTien()));
                }

                dgvChiTietHoaDon.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiBaoCaoDoanhThu()
        {
            if (dtpTuNgayDoanhThu.Value.Date > dtpDenNgayDoanhThu.Value.Date)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnXemDoanhThu.Enabled = false;
            var textCu = btnXemDoanhThu.Text;
            btnXemDoanhThu.Text = "Đang tải...";

            try
            {
                var tuNgay = dtpTuNgayDoanhThu.Value.Date;
                var denNgay = dtpDenNgayDoanhThu.Value.Date;
                hienThiDoanhThuTheoThang = cboKieuDoanhThu.SelectedIndex == 1;

                var thongKe = await hoaDonController.LayThongKeDuLieu(tuNgay, denNgay);
                var tongVe = await hoaDonController.LayTongVeDaBan(tuNgay, denNgay);
                var danhSachLoaiVe = await hoaDonController.LayThongKeTheoLoaiVe(tuNgay, denNgay);
                var danhSachDoanhThu = hienThiDoanhThuTheoThang
                    ? await hoaDonController.LayThongKeDoanhThuTheoThang(tuNgay, denNgay)
                    : await hoaDonController.LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);

                var trungBinhHoaDon = thongKe.TongHoaDon > 0 ? thongKe.TongThanhTien / thongKe.TongHoaDon : 0;
                lblTongHoaDonDoanhThu.Text = $"Tổng hóa đơn\n{thongKe.TongHoaDon:N0}";
                lblTongVeDoanhThu.Text = $"Tổng vé đã bán\n{tongVe:N0}";
                lblTongTienDoanhThu.Text = $"Tổng tiền\n{DinhDangTien(thongKe.TongTien)}";
                lblTongGiamDoanhThu.Text = $"Tổng tiền giảm\n{DinhDangTien(thongKe.TongTienGiam)}";
                lblThanhTienDoanhThu.Text = $"Doanh thu thực tế\n{DinhDangTien(thongKe.TongThanhTien)}";
                lblTrungBinhHoaDon.Text = $"TB/hóa đơn\n{DinhDangTien(trungBinhHoaDon)}";

                HienThiDoanhThuTheoLoai(danhSachLoaiVe);
                HienThiDoanhThuTheoThoiGian(danhSachDoanhThu);
                danhSachBieuDoDoanhThu = danhSachDoanhThu;
                pnlBieuDoDoanhThu.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnXemDoanhThu.Text = textCu;
                btnXemDoanhThu.Enabled = true;
            }
        }

        private void HienThiDoanhThuTheoLoai(List<ThongKeTheoLoaiVe> danhSachLoaiVe)
        {
            dgvDoanhThuTheoLoai.Rows.Clear();
            foreach (var muc in danhSachLoaiVe.OrderByDescending(x => x.TongThanhTien))
            {
                dgvDoanhThuTheoLoai.Rows.Add(
                    muc.TenLoaiVe,
                    muc.SoVeDaBan.ToString("N0"),
                    DinhDangTien(muc.TongThanhTien));
            }

            dgvDoanhThuTheoLoai.ClearSelection();
        }

        private void HienThiDoanhThuTheoThoiGian(List<ThongKeDoanhThuNgay> danhSachDoanhThu)
        {
            dgvDoanhThuTheoThoiGian.Rows.Clear();
            var dinhDangNgay = hienThiDoanhThuTheoThang ? "MM/yyyy" : "dd/MM/yyyy";
            foreach (var muc in danhSachDoanhThu)
            {
                dgvDoanhThuTheoThoiGian.Rows.Add(
                    muc.Ngay.ToString(dinhDangNgay, CultureInfo.CurrentCulture),
                    DinhDangTien(muc.TongThanhTien));
            }

            dgvDoanhThuTheoThoiGian.ClearSelection();
        }

        private void pnlBieuDoDoanhThu_Paint(object? sender, PaintEventArgs e)
        {
            var danhSach = danhSachBieuDoDoanhThu;
            var khuVuc = pnlBieuDoDoanhThu.ClientRectangle;
            e.Graphics.Clear(Color.White);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (khuVuc.Width <= 0 || khuVuc.Height <= 0)
            {
                return;
            }

            using var fontChu = new Font("Segoe UI", 8.5F);
            using var fontDam = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            using var butChu = new SolidBrush(GiaoDienHelper.MauChuPhu);

            if (danhSach.Count == 0)
            {
                var text = "Chưa có dữ liệu doanh thu";
                var size = e.Graphics.MeasureString(text, fontChu);
                e.Graphics.DrawString(text, fontChu, butChu, (khuVuc.Width - size.Width) / 2, (khuVuc.Height - size.Height) / 2);
                return;
            }

            var leTrai = 66;
            var lePhai = 18;
            var leTren = 18;
            var leDuoi = 46;
            var khungRong = khuVuc.Width - leTrai - lePhai;
            var khungCao = khuVuc.Height - leTren - leDuoi;
            if (khungRong <= 0 || khungCao <= 0)
            {
                return;
            }

            var giaTriMax = danhSach.Max(x => x.TongThanhTien);
            if (giaTriMax <= 0)
            {
                giaTriMax = 1;
            }

            using var butCot = new SolidBrush(Color.FromArgb(88, 138, 197));
            using var butCotDam = new Pen(Color.FromArgb(57, 107, 166), 1f);
            using var butTruc = new Pen(Color.FromArgb(170, 170, 170), 1.2f);
            using var butLuoi = new Pen(Color.FromArgb(235, 235, 235), 1f);

            const int soMocY = 4;
            for (var i = 0; i <= soMocY; i++)
            {
                var tyLe = i / (float)soMocY;
                var y = leTren + khungCao - (tyLe * khungCao);
                e.Graphics.DrawLine(butLuoi, leTrai, y, leTrai + khungRong, y);

                var nhanY = DinhDangGiaTriRutGon(giaTriMax * (decimal)tyLe);
                var sizeY = e.Graphics.MeasureString(nhanY, fontChu);
                e.Graphics.DrawString(nhanY, fontChu, butChu, leTrai - sizeY.Width - 6, y - sizeY.Height / 2);
            }

            e.Graphics.DrawLine(butTruc, leTrai, leTren, leTrai, leTren + khungCao);
            e.Graphics.DrawLine(butTruc, leTrai, leTren + khungCao, leTrai + khungRong, leTren + khungCao);

            var soCot = danhSach.Count;
            var beRongKhe = khungRong / (float)soCot;
            var doRongCot = MathF.Min(54f, beRongKhe * 0.62f);
            var buocNhanX = Math.Max(1, (int)Math.Ceiling(soCot / 10f));

            for (var i = 0; i < soCot; i++)
            {
                var muc = danhSach[i];
                var chieuCao = (float)(muc.TongThanhTien / giaTriMax) * khungCao;
                var tamKhe = leTrai + (i * beRongKhe) + (beRongKhe / 2f);
                var x = tamKhe - (doRongCot / 2f);
                var y = leTren + khungCao - chieuCao;
                var hinhCot = new RectangleF(x, y, doRongCot, Math.Max(chieuCao, 1f));

                e.Graphics.FillRectangle(butCot, hinhCot);
                e.Graphics.DrawRectangle(butCotDam, x, y, doRongCot, Math.Max(chieuCao, 1f));

                if (i % buocNhanX != 0 && i != soCot - 1)
                {
                    continue;
                }

                var dinhDangNgay = hienThiDoanhThuTheoThang ? "MM/yyyy" : "dd/MM";
                var nhanX = muc.Ngay.ToString(dinhDangNgay, CultureInfo.CurrentCulture);
                var sizeX = e.Graphics.MeasureString(nhanX, fontChu);
                e.Graphics.DrawString(nhanX, fontChu, butChu, tamKhe - sizeX.Width / 2f, leTren + khungCao + 8);

                var nhanGiaTri = DinhDangGiaTriRutGon(muc.TongThanhTien);
                var sizeGiaTri = e.Graphics.MeasureString(nhanGiaTri, fontDam);
                var yGiaTri = Math.Max(leTren + 2, y - sizeGiaTri.Height - 3);
                e.Graphics.DrawString(nhanGiaTri, fontDam, butChu, x + (doRongCot - sizeGiaTri.Width) / 2f, yGiaTri);
            }
        }

        private void ApDungGiaoDienRieng()
        {
            foreach (var bang in new[]
            {
                dgvDanhSachVe,
                dgvVeTheoLoai,
                dgvHoaDon,
                dgvChiTietHoaDon,
                dgvDoanhThuTheoLoai,
                dgvDoanhThuTheoThoiGian
            })
            {
                GiaoDienHelper.ApDungBang(bang);
            }

            foreach (var nut in Controls.OfType<Button>())
            {
                GiaoDienHelper.ApDungNutPhu(nut);
            }

            GiaoDienHelper.ApDungNutChinh(btnXemDoanhThu);
        }

        private static void CauHinhBang(DataGridView bang)
        {
            bang.AllowUserToAddRows = false;
            bang.AllowUserToDeleteRows = false;
            bang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bang.BackgroundColor = Color.White;
            bang.ReadOnly = true;
            bang.RowHeadersVisible = false;
            bang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bang.MultiSelect = false;
            bang.AutoGenerateColumns = false;
            bang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        private static DataGridViewTextBoxColumn TaoCot(string tenCot, string tieuDe, int doRong)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = tenCot,
                HeaderText = tieuDe,
                FillWeight = doRong,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        private static Label TaoNhanMuc(string noiDung)
        {
            return new Label
            {
                Text = noiDung,
                AutoSize = true,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = GiaoDienHelper.MauChu
            };
        }

        private static void CauHinhNhanTongQuan(Label nhan)
        {
            nhan.Width = 180;
            nhan.Height = 62;
            nhan.Margin = new Padding(6);
            nhan.Padding = new Padding(10, 8, 10, 8);
            nhan.BackColor = Color.White;
            nhan.BorderStyle = BorderStyle.FixedSingle;
            nhan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            nhan.TextAlign = ContentAlignment.MiddleLeft;
        }

        private static void DinhDangDongNhom(DataGridViewRow dong)
        {
            dong.DefaultCellStyle.BackColor = Color.FromArgb(238, 241, 245);
            dong.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            dong.DefaultCellStyle.ForeColor = GiaoDienHelper.MauChu;
        }

        private static void DinhDangDongTong(DataGridViewRow dong)
        {
            dong.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 240);
            dong.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            dong.DefaultCellStyle.ForeColor = GiaoDienHelper.MauNhanDam;
        }

        private static string DinhDangTien(decimal giaTri)
        {
            return giaTri.ToString("N0", CultureInfo.CurrentCulture) + " VNĐ";
        }

        private static string DinhDangGiaTriRutGon(decimal giaTri)
        {
            if (giaTri >= 1_000_000_000m)
            {
                return $"{giaTri / 1_000_000_000m:0.#} Tỷ";
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
    }
}
