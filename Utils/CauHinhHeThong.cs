using System.Configuration;

namespace doanbanve.Utils
{
    public static class CauHinhHeThong
    {
        public static string LayChuoiKetNoi()
        {
            return ConfigurationManager.ConnectionStrings["db"]?.ConnectionString ?? string.Empty;
        }
    }
}
