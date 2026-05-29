using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class LichSuChatDAO
    {
        public async Task<List<LichSuChat>> LayTheoNguoiDung(int maNguoiDung)
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.Set<LichSuChat>()
                .AsNoTracking()
                .Where(x => x.MaNguoiDung == maNguoiDung)
                .OrderByDescending(x => x.NgayTao)
                .ToListAsync();
        }

        public async Task ThemLichSu(LichSuChat lichSu)
        {
            using var db = DuLieuContext.TaoMoi();
            db.Set<LichSuChat>().Add(lichSu);
            await db.SaveChangesAsync();
        }
    }
}
