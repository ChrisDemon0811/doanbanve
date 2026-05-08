using doanbanve.Models;

namespace doanbanve.Utils
{
    public static class GioHangTam
    {
        private static readonly Dictionary<int, List<MucGioHang>> danhSachTheoNguoiDung = new();

        public static IReadOnlyList<MucGioHang> LayDanhSach(int maNguoiDung)
        {
            if (!danhSachTheoNguoiDung.TryGetValue(maNguoiDung, out var danhSach))
            {
                danhSach = new List<MucGioHang>();
                danhSachTheoNguoiDung[maNguoiDung] = danhSach;
            }

            return danhSach.AsReadOnly();
        }

        public static void ThemMuc(int maNguoiDung, MucGioHang muc)
        {
            if (!danhSachTheoNguoiDung.TryGetValue(maNguoiDung, out var danhSach))
            {
                danhSach = new List<MucGioHang>();
                danhSachTheoNguoiDung[maNguoiDung] = danhSach;
            }

            danhSach.Add(muc);
        }

        public static void XoaMuc(int maNguoiDung, MucGioHang muc)
        {
            if (danhSachTheoNguoiDung.TryGetValue(maNguoiDung, out var danhSach))
            {
                danhSach.Remove(muc);
            }
        }

        public static void XoaTatCa(int maNguoiDung)
        {
            if (danhSachTheoNguoiDung.TryGetValue(maNguoiDung, out var danhSach))
            {
                danhSach.Clear();
            }
        }
    }
}
