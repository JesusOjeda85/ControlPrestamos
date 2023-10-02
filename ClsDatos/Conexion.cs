using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClsDatos
{
    public class Conexion
    {
        SqlConnection StrConexion;
        SqlConnection StrConexion_Expediente;

        public void ConexionSQL()
        {
            StrConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Local"].ToString());          
            StrConexion_Expediente = new SqlConnection(ConfigurationManager.ConnectionStrings["Expedientes"].ToString());
        }

        public SqlConnection abrirConexion()
        {
            try
            {
                ConexionSQL();
                if (StrConexion.State == ConnectionState.Closed)
                {
                    StrConexion.Open();
                }
                else
                {
                    cerrarConexion();
                    abrirConexion();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return StrConexion;
        }

        public void cerrarConexion()
        {
            if (StrConexion != null)
            {
                if (StrConexion.State != ConnectionState.Closed)
                {
                    StrConexion.Close();
                }
            }
        }

        public SqlConnection abrirConexionExpediente()
        {
            try
            {
                if (StrConexion_Expediente.State == ConnectionState.Closed)
                {
                    StrConexion_Expediente.Open();
                }
                else
                {
                    cerrarConexionExpediente();
                    abrirConexionExpediente();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return StrConexion_Expediente;
        }

        public void cerrarConexionExpediente()
        {
            if (StrConexion_Expediente != null)
            {
                if (StrConexion_Expediente.State != ConnectionState.Closed)
                {
                    StrConexion_Expediente.Close();
                }
            }
        }
    }
}
