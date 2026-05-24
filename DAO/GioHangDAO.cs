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

            try
            {
                db.GioHang.Add(gioHang);
                await db.SaveChangesAsync();
                return gioHang.MaGioHang;
            }
            catch (DbUpdateException)
            {
                // Truong hop chay dong thoi: user khac request vua tao gio hang xong.
                var maGioHangDaCo = await db.GioHang
                    .AsNoTracking()
                    .Where(x => x.MaNguoiDung == maNguoiDung)
                    .Select(x => (int?)x.MaGioHang)
                    .FirstOrDefaultAsync();

                if (maGioHangDaCo.HasValue)
                {
                    return maGioHangDaCo.Value;
                }

                throw;
            }
        }
    }
}
