using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using doanbanve.Models;
using doanbanve.Utils;

namespace doanbanve.DAO
{
    public class VeDAO
    {
        public async Task<List<Ve>> LayDanhSachVe(int? maLoaiVe)
        {
            var danhSach = new List<Ve>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            var cauLenh = new StringBuilder(@"SELECT MaVe, MaLoaiVe, TenVe, GiaVe, GiaNguoiLon, GiaTreEm, GiaNguoiCaoTuoi, SoLuong, MoTa, ThongTinVe, TrangThai
                                            FROM Ve
                                            WHERE TrangThai = 1");

            if (maLoaiVe.HasValue && maLoaiVe.Value > 0)
            {
                cauLenh.Append(" AND MaLoaiVe = @MaLoaiVe");
            }

            cauLenh.Append(" ORDER BY TenVe");

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh.ToString(), ketNoi);
            if (maLoaiVe.HasValue && maLoaiVe.Value > 0)
            {
                lenh.Parameters.AddWithValue("@MaLoaiVe", maLoaiVe.Value);
            }

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add(new Ve
                {
                    MaVe = doc.GetInt32(0),
                    MaLoaiVe = doc.GetInt32(1),
                    TenVe = doc.GetString(2),
                    GiaVe = doc.GetDecimal(3),
                    GiaNguoiLon = doc.GetDecimal(4),
                    GiaTreEm = doc.GetDecimal(5),
                    GiaNguoiCaoTuoi = doc.GetDecimal(6),
                    SoLuong = doc.GetInt32(7),
                    MoTa = doc.IsDBNull(8) ? null : doc.GetString(8),
                    ThongTinVe = doc.IsDBNull(9) ? null : doc.GetString(9),
                    TrangThai = doc.GetBoolean(10)
                });
            }

            return danhSach;
        }

        public async Task<List<Ve>> LayDanhSachVeQuanLy()
        {
            var danhSach = new List<Ve>();
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"SELECT MaVe, MaLoaiVe, TenVe, GiaVe, GiaNguoiLon, GiaTreEm, GiaNguoiCaoTuoi, SoLuong, MoTa, ThongTinVe, TrangThai
                                    FROM Ve
                                    ORDER BY TenVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);

            await ketNoi.OpenAsync();
            using var doc = await lenh.ExecuteReaderAsync();
            while (await doc.ReadAsync())
            {
                danhSach.Add(new Ve
                {
                    MaVe = doc.GetInt32(0),
                    MaLoaiVe = doc.GetInt32(1),
                    TenVe = doc.GetString(2),
                    GiaVe = doc.GetDecimal(3),
                    GiaNguoiLon = doc.GetDecimal(4),
                    GiaTreEm = doc.GetDecimal(5),
                    GiaNguoiCaoTuoi = doc.GetDecimal(6),
                    SoLuong = doc.GetInt32(7),
                    MoTa = doc.IsDBNull(8) ? null : doc.GetString(8),
                    ThongTinVe = doc.IsDBNull(9) ? null : doc.GetString(9),
                    TrangThai = doc.GetBoolean(10)
                });
            }

            return danhSach;
        }

        public async Task<int> ThemVe(Ve ve)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"INSERT INTO Ve (MaLoaiVe, TenVe, GiaVe, GiaNguoiLon, GiaTreEm, GiaNguoiCaoTuoi, SoLuong, MoTa, ThongTinVe, TrangThai)
                                    VALUES (@MaLoaiVe, @TenVe, @GiaVe, @GiaNguoiLon, @GiaTreEm, @GiaNguoiCaoTuoi, @SoLuong, @MoTa, @ThongTinVe, 1);
                                    SELECT SCOPE_IDENTITY();";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaLoaiVe", ve.MaLoaiVe);
            lenh.Parameters.AddWithValue("@TenVe", ve.TenVe);
            lenh.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
            lenh.Parameters.AddWithValue("@GiaNguoiLon", ve.GiaNguoiLon);
            lenh.Parameters.AddWithValue("@GiaTreEm", ve.GiaTreEm);
            lenh.Parameters.AddWithValue("@GiaNguoiCaoTuoi", ve.GiaNguoiCaoTuoi);
            lenh.Parameters.AddWithValue("@SoLuong", ve.SoLuong);
            lenh.Parameters.AddWithValue("@MoTa", (object?)ve.MoTa ?? DBNull.Value);
            lenh.Parameters.AddWithValue("@ThongTinVe", (object?)ve.ThongTinVe ?? DBNull.Value);

            await ketNoi.OpenAsync();
            var ketQua = await lenh.ExecuteScalarAsync();
            return Convert.ToInt32(ketQua);
        }

        public async Task SuaVe(Ve ve)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = @"UPDATE Ve
                                    SET MaLoaiVe = @MaLoaiVe,
                                        TenVe = @TenVe,
                                        GiaVe = @GiaVe,
                                        GiaNguoiLon = @GiaNguoiLon,
                                        GiaTreEm = @GiaTreEm,
                                        GiaNguoiCaoTuoi = @GiaNguoiCaoTuoi,
                                        SoLuong = @SoLuong,
                                        MoTa = @MoTa,
                                        ThongTinVe = @ThongTinVe
                                    WHERE MaVe = @MaVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaVe", ve.MaVe);
            lenh.Parameters.AddWithValue("@MaLoaiVe", ve.MaLoaiVe);
            lenh.Parameters.AddWithValue("@TenVe", ve.TenVe);
            lenh.Parameters.AddWithValue("@GiaVe", ve.GiaVe);
            lenh.Parameters.AddWithValue("@GiaNguoiLon", ve.GiaNguoiLon);
            lenh.Parameters.AddWithValue("@GiaTreEm", ve.GiaTreEm);
            lenh.Parameters.AddWithValue("@GiaNguoiCaoTuoi", ve.GiaNguoiCaoTuoi);
            lenh.Parameters.AddWithValue("@SoLuong", ve.SoLuong);
            lenh.Parameters.AddWithValue("@MoTa", (object?)ve.MoTa ?? DBNull.Value);
            lenh.Parameters.AddWithValue("@ThongTinVe", (object?)ve.ThongTinVe ?? DBNull.Value);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }

        public async Task XoaVe(int maVe)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenh = "DELETE FROM Ve WHERE MaVe = @MaVe";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenh = new SqlCommand(cauLenh, ketNoi);
            lenh.Parameters.AddWithValue("@MaVe", maVe);

            await ketNoi.OpenAsync();
            await lenh.ExecuteNonQueryAsync();
        }
    }
}
