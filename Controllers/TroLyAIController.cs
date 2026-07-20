using doanbanve.Services;

namespace doanbanve.Controllers
{
    public class TroLyAIController
    {
        private readonly TroLyAIService troLyAIService = new();

        public Task<string> TuVanVe(int maNguoiDung, string cauHoi)
        {
            return troLyAIService.TuVanVe(maNguoiDung, cauHoi);
        }

        public Task<string?> PhanTichDoanhThuNeuCoThe(int maNguoiDung, string noiDungNhacLenh)
        {
            return troLyAIService.PhanTichDoanhThuNeuCoThe(maNguoiDung, noiDungNhacLenh);
        }
    }
}
