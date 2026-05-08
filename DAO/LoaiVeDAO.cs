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
    }
}
