namespace doanbanve.Utils
{
    public static class GiaoDienHelper
    {
        public static readonly Color MauNen = Color.FromArgb(247, 248, 250);
        public static readonly Color MauThe = Color.White;
        public static readonly Color MauVien = Color.FromArgb(224, 228, 235);
        public static readonly Color MauChu = Color.FromArgb(32, 38, 46);
        public static readonly Color MauChuPhu = Color.FromArgb(88, 96, 108);
        public static readonly Color MauNhan = Color.FromArgb(210, 85, 30);
        public static readonly Color MauNhanDam = Color.FromArgb(185, 70, 24);
        public static readonly Color MauChon = Color.FromArgb(232, 244, 255);

        public static readonly Font FontMacDinh = new("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font FontDam = new("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        public static readonly Font FontTieuDe = new("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);

        public static void ApDungGiaoDien(Control control)
        {
            control.ForeColor = MauChu;

            switch (control)
            {
                case Form form:
                    form.Font = FontMacDinh;
                    form.BackColor = MauNen;
                    break;
                case UserControl userControl:
                    userControl.Font = FontMacDinh;
                    userControl.BackColor = MauNen;
                    break;
                case FlowLayoutPanel flow:
                    flow.Font = FontMacDinh;
                    flow.BackColor = MauNen;
                    flow.Padding = flow.Padding == Padding.Empty ? new Padding(4) : flow.Padding;
                    break;
                case TabControl tab:
                    tab.Font = FontMacDinh;
                    tab.BackColor = MauNen;
                    break;
                case TabPage page:
                    page.Font = FontMacDinh;
                    page.BackColor = MauNen;
                    page.UseVisualStyleBackColor = false;
                    break;
                case Panel panel:
                    panel.BackColor = panel.BorderStyle == BorderStyle.FixedSingle ? MauThe : MauNen;
                    break;
                case GroupBox groupBox:
                    groupBox.Font = FontDam;
                    groupBox.ForeColor = MauChu;
                    break;
                case Button button:
                    ApDungNutPhu(button);
                    break;
                case TextBox textBox:
                    textBox.Font = FontMacDinh;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case RichTextBox richTextBox:
                    richTextBox.Font = FontMacDinh;
                    richTextBox.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case ComboBox comboBox:
                    comboBox.Font = FontMacDinh;
                    comboBox.FlatStyle = FlatStyle.Flat;
                    break;
                case DataGridView grid:
                    ApDungBang(grid);
                    break;
            }

            foreach (Control con in control.Controls)
            {
                ApDungGiaoDien(con);
            }
        }

        public static void ApDungThe(Panel panel)
        {
            panel.BackColor = MauThe;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Padding = panel.Padding == Padding.Empty ? new Padding(4) : panel.Padding;
        }

        public static void ApDungNutChinh(Button button)
        {
            DamBaoKichThuocNut(button);
            button.BackColor = MauNhan;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = FontDam;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        public static void ApDungNutPhu(Button button)
        {
            DamBaoKichThuocNut(button);
            button.BackColor = Color.White;
            button.ForeColor = MauChu;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = MauVien;
            button.FlatAppearance.BorderSize = 1;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        private static void DamBaoKichThuocNut(Button button)
        {
            if (button.Text is "+" or "-")
            {
                return;
            }

            var doRongToiThieu = button.Text.Length <= 4 ? 72 : 112;
            button.Size = new Size(Math.Max(button.Width, doRongToiThieu), Math.Max(button.Height, 30));
        }

        public static void ApDungNutMenu(Button button, bool dangChon = false)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(18, 0, 0, 0);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.BackColor = dangChon ? MauChon : Color.FromArgb(242, 244, 247);
            button.ForeColor = dangChon ? MauNhanDam : MauChu;
            button.Font = dangChon ? FontDam : FontMacDinh;
        }

        public static void ApDungBang(DataGridView bang)
        {
            bang.BackgroundColor = MauThe;
            bang.BorderStyle = BorderStyle.FixedSingle;
            bang.GridColor = MauVien;
            bang.EnableHeadersVisualStyles = false;
            bang.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(238, 241, 245);
            bang.ColumnHeadersDefaultCellStyle.ForeColor = MauChu;
            bang.ColumnHeadersDefaultCellStyle.Font = FontDam;
            bang.ColumnHeadersDefaultCellStyle.SelectionBackColor = bang.ColumnHeadersDefaultCellStyle.BackColor;
            bang.ColumnHeadersDefaultCellStyle.SelectionForeColor = bang.ColumnHeadersDefaultCellStyle.ForeColor;
            bang.DefaultCellStyle.BackColor = MauThe;
            bang.DefaultCellStyle.ForeColor = MauChu;
            bang.DefaultCellStyle.SelectionBackColor = MauChon;
            bang.DefaultCellStyle.SelectionForeColor = MauChu;
            bang.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 251, 252);
            bang.RowTemplate.Height = 30;
            bang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bang.MultiSelect = false;
            bang.RowHeadersVisible = false;
        }

        public static string DinhDangVaiTro(string? vaiTro)
        {
            return vaiTro switch
            {
                "QuanLy" => "Quản lý",
                "NguoiDung" => "Người dùng",
                _ when string.IsNullOrWhiteSpace(vaiTro) => "-",
                _ => vaiTro!
            };
        }

        public static string DinhDangThanhToan(string? thanhToan)
        {
            return thanhToan switch
            {
                "TheNganHang" => "Thẻ ngân hàng",
                "TheQuocTe" => "Thẻ tín dụng/Ghi nợ quốc tế",
                "ViDienTu" => "Ví điện tử",
                "Khac" => "Khác",
                _ when string.IsNullOrWhiteSpace(thanhToan) => "-",
                _ => thanhToan!
            };
        }

        public static string DinhDangTrangThaiHoaDon(string? trangThai)
        {
            return trangThai switch
            {
                "DaThanhToan" => "Đã thanh toán",
                "ChoThanhToan" => "Chờ thanh toán",
                "DaHuy" => "Đã hủy",
                "HoanTien" => "Hoàn tiền",
                _ when string.IsNullOrWhiteSpace(trangThai) => "-",
                _ => trangThai!
            };
        }

        public static string DinhDangTrangThai(bool trangThai)
        {
            return trangThai ? "Đang hoạt động" : "Ngừng hoạt động";
        }

        public static string DinhDangKieuGiamGia(string? kieuGiamGia)
        {
            return kieuGiamGia switch
            {
                "PhanTram" => "Phần trăm",
                "TienMat" => "Tiền mặt",
                _ when string.IsNullOrWhiteSpace(kieuGiamGia) => "-",
                _ => kieuGiamGia!
            };
        }
        public static string ChuanHoaNoiDungHienThi(string? noiDung, string macDinh = "")
        {
            var ketQua = string.IsNullOrWhiteSpace(noiDung) ? macDinh : noiDung.Trim();
            return ketQua
                .Replace("\\r\\n", Environment.NewLine)
                .Replace("\\n", Environment.NewLine)
                .Replace("\\r", Environment.NewLine);
        }

        public static int TinhChieuCaoVanBan(string? noiDung, Font font, int doRong, int chieuCaoToiThieu)
        {
            var vanBan = string.IsNullOrWhiteSpace(noiDung) ? " " : noiDung;
            var khungDo = new Size(Math.Max(1, doRong), int.MaxValue);
            var kichThuoc = TextRenderer.MeasureText(
                vanBan,
                font,
                khungDo,
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

            return Math.Max(chieuCaoToiThieu, kichThuoc.Height + 8);
        }
    }
}
