using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class BaoCaoController
    {
        private readonly BaoCaoDAO baoCaoDAO = new();

        public async Task<List<BaoCaoDoanhThu>> LayBaoCaoDoanhThu(DateTime? tuNgay, DateTime? denNgay, bool theoThang)
        {
            return await baoCaoDAO.LayBaoCaoDoanhThu(tuNgay, denNgay, theoThang);
        }

        public async Task<List<BaoCaoVeBanChayTheoLoai>> LayBaoCaoVeBanChayTheoLoai(DateTime? tuNgay, DateTime? denNgay)
        {
            return await baoCaoDAO.LayBaoCaoVeBanChayTheoLoai(tuNgay, denNgay);
        }
    }
}
