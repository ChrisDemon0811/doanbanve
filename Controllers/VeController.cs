using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class VeController
    {
        private readonly VeDAO veDAO = new();

        public async Task<List<Ve>> LayDanhSachVe(int? maLoaiVe)
        {
            return await veDAO.LayDanhSachVe(maLoaiVe);
        }

        public async Task<List<Ve>> LayDanhSachVeQuanLy()
        {
            return await veDAO.LayDanhSachVeQuanLy();
        }

        public async Task ThemVe(Ve ve)
        {
            await veDAO.ThemVe(ve);
        }

        public async Task SuaVe(Ve ve)
        {
            await veDAO.SuaVe(ve);
        }

        public async Task XoaVe(int maVe)
        {
            await veDAO.XoaVe(maVe);
        }
    }
}
