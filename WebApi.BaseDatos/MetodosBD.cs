using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.BaseDatos
{
    public class MetodosBD
    {
        static Conexion con = new();

        public static DataSet EjecutarConsultaEnDataSet(string query)
        {
            SqlDataAdapter Adaptador;
            DataSet ds = new DataSet();

            using (SqlConnection oConexion = new(con.CadenaSql()))
            {
                Adaptador = new SqlDataAdapter(query, oConexion);
                Adaptador.SelectCommand.CommandTimeout = 0;
                Adaptador.SelectCommand.CommandType = CommandType.Text;
                try
                {
                    Adaptador.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConexion.Close();
                }
            }

        }

        public static DataTable EjecutarConsultaEnDataTable(string query)
        {
            SqlDataAdapter Adaptador;
            DataTable dt = new();
            using (SqlConnection oConexion = new(con.CadenaSql()))
            {
                Adaptador = new SqlDataAdapter(query, oConexion);
                Adaptador.SelectCommand.CommandTimeout = 0;
                Adaptador.SelectCommand.CommandType = CommandType.Text;
                try
                {
                    Adaptador.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConexion.Close();
                }
            }
        }

        public static DataSet EjecutarProcedimiento(string proc, List<SqlParameter> parametros)
        {
            SqlDataAdapter Adaptador;
            DataSet ds = new DataSet();
            Conexion conexionDePrueba = new();
            using (SqlConnection oConexion = new SqlConnection(con.CadenaSql()))
            {
                Adaptador = new System.Data.SqlClient.SqlDataAdapter(proc, con.CadenaSql());
                Adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter par in parametros)
                {
                    Adaptador.SelectCommand.Parameters.Add(par);
                }
                try
                {
                    Adaptador.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    oConexion.Close();
                }
            }
        }

        public static string DataTableToJsonObj(DataTable dt)
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

        public static List<Dictionary<string, object>> convertirDatatableEnJsonString(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new();
            Dictionary<string, object> row = new();
            var dato = "";
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    if ((dr[col.ColumnName].ToString() != "True") && (dr[col.ColumnName].ToString() != "False"))
                    { dato = dr[col.ColumnName].ToString(); }
                    else
                    if (dr[col.ColumnName].ToString() == "True") { dato = "1"; } else { dato = "0"; }

                    row.Add(col.ColumnName, dato);
                }
                rows.Add(row);
            }
            return rows;
        }

        public static string TablasToJson(DataSet ds)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }

        public static List<string> ListaTablasJson(DataSet ds)
        {
            List<string> lsttbl = new();
            for (int t = 0; t < ds.Tables.Count; t++)
            {
                string tbljson = DataTableToJsonObj(ds.Tables[t]);
                lsttbl.Add(tbljson);
            }
            return lsttbl;
        }
    }
}
