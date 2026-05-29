using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class CauHinhAIDAO
    {
        public async Task<CauHinhAI?> LayCauHinhHienTai()
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.Set<CauHinhAI>().AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task LuuCauHinh(CauHinhAI cauHinh)
        {
            using var db = DuLieuContext.TaoMoi();
            var duLieu = await db.Set<CauHinhAI>().FirstOrDefaultAsync();
            if (duLieu == null)
            {
                db.Set<CauHinhAI>().Add(cauHinh);
            }
            else
            {
                duLieu.NhaCungCap = cauHinh.NhaCungCap;
                duLieu.KhoaApi = cauHinh.KhoaApi;
                duLieu.MoHinh = cauHinh.MoHinh;
                duLieu.NhacLenh = cauHinh.NhacLenh;
            }

            await db.SaveChangesAsync();
        }
    }
}
