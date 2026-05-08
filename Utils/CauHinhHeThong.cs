using Microsoft.Extensions.Configuration;

namespace doanbanve.Utils
{
    public static class CauHinhHeThong
    {
        private static readonly IConfigurationRoot CauHinh = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static string LayChuoiKetNoi()
        {
            return CauHinh.GetConnectionString("SqlServer") ?? string.Empty;
        }
    }
}
