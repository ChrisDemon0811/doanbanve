using Microsoft.Data.SqlClient;
using doanbanve.Utils;

namespace doanbanve.DAO
{
    public class VoucherDAO
    {
        public async Task<(bool HopLe, int? MaVoucher, decimal TienGiam, string ThongBao)> KiemTraVoucher(string maGiamGia, decimal tongTien)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaVoucher, KieuGiamGia, GiaTriGiam, NgayBatDau, NgayKetThuc, SoLuong, TrangThai
                                    FROM Voucher
                                    WHERE MaGiamGia = @MaGiamGia";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaGiamGia", maGiamGia);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            if (!await doc.ReadAsync())
            {
                return (false, null, 0, "Mã voucher không tồn tại.");
            }

            var maVoucher = doc.GetInt32(0);
            var kieuGiamGia = doc.GetString(1);
            var giaTriGiam = doc.GetDecimal(2);
            var ngayBatDau = doc.GetDateTime(3);
            var ngayKetThuc = doc.GetDateTime(4);
            var soLuong = doc.GetInt32(5);
            var trangThai = doc.GetBoolean(6);

            if (!trangThai || soLuong <= 0)
            {
                return (false, null, 0, "Voucher đã hết hiệu lực.");
            }

            var homNay = DateTime.Today;
            if (homNay < ngayBatDau.Date || homNay > ngayKetThuc.Date)
            {
                return (false, null, 0, "Voucher đã hết hạn.");
            }

            decimal tienGiam = 0;
            if (kieuGiamGia == "PhanTram")
            {
                tienGiam = tongTien * (giaTriGiam / 100m);
            }
            else
            {
                tienGiam = giaTriGiam;
            }

            if (tienGiam > tongTien)
            {
                tienGiam = tongTien;
            }

            return (true, maVoucher, tienGiam, "Áp dụng voucher thành công.");
        }

        public async Task TruSoLuong(int maVoucher)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"UPDATE Voucher
                                    SET SoLuong = CASE WHEN SoLuong > 0 THEN SoLuong - 1 ELSE 0 END
                                    WHERE MaVoucher = @MaVoucher";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaVoucher", maVoucher);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }
    }
}
