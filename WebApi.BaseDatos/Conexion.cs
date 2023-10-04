using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WebApi.BaseDatos
{
    public class Conexion
    {
        SqlConnection con;
        public Conexion()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("ConexionDB").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }

        public string CadenaSql()
        {
            return con.ConnectionString;
        }
    }
}
