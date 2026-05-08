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
    }
}
