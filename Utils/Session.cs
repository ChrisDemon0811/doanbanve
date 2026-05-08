using doanbanve.Models;

namespace doanbanve.Utils
{
    public static class Session
    {
        public static NguoiDung? NguoiDungHienTai { get; private set; }

        public static void DangNhap(NguoiDung nguoiDung)
        {
            NguoiDungHienTai = nguoiDung;
        }

        public static void DangXuat()
        {
            NguoiDungHienTai = null;
        }

        public static bool LaQuanLy()
        {
            return NguoiDungHienTai?.VaiTro == "QuanLy";
        }
    }
}
