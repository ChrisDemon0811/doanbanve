using System.Drawing;

namespace doanbanve.Forms
{
    public partial class frmThongTinVe : Form
    {
        public frmThongTinVe(string tieuDe, string? thongTinVe)
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            Text = "Thông tin vé";
            lblTieuDe.Text = tieuDe;
            if (!string.IsNullOrWhiteSpace(thongTinVe) && LaRtf(thongTinVe))
            {
                rtbThongTinVe.Rtf = thongTinVe;
            }
            else
            {
                rtbThongTinVe.Text = string.IsNullOrWhiteSpace(thongTinVe)
                    ? "Đang cập nhật thông tin vé."
                    : doanbanve.Utils.GiaoDienHelper.ChuanHoaNoiDungHienThi(thongTinVe);
            }

            DatConTroThongTin();
        }

        public frmThongTinVe(Models.Ve ve)
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            Text = "Thông tin vé";
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
                ? "Đang cập nhật thông tin vé."
                : doanbanve.Utils.GiaoDienHelper.ChuanHoaNoiDungHienThi(ve.ThongTinVe);
            var moTa = doanbanve.Utils.GiaoDienHelper.ChuanHoaNoiDungHienThi(ve.MoTa, "Đang cập nhật.");

            return string.Join(Environment.NewLine, new[]
            {
                $"Mã vé: {ve.MaVe}",
                $"Tên vé: {ve.TenVe}",
                $"Mã loại vé: {ve.MaLoaiVe}",
                $"Giá vé: {ve.GiaVe.ToString("N0")} VN\u0110",
                $"Giá người lớn: {ve.GiaNguoiLon.ToString("N0")} VN\u0110",
                $"Giá trẻ em: {ve.GiaTreEm.ToString("N0")} VN\u0110",
                $"Giá người cao tuổi: {ve.GiaNguoiCaoTuoi.ToString("N0")} VN\u0110",
                $"Mô tả: {moTa}",
                "",
                "Thông tin vé:",
                thongTin
            });
        }
    }
}
