using System.Data.SqlClient;
using System.Data;
using System.Text;
using Prestamos_Shared.Objetos;
using ClsObjetos;

namespace WebApi.Conexion
{
    public class UtileriasBD
    {
        private SqlConnection? con;

        public UtileriasBD()
        {
            var configuation = GetConfiguration();
            con = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("ConexionDB").Value);
        }

        private IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        public async Task<DataTable> EjecutarConsultaEnTabla(string query, IEnumerable<SqlParameter>? Params = null)
        {
            var dt = new DataTable();
            try
            {
                using SqlConnection oConexion = new(con.ConnectionString);
                using (var adaptador = new SqlDataAdapter(query, oConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (var item in Params)
                        {
                            adaptador.SelectCommand.Parameters.AddWithValue(item.ParameterName, item.Value);
                        }
                    }
                    await oConexion.OpenAsync();
                    var reader = await adaptador.SelectCommand.ExecuteReaderAsync();
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public async Task<DataSet> EjecutarConsultaEnDataSet(string query, IEnumerable<SqlParameter>? Params = null)
        {
            var ds = new DataSet();
            try
            {
                using SqlConnection oConexion = new(con.ConnectionString);
                using (var adaptador = new SqlDataAdapter(query, oConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (var item in Params)
                        {
                            adaptador.SelectCommand.Parameters.AddWithValue(item.ParameterName, item.Value);
                        }
                    }
                    await oConexion.OpenAsync();
                    var reader = await adaptador.SelectCommand.ExecuteReaderAsync();
                    while (!reader.IsClosed)
                        ds.Tables.Add().Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }

        public async Task<ObjMensaje> Ejecutar(string query, IEnumerable<SqlParameter>? Params = null)
        {
            var result = new ObjMensaje();
            try
            {
                using var oConexion = new SqlConnection(con.ConnectionString);
                using (var comando = new SqlCommand(query, oConexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (Params != null)
                    {
                        foreach (var item in Params)
                        {
                            comando.Parameters.AddWithValue(item.ParameterName, item.Value);
                        }
                    }
                    await oConexion.OpenAsync();
                    await comando.ExecuteNonQueryAsync();
                    result.Error = 0;
                    result.Mensaje = "Ok";
                }
            }
            catch (Exception ex)
            {
                result.Error = 1;
                result.Mensaje = ex.Message;
            }
            return result;
        }


        public string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new();
            ds.Merge(dt);
            StringBuilder JsonString = new();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString().Replace("\"", "\\\"").Trim() + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            JsonString.Append("\"" + ds.Tables[0].Columns[j].ColumnName.ToString() + "\":" + "\"" + ds.Tables[0].Rows[i][j].ToString().Replace("\"", "\\\"").Trim() + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        public List<string> ListaTablasJson(DataSet ds)
        {
            List<string> lsttbl = new();
            for (int t = 0; t < ds.Tables.Count; t++)
            {
                string tbljson = DataTableToJsonObj(ds.Tables[t]);
                lsttbl.Add(tbljson);
            }
            return lsttbl;
        }

        public async Task<List<string>> EjecutarConsultaJson(string query, IEnumerable<SqlParameter>? Params = null)
        {
            var ds = await this.EjecutarConsultaEnDataSet(query, Params);
            List<string> lst = ListaTablasJson(ds);
            return lst;
        }

    }
}

