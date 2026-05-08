using System.Data;
using Microsoft.Data.SqlClient;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.DAO
{
    public class NguoiDungDAO
    {
        public async Task<NguoiDung?> LayTheoTaiKhoanMatKhau(string taiKhoan, string matKhau)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaNguoiDung, TaiKhoan, MatKhau, HoTen, Email, SoDienThoai, VaiTro, NgayDangKy, TrangThai
                                 FROM NguoiDung
                                 WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau AND TrangThai = 1";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
            lenh.Parameters.AddWithValue("@MatKhau", matKhau);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync(CommandBehavior.SingleRow);
            if (!doc.Read())
            {
                return null;
            }

            return new NguoiDung
            {
                MaNguoiDung = doc.GetInt32(0),
                TaiKhoan = doc.GetString(1),
                MatKhau = doc.GetString(2),
                HoTen = doc.GetString(3),
                Email = doc.IsDBNull(4) ? null : doc.GetString(4),
                SoDienThoai = doc.IsDBNull(5) ? null : doc.GetString(5),
                VaiTro = doc.GetString(6),
                NgayDangKy = doc.GetDateTime(7),
                TrangThai = doc.GetBoolean(8)
            };
        }

        public async Task<bool> KiemTraTaiKhoanTonTai(string taiKhoan)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = "SELECT COUNT(1) FROM NguoiDung WHERE TaiKhoan = @TaiKhoan";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@TaiKhoan", taiKhoan);

            await ketNoi.OpenAsync();
            var ketQua = (int)await lenh.ExecuteScalarAsync();
            return ketQua > 0;
        }

        public async Task<int> ThemNguoiDung(NguoiDung nguoiDung)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"INSERT INTO NguoiDung (TaiKhoan, MatKhau, HoTen, Email, SoDienThoai, VaiTro, TrangThai)
                                 VALUES (@TaiKhoan, @MatKhau, @HoTen, @Email, @SoDienThoai, @VaiTro, 1);
                                 SELECT SCOPE_IDENTITY();";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@TaiKhoan", nguoiDung.TaiKhoan);
            lenh.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
            lenh.Parameters.AddWithValue("@HoTen", nguoiDung.HoTen);
            lenh.Parameters.AddWithValue("@Email", (object?)nguoiDung.Email ?? DBNull.Value);
            lenh.Parameters.AddWithValue("@SoDienThoai", (object?)nguoiDung.SoDienThoai ?? DBNull.Value);
            lenh.Parameters.AddWithValue("@VaiTro", nguoiDung.VaiTro);

            await ketNoi.OpenAsync();
            var ketQua = await lenh.ExecuteScalarAsync();
            return Convert.ToInt32(ketQua);
        }

        public async Task<List<NguoiDung>> LayDanhSachNguoiDung()
        {
            var danhSach = new List<NguoiDung>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaNguoiDung, TaiKhoan, MatKhau, HoTen, Email, SoDienThoai, VaiTro, NgayDangKy, TrangThai
                                 FROM NguoiDung
                                 ORDER BY HoTen";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add(new NguoiDung
                {
                    MaNguoiDung = doc.GetInt32(0),
                    TaiKhoan = doc.GetString(1),
                    MatKhau = doc.GetString(2),
                    HoTen = doc.GetString(3),
                    Email = doc.IsDBNull(4) ? null : doc.GetString(4),
                    SoDienThoai = doc.IsDBNull(5) ? null : doc.GetString(5),
                    VaiTro = doc.GetString(6),
                    NgayDangKy = doc.GetDateTime(7),
                    TrangThai = doc.GetBoolean(8)
                });
            }

            return danhSach;
        }

        public async Task DatMatKhau(int maNguoiDung, string matKhauMoi)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"UPDATE NguoiDung
                                 SET MatKhau = @MatKhau
                                 WHERE MaNguoiDung = @MaNguoiDung";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MatKhau", matKhauMoi);
            lenh.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }
    }
}
