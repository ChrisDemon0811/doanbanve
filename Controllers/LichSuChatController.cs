using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class LichSuChatController
    {
        private readonly LichSuChatDAO lichSuDAO = new();

        public Task<List<LichSuChat>> LayTheoNguoiDung(int maNguoiDung)
        {
            return lichSuDAO.LayTheoNguoiDung(maNguoiDung);
        }

        public Task ThemLichSu(LichSuChat lichSu)
        {
            return lichSuDAO.ThemLichSu(lichSu);
        }
    }
}
