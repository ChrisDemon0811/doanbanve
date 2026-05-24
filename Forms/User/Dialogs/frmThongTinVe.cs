using System.Drawing;

namespace doanbanve.Forms
{
    public partial class frmThongTinVe : Form
    {
        public frmThongTinVe(string tieuDe, string? thongTinVe)
        {
            InitializeComponent();
            Text = "Thong tin ve";
            lblTieuDe.Text = tieuDe;
            if (!string.IsNullOrWhiteSpace(thongTinVe) && LaRtf(thongTinVe))
            {
                rtbThongTinVe.Rtf = thongTinVe;
            }
            else
            {
                rtbThongTinVe.Text = string.IsNullOrWhiteSpace(thongTinVe) ? "Dang cap nhat thong tin ve." : thongTinVe;
            }

            DatConTroThongTin();
        }

        public frmThongTinVe(Models.Ve ve)
        {
            InitializeComponent();
            Text = "Thong tin ve";
            lblTieuDe.Text = ve.TenVe;
            if (!string.IsNullOrWhiteSpace(ve.ThongTinVe) && LaRtf(ve.ThongTinVe))
            {
                rtbThongTinVe.Rtf = ve.ThongTinVe;
            }
            else
            {
                rtbThongTinVe.Text = TaoNoiDungThongTin(ve);
            }

            TaiAnhVe(ve.AnhVe);
            DatConTroThongTin();
        }

        private void DatConTroThongTin()
        {
            rtbThongTinVe.SelectionStart = 0;
            rtbThongTinVe.SelectionLength = 0;
            rtbThongTinVe.HideSelection = true;
            rtbThongTinVe.TabStop = false;
        }

        private void TaiAnhVe(string? duongDanAnh)
        {
            if (string.IsNullOrWhiteSpace(duongDanAnh))
            {
                picAnhVe.Image = null;
                return;
            }

            var duongDanTuyetDoi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image", duongDanAnh);
            if (File.Exists(duongDanTuyetDoi))
            {
                using var anh = Image.FromFile(duongDanTuyetDoi);
                picAnhVe.Image = new Bitmap(anh);
            }
            else
            {
                picAnhVe.Image = null;
            }
        }

        private static bool LaRtf(string giaTri)
        {
            return giaTri.TrimStart().StartsWith(@"{\rtf", StringComparison.OrdinalIgnoreCase);
        }

        private static string TaoNoiDungThongTin(Models.Ve ve)
        {
            var thongTin = string.IsNullOrWhiteSpace(ve.ThongTinVe)
                ? "Dang cap nhat thong tin ve."
                : ve.ThongTinVe;
            var moTa = string.IsNullOrWhiteSpace(ve.MoTa) ? "Dang cap nhat." : ve.MoTa;

            return string.Join(Environment.NewLine, new[]
            {
                $"Ma ve: {ve.MaVe}",
                $"Ten ve: {ve.TenVe}",
                $"Loai ve: {ve.MaLoaiVe}",
                $"Gia ve: {ve.GiaVe.ToString("N0")} VN\u0110",
                $"Gia nguoi lon: {ve.GiaNguoiLon.ToString("N0")} VN\u0110",
                $"Gia tre em: {ve.GiaTreEm.ToString("N0")} VN\u0110",
                $"Gia nguoi cao tuoi: {ve.GiaNguoiCaoTuoi.ToString("N0")} VN\u0110",
                $"Mo ta: {moTa}",
                "",
                "Thong tin ve:",
                thongTin
            });
        }
    }
}
