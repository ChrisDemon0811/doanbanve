using doanbanve.DAO;

namespace doanbanve.Controllers
{
    public class VoucherController
    {
        private readonly VoucherDAO voucherDAO = new();

        public async Task<List<(int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong, bool TrangThai)>> LayDanhSachVoucher()
        {
            return await voucherDAO.LayDanhSachVoucher();
        }

        public async Task<List<(int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong, bool TrangThai)>> LayVoucherConHieuLuc()
        {
            return await voucherDAO.LayVoucherConHieuLuc();
        }

        public decimal TinhTienGiam((int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong, bool TrangThai) voucher, decimal tongTien)
        {
            return voucherDAO.TinhTienGiam(voucher, tongTien);
        }

        public async Task<(bool CoVoucher, int MaVoucher, string MaGiamGia, string TenVoucher, decimal TienGiam)> LayVoucherTotNhat(decimal tongTien)
        {
            return await voucherDAO.LayVoucherTotNhat(tongTien);
        }

        public async Task ThemVoucher(string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            await voucherDAO.ThemVoucher(maGiamGia, tenVoucher, kieuGiamGia, giaTriGiam, ngayBatDau, ngayKetThuc, soLuong);
        }

        public async Task SuaVoucher(int maVoucher, string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            await voucherDAO.SuaVoucher(maVoucher, maGiamGia, tenVoucher, kieuGiamGia, giaTriGiam, ngayBatDau, ngayKetThuc, soLuong);
        }

        public async Task XoaVoucher(int maVoucher)
        {
            await voucherDAO.XoaVoucher(maVoucher);
        }
    }
}
