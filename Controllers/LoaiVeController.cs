using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class LoaiVeController
    {
        private readonly LoaiVeDAO loaiVeDAO = new();

        public async Task<List<LoaiVe>> LayDanhSachLoaiVe()
        {
            return await loaiVeDAO.LayDanhSachLoaiVe();
        }
    }
}
