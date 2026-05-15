using System.Security.Cryptography;
using System.Text;

namespace doanbanve.Utils
{
    public static class MaHoaMatKhau
    {
        public static string MaHoaMD5(string giaTri)
        {
            if (string.IsNullOrEmpty(giaTri))
            {
                return string.Empty;
            }

            using var md5 = MD5.Create();
            var duLieu = Encoding.UTF8.GetBytes(giaTri);
            var bam = md5.ComputeHash(duLieu);
            var chuoi = new StringBuilder(bam.Length * 2);
            foreach (var byteGiaTri in bam)
            {
                chuoi.Append(byteGiaTri.ToString("x2"));
            }

            return chuoi.ToString();
        }
    }
}
