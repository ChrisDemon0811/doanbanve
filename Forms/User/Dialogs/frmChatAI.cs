using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using doanbanve.Controllers;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.Forms
{
    public partial class frmChatAI : Form
    {
        private readonly CauHinhAIController cauHinhController = new();
        private readonly LichSuChatController lichSuController = new();

        public frmChatAI()
        {
            InitializeComponent();
            doanbanve.Utils.GiaoDienHelper.ApDungGiaoDien(this);
            doanbanve.Utils.GiaoDienHelper.ApDungNutChinh(btnGui);
        }

        private async void frmChatAI_Load(object sender, EventArgs e)
        {
            if (Session.NguoiDungHienTai == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để chat.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            rtbHoiThoai.Clear();
            var lichSu = await lichSuController.LayTheoNguoiDung(Session.NguoiDungHienTai.MaNguoiDung);
            foreach (var muc in lichSu.OrderBy(x => x.NgayTao))
            {
                rtbHoiThoai.AppendText($"Bạn: {muc.CauHoi}{Environment.NewLine}");
                rtbHoiThoai.AppendText($"AI: {muc.TraLoi}{Environment.NewLine}{Environment.NewLine}");
            }
        }

        private async void btnGui_Click(object sender, EventArgs e)
        {
            var cauHoi = txtCauHoi.Text.Trim();
            if (string.IsNullOrWhiteSpace(cauHoi))
            {
                MessageBox.Show("Vui lòng nhập câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Session.NguoiDungHienTai == null)
            {
                return;
            }

            try
            {
                var cauHinh = await cauHinhController.LayCauHinhHienTai();
                if (cauHinh == null)
                {
                    MessageBox.Show("Chưa cấu hình AI.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var traLoi = await GoiAI(cauHinh, cauHoi);
                rtbHoiThoai.AppendText($"Bạn: {cauHoi}{Environment.NewLine}");
                rtbHoiThoai.AppendText($"AI: {traLoi}{Environment.NewLine}{Environment.NewLine}");
                txtCauHoi.Clear();

                var lichSu = new LichSuChat
                {
                    MaNguoiDung = Session.NguoiDungHienTai.MaNguoiDung,
                    CauHoi = cauHoi,
                    TraLoi = traLoi,
                    NgayTao = DateTime.Now
                };
                await lichSuController.ThemLichSu(lichSu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static async Task<string> GoiAI(CauHinhAI cauHinh, string cauHoi)
        {
            try
            {
                using var httpClient = new HttpClient();
                var nhaCungCap = (cauHinh.NhaCungCap ?? string.Empty).Trim();
                var moHinh = (cauHinh.MoHinh ?? string.Empty).Trim();
                var nhacLenh = (cauHinh.NhacLenh ?? string.Empty).Trim();

                if (!string.Equals(nhaCungCap, "Gemini", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("Nhà cung cấp chỉ hỗ trợ Gemini. Vui lòng nhập 'Gemini'.");
                }

                // Goi API Gemini (Generative Language)
                var maMoHinh = moHinh.Replace(" ", "-").ToLowerInvariant();
                var url = $"https://generativelanguage.googleapis.com/v1beta/models/{maMoHinh}:generateContent?key={cauHinh.KhoaApi}";
                var payload = new
                {
                    systemInstruction = string.IsNullOrWhiteSpace(nhacLenh) ? null : new { parts = new[] { new { text = nhacLenh } } },
                    contents = new[]
                    {
                        new
                        {
                            role = "user",
                            parts = new[] { new { text = cauHoi } }
                        }
                    }
                };

                var noiDung = JsonSerializer.Serialize(payload, new JsonSerializerOptions { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull });
                using var content = new StringContent(noiDung, Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var traLoi = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();
                return traLoi ?? "Không nhận được phản hồi.";
            }
            catch (Exception ex)
            {
                throw new Exception($"Không gọi được AI: {ex.Message}");
            }
        }
    }
}
