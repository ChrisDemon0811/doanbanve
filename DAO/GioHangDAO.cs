using doanbanve.Data;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.DAO
{
    public class GioHangDAO
    {
        public async Task<int> LayHoacTaoGioHang(int maNguoiDung)
        {
            using var db = DuLieuContext.TaoMoi();
            var maGioHang = await db.GioHang
                .AsNoTracking()
                .Where(x => x.MaNguoiDung == maNguoiDung)
                .OrderByDescending(x => x.MaGioHang)
                .Select(x => (int?)x.MaGioHang)
                .FirstOrDefaultAsync();

            if (maGioHang.HasValue)
            {
                return maGioHang.Value;
            }

            var gioHang = new GioHangDuLieu
            {
                MaNguoiDung = maNguoiDung,
                NgayTao = DateTime.Now
            };

            db.GioHang.Add(gioHang);
            await db.SaveChangesAsync();
            return gioHang.MaGioHang;
        }
    }
}
