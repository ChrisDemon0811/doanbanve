using System.Data;
using Microsoft.Data.SqlClient;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.DAO
{
    public class LoaiVeDAO
    {
        public async Task<List<LoaiVe>> LayDanhSachLoaiVe()
        {
            var danhSach = new List<LoaiVe>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaLoaiVe, TenLoaiVe, MoTa, TrangThai
                                 FROM LoaiVe
                                 WHERE TrangThai = 1
                                 ORDER BY TenLoaiVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add(new LoaiVe
                {
                    MaLoaiVe = doc.GetInt32(0),
                    TenLoaiVe = doc.GetString(1),
                    MoTa = doc.IsDBNull(2) ? null : doc.GetString(2),
                    TrangThai = doc.GetBoolean(3)
                });
            }

            return danhSach;
        }

        public async Task<List<LoaiVe>> LayDanhSachLoaiVeQuanLy()
        {
            var danhSach = new List<LoaiVe>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaLoaiVe, TenLoaiVe, MoTa, TrangThai
                                 FROM LoaiVe
                                 ORDER BY TenLoaiVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add(new LoaiVe
                {
                    MaLoaiVe = doc.GetInt32(0),
                    TenLoaiVe = doc.GetString(1),
                    MoTa = doc.IsDBNull(2) ? null : doc.GetString(2),
                    TrangThai = doc.GetBoolean(3)
                });
            }

            return danhSach;
        }

        public async Task<int> ThemLoaiVe(LoaiVe loaiVe)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"INSERT INTO LoaiVe (TenLoaiVe, MoTa, TrangThai)
                                 VALUES (@TenLoaiVe, @MoTa, 1);
                                 SELECT SCOPE_IDENTITY();";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@TenLoaiVe", loaiVe.TenLoaiVe);
            lenh.Parameters.AddWithValue("@MoTa", (object?)loaiVe.MoTa ?? DBNull.Value);

            await ketNoi.OpenAsync();
            var ketQua = await lenh.ExecuteScalarAsync();
            return Convert.ToInt32(ketQua);
        }

        public async Task SuaLoaiVe(LoaiVe loaiVe)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"UPDATE LoaiVe
                                 SET TenLoaiVe = @TenLoaiVe,
                                     MoTa = @MoTa
                                 WHERE MaLoaiVe = @MaLoaiVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaLoaiVe", loaiVe.MaLoaiVe);
            lenh.Parameters.AddWithValue("@TenLoaiVe", loaiVe.TenLoaiVe);
            lenh.Parameters.AddWithValue("@MoTa", (object?)loaiVe.MoTa ?? DBNull.Value);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }

        public async Task XoaLoaiVe(int maLoaiVe)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = "DELETE FROM LoaiVe WHERE MaLoaiVe = @MaLoaiVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaLoaiVe", maLoaiVe);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }
    }
}
