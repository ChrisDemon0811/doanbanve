using doanbanve.Controllers;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmChatAI : Form
    {
        private readonly LichSuChatController lichSuController = new();
        private readonly TroLyAIController troLyAIController = new();

        public frmChatAI()
        {
            InitializeComponent();
            GiaoDienHelper.ApDungGiaoDien(this);
            GiaoDienHelper.ApDungNutChinh(btnGui);
            flpHoiThoai.BackColor = Color.FromArgb(250, 251, 253);
            lblTieuDe.Text = "Tr\u1ee3 l\u00fd t\u01b0 v\u1ea5n v\u00e9 AI";
            Text = "Tr\u1ee3 l\u00fd t\u01b0 v\u1ea5n v\u00e9";
            btnGui.Text = "G\u1eedi";
            AcceptButton = btnGui;
        }

        private async void frmChatAI_Load(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui l\u00f2ng \u0111\u0103ng nh\u1eadp \u0111\u1ec3 chat.", "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            await TaiLichSu();
        }

        private async Task TaiLichSu()
        {
            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            flpHoiThoai.Controls.Clear();
            var lichSu = await lichSuController.LayTheoNguoiDung(Session.NguoiDungHienTai.MaNguoiDung);
            foreach (var muc in lichSu.OrderBy(x => x.NgayTao))
            {
                ThemTinNhan("B\u1ea1n", muc.CauHoi, true);
                ThemTinNhan("AI", muc.TraLoi, false);
            }

            CuonXuongCuoi();
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            var cauHoi = txtCauHoi.Text.Trim();
            if (string.IsNullOrWhiteSpace(cauHoi))
            {
                MessageBox.Show("Vui l\u00f2ng nh\u1eadp c\u00e2u h\u1ecfi.", "Th\u00f4ng b\u00e1o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            btnGui.Enabled = false;
            txtCauHoi.Enabled = false;
            ThemTinNhan("B\u1ea1n", cauHoi, true);
            ThemTinNhan("AI", "\u0110ang t\u01b0 v\u1ea5n...", false);
            CuonXuongCuoi();
            txtCauHoi.Clear();

            try
            {
                var traLoi = await troLyAIController.TuVanVe(Session.NguoiDungHienTai.MaNguoiDung, cauHoi);
                await TaiLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kh\u00f4ng th\u1ec3 g\u1ecdi tr\u1ee3 l\u00fd AI: " + ex.Message, "L\u1ed7i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await TaiLichSu();
            }
            finally
            {
                btnGui.Enabled = true;
                txtCauHoi.Enabled = true;
                txtCauHoi.Focus();
            }
        }

        private void ThemTinNhan(string nguoiGui, string noiDung, bool laNguoiDung)
        {
            var noiDungHienThi = GiaoDienHelper.ChuanHoaNoiDungHienThi(noiDung, "\u0110ang c\u1eadp nh\u1eadt.");
            var doRongDong = Math.Max(320, flpHoiThoai.ClientSize.Width - flpHoiThoai.Padding.Horizontal - 28);
            var doRongBong = Math.Min(520, (int)(doRongDong * 0.78));
            var mauNen = laNguoiDung ? GiaoDienHelper.MauNhan : Color.FromArgb(238, 242, 247);
            var mauChu = laNguoiDung ? Color.White : GiaoDienHelper.MauChu;
            var mauTen = laNguoiDung ? Color.FromArgb(255, 241, 232) : GiaoDienHelper.MauNhanDam;

            using var fontNoiDung = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            var chieuCaoNoiDung = GiaoDienHelper.TinhChieuCaoVanBan(noiDungHienThi, fontNoiDung, doRongBong - 24, 28);
            var chieuCaoBong = chieuCaoNoiDung + 42;
            var dong = new Panel
            {
                Width = doRongDong,
                Height = chieuCaoBong + 8,
                Margin = new Padding(0, 0, 0, 6),
                BackColor = flpHoiThoai.BackColor
            };

            var bong = new Panel
            {
                Width = doRongBong,
                Height = chieuCaoBong,
                BackColor = mauNen,
                Location = new Point(laNguoiDung ? doRongDong - doRongBong : 0, 0),
                Padding = new Padding(12, 8, 12, 10)
            };

            var lblNguoiGui = new Label
            {
                Text = nguoiGui,
                AutoSize = false,
                Location = new Point(12, 8),
                Size = new Size(doRongBong - 24, 22),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = mauTen,
                TextAlign = laNguoiDung ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft
            };

            var lblNoiDung = new Label
            {
                Text = noiDungHienThi,
                AutoSize = false,
                Location = new Point(12, 32),
                Size = new Size(doRongBong - 24, chieuCaoNoiDung),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = mauChu,
                TextAlign = ContentAlignment.TopLeft,
                UseMnemonic = false
            };

            bong.Controls.Add(lblNguoiGui);
            bong.Controls.Add(lblNoiDung);
            dong.Controls.Add(bong);
            flpHoiThoai.Controls.Add(dong);
        }

        private void CuonXuongCuoi()
        {
            if (flpHoiThoai.Controls.Count == 0)
            {
                return;
            }

            flpHoiThoai.ScrollControlIntoView(flpHoiThoai.Controls[^1]);
        }
    }
}
