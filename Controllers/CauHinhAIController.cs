using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class CauHinhAIController
    {
        private readonly CauHinhAIDAO cauHinhDAO = new();

        public Task<CauHinhAI?> LayCauHinhHienTai()
        {
            return cauHinhDAO.LayCauHinhHienTai();
        }

        public Task LuuCauHinh(CauHinhAI cauHinh)
        {
            return cauHinhDAO.LuuCauHinh(cauHinh);
        }
    }
}
