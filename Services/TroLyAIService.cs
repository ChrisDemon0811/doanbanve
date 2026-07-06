using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using doanbanve.Controllers;
using doanbanve.DAO;
using doanbanve.Data;
using doanbanve.Models;
using doanbanve.Utils;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.Services
{
    public class TroLyAIService
    {
        private readonly CauHinhAIController cauHinhAIController = new();
        private readonly LichSuChatDAO lichSuChatDAO = new();

        public async Task<string> TuVanVe(int maNguoiDung, string cauHoi)
        {
            if (string.IsNullOrWhiteSpace(cauHoi))
            {
                return "Vui lòng nhập câu hỏi để mình tư vấn vé phù hợp.";
            }

            var cauHoiDaTrim = cauHoi.Trim();
            var cauHinh = await cauHinhAIController.LayCauHinhHienTai();
            if (cauHinh == null || string.IsNullOrWhiteSpace(cauHinh.KhoaApi) || string.IsNullOrWhiteSpace(cauHinh.MoHinh))
            {
                var thongBao = "Chưa cấu hình AI. Vui lòng liên hệ quản lý để thiết lập API key và mô hình.";
                await LuuLichSuNeuCo(maNguoiDung, cauHoiDaTrim, thongBao);
                return thongBao;
            }

            var duLieuVe = await TaoDuLieuVe();
            var duLieuVoucher = await TaoDuLieuVoucher();
            var prompt = TaoPrompt(cauHoiDaTrim, duLieuVe, duLieuVoucher, cauHinh.NhacLenh);
            string traLoi;

            try
            {
                traLoi = await GoiAI(cauHinh, prompt);
            }
            catch (Exception ex)
            {
                traLoi = "Xin lỗi, hiện tại trợ lý AI chưa thể phản hồi. Vui lòng thử lại sau. Chi tiết lỗi: " + ex.Message;
            }

            await LuuLichSuNeuCo(maNguoiDung, cauHoiDaTrim, traLoi);
            return traLoi;
        }

        public async Task<string> PhanTichDoanhThu(int maNguoiDung, string noiDungPrompt)
        {
            if (string.IsNullOrWhiteSpace(noiDungPrompt))
            {
                return "Chưa có dữ liệu để phân tích.";
            }

            var promptDaTrim = noiDungPrompt.Trim();
            var cauHinh = await cauHinhAIController.LayCauHinhHienTai();
            if (cauHinh == null || string.IsNullOrWhiteSpace(cauHinh.KhoaApi) || string.IsNullOrWhiteSpace(cauHinh.MoHinh))
            {
                var thongBao = "Chưa cấu hình AI. Vui lòng thiết lập API key và mô hình trước khi phân tích.";
                await LuuLichSuNeuCo(maNguoiDung, "Phân tích báo cáo doanh thu", thongBao);
                return thongBao;
            }

            string traLoi;
            try
            {
                traLoi = await GoiAI(cauHinh, promptDaTrim);
            }
            catch (Exception ex)
            {
                traLoi = "Xin lỗi, hiện tại AI chưa thể phân tích báo cáo. Chi tiết lỗi: " + ex.Message;
            }

            await LuuLichSuNeuCo(maNguoiDung, "Phân tích báo cáo doanh thu", traLoi);
            return traLoi;
        }

        private static async Task<string> TaoDuLieuVe()
        {
            using var db = DuLieuContext.TaoMoi();
            var danhSachVe = await (
                from ve in db.Ve.AsNoTracking()
                join loaiVe in db.LoaiVe.AsNoTracking() on ve.MaLoaiVe equals loaiVe.MaLoaiVe
                where ve.TrangThai && loaiVe.TrangThai
                orderby loaiVe.TenLoaiVe, ve.GiaNguoiLon, ve.TenVe
                select new
                {
                    ve.MaVe,
                    ve.TenVe,
                    loaiVe.TenLoaiVe,
                    ve.GiaNguoiLon,
                    ve.GiaTreEm,
                    ve.GiaNguoiCaoTuoi,
                    ve.SoLuong,
                    ve.MoTa,
                    ve.ThongTinVe
                })
                .ToListAsync();

            if (danhSachVe.Count == 0)
            {
                return "Hiện chưa có vé đang hoạt động.";
            }

            var sb = new StringBuilder();
            foreach (var ve in danhSachVe)
            {
                sb.AppendLine($"- Mã vé: {ve.MaVe}");
                sb.AppendLine($"  Tên vé: {ve.TenVe}");
                sb.AppendLine($"  Loại vé: {ve.TenLoaiVe}");
                sb.AppendLine($"  Giá người lớn: {ve.GiaNguoiLon:N0} VNĐ");
                sb.AppendLine($"  Giá trẻ em: {ve.GiaTreEm:N0} VNĐ");
                sb.AppendLine($"  Giá người cao tuổi: {ve.GiaNguoiCaoTuoi:N0} VNĐ");
                sb.AppendLine($"  Số lượng/ngày: {ve.SoLuong}");
                sb.AppendLine($"  Mô tả: {ChuanHoaNoiDung(ve.MoTa)}");
                sb.AppendLine($"  Thông tin vé: {ChuanHoaNoiDung(ve.ThongTinVe)}");
            }

            return sb.ToString();
        }

        private static async Task<string> TaoDuLieuVoucher()
        {
            using var db = DuLieuContext.TaoMoi();
            var homNay = DateTime.Today;
            var danhSachVoucher = await db.Voucher
                .AsNoTracking()
                .Where(x => x.TrangThai && x.SoLuong > 0 && x.NgayBatDau <= homNay && x.NgayKetThuc >= homNay)
                .OrderBy(x => x.NgayKetThuc)
                .Select(x => new
                {
                    x.MaGiamGia,
                    x.TenVoucher,
                    x.KieuGiamGia,
                    x.GiaTriGiam,
                    x.NgayBatDau,
                    x.NgayKetThuc,
                    x.SoLuong
                })
                .ToListAsync();

            if (danhSachVoucher.Count == 0)
            {
                return "Hiện chưa có voucher còn hiệu lực.";
            }

            var sb = new StringBuilder();
            foreach (var voucher in danhSachVoucher)
            {
                var giaTri = voucher.KieuGiamGia == "PhanTram"
                    ? $"{voucher.GiaTriGiam:N0}%"
                    : $"{voucher.GiaTriGiam:N0} VNĐ";

                sb.AppendLine($"- Mã voucher: {voucher.MaGiamGia}");
                sb.AppendLine($"  Tên voucher: {voucher.TenVoucher}");
                sb.AppendLine($"  Kiểu giảm giá: {voucher.KieuGiamGia}");
                sb.AppendLine($"  Giá trị giảm: {giaTri}");
                sb.AppendLine($"  Hiệu lực: {voucher.NgayBatDau:dd/MM/yyyy} - {voucher.NgayKetThuc:dd/MM/yyyy}");
                sb.AppendLine($"  Số lượng còn: {voucher.SoLuong}");
            }

            return sb.ToString();
        }

        private static string TaoPrompt(string cauHoi, string duLieuVe, string duLieuVoucher, string? nhacLenhThem)
        {
            var promptNen = @"Bạn là trợ lý tư vấn vé cho khu du lịch.
Chỉ sử dụng dữ liệu vé, loại vé và voucher dưới đây để trả lời.
Không được tự tạo vé, giá hoặc khuyến mãi không có trong dữ liệu.
Nếu khách hỏi ngoài phạm vi bán vé khu du lịch, hãy trả lời ngắn gọn rằng bạn chỉ hỗ trợ tư vấn vé.
Nếu thiếu thông tin thì hỏi lại khách.
Trả lời ngắn gọn, lịch sự, bằng tiếng Việt.

DỮ LIỆU VÉ:
{duLieuVe}

DỮ LIỆU VOUCHER:
{duLieuVoucher}

CÂU HỎI KHÁCH:
{cauHoi}";

            var prompt = promptNen
                .Replace("{duLieuVe}", duLieuVe)
                .Replace("{duLieuVoucher}", duLieuVoucher)
                .Replace("{cauHoi}", cauHoi);

            if (string.IsNullOrWhiteSpace(nhacLenhThem))
            {
                return prompt;
            }

            return nhacLenhThem.Trim() + Environment.NewLine + Environment.NewLine + prompt;
        }

        private static async Task<string> GoiAI(CauHinhAI cauHinh, string prompt)
        {
            var nhaCungCap = (cauHinh.NhaCungCap ?? string.Empty).Trim();
            if (string.Equals(nhaCungCap, "Gemini", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(nhaCungCap, "Google", StringComparison.OrdinalIgnoreCase))
            {
                return await GoiGemini(cauHinh, prompt);
            }

            if (string.Equals(nhaCungCap, "OpenAI", StringComparison.OrdinalIgnoreCase))
            {
                return await GoiOpenAI(cauHinh, prompt);
            }

            throw new InvalidOperationException("Nhà cung cấp AI chưa được hỗ trợ. Vui lòng dùng Gemini hoặc OpenAI.");
        }

        private static async Task<string> GoiGemini(CauHinhAI cauHinh, string prompt)
        {
            using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(45) };
            var maMoHinh = cauHinh.MoHinh.Trim().Replace(" ", "-").ToLowerInvariant();
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/{maMoHinh}:generateContent?key={cauHinh.KhoaApi}";
            var payload = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[] { new { text = prompt } }
                    }
                }
            };

            var noiDung = JsonSerializer.Serialize(payload);
            using var content = new StringContent(noiDung, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, content);
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Gemini API lỗi {(int)response.StatusCode}: {RutGon(json)}");
            }

            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("candidates", out var candidates) && candidates.GetArrayLength() > 0)
            {
                var text = candidates[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text.Trim();
                }
            }

            return "Không nhận được phản hồi từ AI.";
        }

        private static async Task<string> GoiOpenAI(CauHinhAI cauHinh, string prompt)
        {
            using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(45) };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", cauHinh.KhoaApi);

            var payload = new
            {
                model = cauHinh.MoHinh.Trim(),
                messages = new[]
                {
                    new { role = "user", content = prompt }
                }
            };

            var noiDung = JsonSerializer.Serialize(payload);
            using var content = new StringContent(noiDung, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"OpenAI API lỗi {(int)response.StatusCode}: {RutGon(json)}");
            }

            using var doc = JsonDocument.Parse(json);
            if (doc.RootElement.TryGetProperty("choices", out var choices) && choices.GetArrayLength() > 0)
            {
                var text = choices[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text.Trim();
                }
            }

            return "Không nhận được phản hồi từ AI.";
        }

        private async Task LuuLichSuNeuCo(int maNguoiDung, string cauHoi, string traLoi)
        {
            if (maNguoiDung <= 0)
            {
                return;
            }

            await lichSuChatDAO.ThemLichSu(new LichSuChat
            {
                MaNguoiDung = maNguoiDung,
                CauHoi = cauHoi,
                TraLoi = traLoi,
                NgayTao = DateTime.Now
            });
        }

        private static string ChuanHoaNoiDung(string? noiDung)
        {
            var text = GiaoDienHelper.ChuanHoaNoiDungHienThi(noiDung, "Đang cập nhật.");
            return text.Length > 900 ? text[..900] + "..." : text;
        }

        private static string RutGon(string noiDung)
        {
            if (string.IsNullOrWhiteSpace(noiDung))
            {
                return "Không có nội dung lỗi.";
            }

            return noiDung.Length > 500 ? noiDung[..500] + "..." : noiDung;
        }
    }
}
