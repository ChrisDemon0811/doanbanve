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

        public async Task<List<(int MaVoucher, string MaGiamGia, string TenVoucher, string KieuGiamGia, decimal GiaTriGiam, DateTime NgayBatDau, DateTime NgayKetThuc, int SoLuong, bool TrangThai)>> LayDanhSachVoucher()
        {
            var danhSach = new List<(int, string, string, string, decimal, DateTime, DateTime, int, bool)>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaVoucher, MaGiamGia, TenVoucher, KieuGiamGia, GiaTriGiam, NgayBatDau, NgayKetThuc, SoLuong, TrangThai
                                    FROM Voucher
                                    ORDER BY MaVoucher DESC";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add((
                    doc.GetInt32(0),
                    doc.GetString(1),
                    doc.GetString(2),
                    doc.GetString(3),
                    doc.GetDecimal(4),
                    doc.GetDateTime(5),
                    doc.GetDateTime(6),
                    doc.GetInt32(7),
                    doc.GetBoolean(8)
                ));
            }

            return danhSach;
        }

        public async Task<int> ThemVoucher(string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"INSERT INTO Voucher (MaGiamGia, TenVoucher, KieuGiamGia, GiaTriGiam, NgayBatDau, NgayKetThuc, SoLuong, TrangThai)
                                    VALUES (@MaGiamGia, @TenVoucher, @KieuGiamGia, @GiaTriGiam, @NgayBatDau, @NgayKetThuc, @SoLuong, 1);
                                    SELECT SCOPE_IDENTITY();";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaGiamGia", maGiamGia);
            lenh.Parameters.AddWithValue("@TenVoucher", tenVoucher);
            lenh.Parameters.AddWithValue("@KieuGiamGia", kieuGiamGia);
            lenh.Parameters.AddWithValue("@GiaTriGiam", giaTriGiam);
            lenh.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Date);
            lenh.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Date);
            lenh.Parameters.AddWithValue("@SoLuong", soLuong);

            await ketNoi.OpenAsync();
            var ketQua = await lenh.ExecuteScalarAsync();
            return Convert.ToInt32(ketQua);
        }

        public async Task SuaVoucher(int maVoucher, string maGiamGia, string tenVoucher, string kieuGiamGia, decimal giaTriGiam, DateTime ngayBatDau, DateTime ngayKetThuc, int soLuong)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"UPDATE Voucher
                                    SET MaGiamGia = @MaGiamGia,
                                        TenVoucher = @TenVoucher,
                                        KieuGiamGia = @KieuGiamGia,
                                        GiaTriGiam = @GiaTriGiam,
                                        NgayBatDau = @NgayBatDau,
                                        NgayKetThuc = @NgayKetThuc,
                                        SoLuong = @SoLuong
                                    WHERE MaVoucher = @MaVoucher";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaVoucher", maVoucher);
            lenh.Parameters.AddWithValue("@MaGiamGia", maGiamGia);
            lenh.Parameters.AddWithValue("@TenVoucher", tenVoucher);
            lenh.Parameters.AddWithValue("@KieuGiamGia", kieuGiamGia);
            lenh.Parameters.AddWithValue("@GiaTriGiam", giaTriGiam);
            lenh.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Date);
            lenh.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Date);
            lenh.Parameters.AddWithValue("@SoLuong", soLuong);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }

        public async Task XoaVoucher(int maVoucher)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = "DELETE FROM Voucher WHERE MaVoucher = @MaVoucher";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaVoucher", maVoucher);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
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
