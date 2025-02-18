using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace WebApi.Conexion
{
    public static class CollectionExtensions
    {
        public static void AddWithValue(this Collection<SqlParameter> ths, string nombre, object valor) => ths.Add(new SqlParameter(nombre, valor));
    }
}
