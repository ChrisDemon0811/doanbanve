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

        public async Task<List<LoaiVe>> LayDanhSachLoaiVeQuanLy()
        {
            return await loaiVeDAO.LayDanhSachLoaiVeQuanLy();
        }

        public async Task ThemLoaiVe(LoaiVe loaiVe)
        {
            await loaiVeDAO.ThemLoaiVe(loaiVe);
        }

        public async Task SuaLoaiVe(LoaiVe loaiVe)
        {
            await loaiVeDAO.SuaLoaiVe(loaiVe);
        }

        public async Task XoaLoaiVe(int maLoaiVe)
        {
            await loaiVeDAO.XoaLoaiVe(maLoaiVe);
        }
    }
}
