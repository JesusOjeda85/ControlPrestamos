using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ClsDatos
{
    public class Metodos
    {
        public static int ContadorBulk;

        public static string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
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
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = new Dictionary<string, object>();
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
      
        public static DataSet EjecutarConsultaEnDataSet(string query)
        {
            SqlDataAdapter Adaptador;
            DataSet ds = new DataSet();
            Conexion con = new Conexion();          
            Adaptador = new SqlDataAdapter(query, con.abrirConexion());
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
                con.cerrarConexion();
            }
        }

        public static DataSet EjecutarConsultaDataSetExpediente(string query)
        {
            System.Data.SqlClient.SqlDataAdapter Adaptador;
            DataSet ds = new DataSet();
            Conexion conexionExpediente = new Conexion();
            Adaptador = new System.Data.SqlClient.SqlDataAdapter(query, conexionExpediente.abrirConexionExpediente());
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
                conexionExpediente.cerrarConexionExpediente();
            }
        }

        public static DataTable EjecutarConsultaEnDataTable(string query)
        {
            SqlDataAdapter Adaptador;
            DataTable dt = new DataTable();
            Conexion conexionDePrueba = new Conexion();
            Adaptador = new SqlDataAdapter(query, conexionDePrueba.abrirConexion());
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
                conexionDePrueba.cerrarConexion();
            }
        }

        public static string EJECUTAR_SENTENCIA(string par_query)
        {
            string msg = "";
            Conexion conexionDePrueba = new Conexion();
            try
            {
                SqlConnection sqlcon = conexionDePrueba.abrirConexion();
                if (sqlcon.State.ToString() == "Open") { sqlcon.Close(); sqlcon.Open(); } else { sqlcon.Open(); }
                SqlCommand cmd;
                cmd = sqlcon.CreateCommand();
                cmd.CommandText = par_query;
                cmd.CommandTimeout = 1200;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                sqlcon.Close();
                msg = "Si";
            }
            catch (Exception ev)
            {
                msg = ev.ToString();
            }
            finally
            {
                conexionDePrueba.cerrarConexion();
            }
            return msg;
        }

        public static DataTable EjecutarProcedimiento(string proc, List<SqlParameter> parametros)
        {
            System.Data.SqlClient.SqlDataAdapter Adaptador;
            DataTable ds = new DataTable();
            Conexion conexionDePrueba = new Conexion();
            Adaptador = new System.Data.SqlClient.SqlDataAdapter(proc, conexionDePrueba.abrirConexion());
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
                conexionDePrueba.cerrarConexion();
            }
        }

        private static void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            ContadorBulk++;
        }

        public static List<object> BulkCopyDinamico(DataTable tbOrigen, string tbDestino, string tbMapeo)
        {
            ContadorBulk = 1;
            List<object> r = new List<object>();                     
            Conexion conexionDePrueba = new Conexion();
            try
            {

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conexionDePrueba.abrirConexion()))
                {
                    bulkCopy.DestinationTableName = "dbo." + tbDestino;
                    bulkCopy.BulkCopyTimeout = 0;
                    string[] mapeo = tbMapeo.Split('|');
                    string[] mapeoCols;
                    foreach (string cols in mapeo)
                    {
                        mapeoCols = cols.Split(',');
                        bulkCopy.ColumnMappings.Add(mapeoCols[0], mapeoCols[1]);
                    }

                    bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
                    bulkCopy.NotifyAfter = 1;
                    bulkCopy.WriteToServer(tbOrigen);
                }
                r.Add(true);
                return r;
            }
            catch (Exception ex)
            {
                r.Add(false);
                r.Add("Linea " + ContadorBulk.ToString() + ", " + ex.Message.Replace("colid", "columna").Replace("cliente bcp", "archivo origen"));
                return r;
            }
            finally
            {
                conexionDePrueba.cerrarConexion();
            }
        }

        public static string TablasToJson(DataSet ds)
        {
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }

        public static List<string> ListaTablasJson(DataSet ds)
        {
            List<string> lsttbl = new List<string>();
            for (int t = 0; t < ds.Tables.Count; t++)
            {
                string tbljson = DataTableToJsonObj(ds.Tables[t]);
                lsttbl.Add(tbljson);
            }
            return lsttbl;
        }
    }
}
