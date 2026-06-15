using doanbanve.DAO;
using doanbanve.Models;

namespace doanbanve.Controllers
{
    public class GioHangController
    {
        private readonly GioHangDAO gioHangDAO = new();
        private readonly ChiTietGioHangDAO chiTietGioHangDAO = new();
        private readonly VeDAO veDAO = new();

        public async Task<List<MucGioHang>> LayDanhSach(int maNguoiDung)
        {
            var maGioHang = await gioHangDAO.LayHoacTaoGioHang(maNguoiDung);
            return await chiTietGioHangDAO.LayDanhSach(maGioHang);
        }

        public async Task ThemHoacGopMuc(int maNguoiDung, MucGioHang mucMoi)
        {
            var maGioHang = await gioHangDAO.LayHoacTaoGioHang(maNguoiDung);
            mucMoi.MaGioHang = maGioHang;

            var mucCu = await chiTietGioHangDAO.LayTheoVeVaNgay(maGioHang, mucMoi.Ve.MaVe, mucMoi.NgaySuDung);
            if (mucCu != null)
            {
                mucCu.SoLuongNguoiLon += mucMoi.SoLuongNguoiLon;
                mucCu.SoLuongTreEm += mucMoi.SoLuongTreEm;
                mucCu.SoLuongNguoiCaoTuoi += mucMoi.SoLuongNguoiCaoTuoi;
                mucCu.Ve = mucMoi.Ve;
                await KiemTraSoLuongTheoNgay(maGioHang, mucCu, mucMoi.Ve.TenVe, mucCu.MaChiTietGioHang);
                await chiTietGioHangDAO.CapNhat(mucCu);
                return;
            }

            await KiemTraSoLuongTheoNgay(maGioHang, mucMoi, mucMoi.Ve.TenVe);
            await chiTietGioHangDAO.Them(mucMoi);
        }

        public async Task CapNhatMuc(int maNguoiDung, MucGioHang mucCapNhat)
        {
            var maGioHang = await gioHangDAO.LayHoacTaoGioHang(maNguoiDung);
            mucCapNhat.MaGioHang = maGioHang;
            await KiemTraSoLuongTheoNgay(maGioHang, mucCapNhat, mucCapNhat.Ve.TenVe, mucCapNhat.MaChiTietGioHang);
            await chiTietGioHangDAO.CapNhat(mucCapNhat);
        }

        public async Task XoaMuc(int maChiTietGioHang)
        {
            await chiTietGioHangDAO.Xoa(maChiTietGioHang);
        }

        private async Task KiemTraSoLuongTheoNgay(int maGioHang, MucGioHang muc, string? tenVe, int? maChiTietBoQua = null)
        {
            var soLuongMuonMua = muc.TinhTongSoLuong();
            if (soLuongMuonMua <= 0)
            {
                return;
            }

            var soLuongConLai = await veDAO.LaySoLuongConLaiTheoNgay(muc.Ve.MaVe, muc.NgaySuDung);
            var soLuongDangCoTrongGio = await chiTietGioHangDAO.LayTongSoLuongTheoVeVaNgay(
                maGioHang,
                muc.Ve.MaVe,
                muc.NgaySuDung,
                maChiTietBoQua);
            var tongSoLuongTrongGio = soLuongDangCoTrongGio + soLuongMuonMua;

            if (tongSoLuongTrongGio > soLuongConLai)
            {
                var tenHienThi = string.IsNullOrWhiteSpace(tenVe) ? muc.Ve.MaVe.ToString() : tenVe;
                throw new InvalidOperationException(
                    $"Vé '{tenHienThi}' ngày {muc.NgaySuDung:dd/MM/yyyy} chỉ còn {soLuongConLai} vé.");
            }
        }
    }
}
