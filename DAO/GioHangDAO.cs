using Microsoft.Data.SqlClient;
using doanbanve.Utils;

namespace doanbanve.DAO
{
    public class GioHangDAO
    {
        public async Task<int> LayHoacTaoGioHang(int maNguoiDung)
        {
            var chuoiKetNoi = CauHinhHeThong.LayChuoiKetNoi();
            const string cauLenhLay = "SELECT TOP 1 MaGioHang FROM GioHang WHERE MaNguoiDung = @MaNguoiDung ORDER BY MaGioHang DESC";
            const string cauLenhThem = "INSERT INTO GioHang (MaNguoiDung) VALUES (@MaNguoiDung); SELECT SCOPE_IDENTITY();";

            using var ketNoi = new SqlConnection(chuoiKetNoi);
            using var lenhLay = new SqlCommand(cauLenhLay, ketNoi);
            lenhLay.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);

            await ketNoi.OpenAsync();
            var ketQua = await lenhLay.ExecuteScalarAsync();
            if (ketQua != null && int.TryParse(ketQua.ToString(), out var maGioHang))
            {
                return maGioHang;
            }

            using var lenhThem = new SqlCommand(cauLenhThem, ketNoi);
            lenhThem.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
            var ketQuaThem = await lenhThem.ExecuteScalarAsync();
            return Convert.ToInt32(ketQuaThem);
        }
    }
}
