using ClsObjetos;
using System.Data;
using System.Data.SqlClient;
using WebApi.BaseDatos;
using WebApi.Dto;
using WebApi.Entidades;

namespace WebApi.Repositorio.AplicacionDescuentos
{
    public class RAplicacion
    {
        public static ObjMensaje Cargar_Descuentos(BuscarEmpleado obj)
        {
            ObjMensaje msg = new();

            try
            {
                List<SqlParameter> parametro = new()
                {
                     new SqlParameter("@Desde", SqlDbType.Int) {Value= obj.Desde },
                      new SqlParameter("@Hasta", SqlDbType.Int) {Value= obj.Hasta },
                     new SqlParameter("@IdUsuario", SqlDbType.Int) {Value= obj.IdUsuario },
                     new SqlParameter("@FkOrganismo", SqlDbType.Int) {Value= obj.FkOrganismo },
                     new SqlParameter("@FkConcepto", SqlDbType.Int) {Value= obj.FkConcepto },
                       new SqlParameter("@Busqueda", SqlDbType.VarChar,50) {Value= obj.Busqueda },
                };

                DataSet ds = MetodosBD.EjecutarProcedimiento("SPT_Captura_Listar_CreditosAplicar ", parametro);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
                    msg.Datos = ds.Tables[1].Rows[0][0].ToString();
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

        public static ObjMensaje Aplicar_Descuentos(DatosCaptura Obj)
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_AplicacionDescuentos_Aplicar " + Obj.FkUsuarioAutoriza +",'" + Obj.Aplicados + "','"+Obj.Rechazados+"','" + Obj.Quincena + "','" + Obj.Año +"'");
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

        public static ObjMensaje Listar_Quincenas()
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_AplicacionDescuentos_Listar_Quincenas");
                if (ds.Tables.Count > 0)
                {
                    List<Dictionary<string, object>> Tbljson = MetodosBD.convertirDatatableEnJsonString(ds.Tables[0]);
                    msg.Error = 0;
                    msg.Mensaje = "";
                    msg.Data = Tbljson;
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
