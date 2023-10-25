using ClsObjetos;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Entidades;

namespace WebApi.Repositorio.AplicacionDescuentos
{
    public class RAplicacion
    {
        public static ObjMensaje Aplicar_Descuentos(DatosCaptura Obj)
        {
            ObjMensaje msg = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_AplicacionDescuentos_Aplicar" + Obj.IdUsuario + "," + Obj.Valores + "'");
                if (ds.Tables.Count > 0)
                {
                    msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                    msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
                    msg.Data = null;
                    msg.Datos = "";
                }
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
