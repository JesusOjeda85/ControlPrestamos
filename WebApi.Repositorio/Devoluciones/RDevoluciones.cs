
using ClsObjetos;
using System.Data;
using System.Data.SqlClient;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Repositorio.Devoluciones
{
    public class RDevoluciones
    {
        public static ObjMensaje Listar_Adeudos_Creditos(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();

            try
            {

                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Devoluciones_Listar_Adeudos_Creditos '" + obj.Busqueda + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Guardar_Devoluciones(DatosCapturaDevoluciones Obj)
        {
            ObjMensaje msg = new();
            try
            {
                List<SqlParameter> parametro = new()
                {
                    new SqlParameter("@Id", SqlDbType.Int) {Value= Obj.Id },
                    new SqlParameter("@FkCredito", SqlDbType.Int) { Value = Obj.FkCredito },
                    new SqlParameter("@Importe", SqlDbType.Float) { Value = Obj.Importe },
                    new SqlParameter("@ChequeRecibo", SqlDbType.VarChar) { Value = Obj.ChequeRecibo },
                };

                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Devoluciones_Guardar ", parametro);
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                    msg.Datos = "";
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Listar_Adeudos_Impresion(FiltroAdeudos obj)
        {
            ObjMensaje msg = new();

            try
            {

                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Devoluciones_Listar_Adeudos_Impresion '" + obj.Tipo + "','"+obj.Filtro+"'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);

                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;                   
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = "No Existe Información";
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }

        public static ObjMensaje Aplicar_Renumeracion(DatosNumeracion Obj)
        {
            ObjMensaje msg = new();
            DataSet ds = new DataSet();
            try
            {
                ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Devoluciones_ReNumeracion_Aplicar " + Obj.fkusuario + ",'" + Obj.Proceso + "'"); 
              
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                    msg.Datos = "";
                }
                else
                {
                    msg.Error = 1;
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                msg.Error = 1;
                msg.Mensaje = ex.Message.ToString();
            }
            return msg;
        }


    }
}
