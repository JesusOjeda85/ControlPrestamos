
using ClsDatos;
using ClsEntidades;
using ClsObjetos;
using System;
using System.Data;

namespace Nomina_Sesion
{
    public class ProcesosDeSesion
    {
        public static ObjMensaje Iniciar_Seccion(Login obj)
        {          
            Sesion log = new Sesion();
            ObjMensaje ClsMensaje = new ObjMensaje();
            try
            {
                DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sesion_Iniciar_Sesion '" + obj.Usuario + "','" + obj.Contraseña + "'");
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    log.IdUsuario = Convert.ToInt16(ds.Tables[1].Rows[0]["Id"].ToString());
                    log.Usuario = ds.Tables[1].Rows[0]["Usuario"].ToString();
                    log.Nombre = ds.Tables[1].Rows[0]["Nombre"].ToString();                                     
                   
                    ClsMensaje.Data = log;
                }
                ClsMensaje.Error = Convert.ToInt32(ds.Tables[0].Rows[0]["Error"].ToString());
                ClsMensaje.Mensaje = ds.Tables[0].Rows[0]["Mensaje"].ToString();
                ds.Dispose();
            }
            catch (Exception ex)
            {
                ClsMensaje.Error = 0;
                ClsMensaje.Mensaje = ex.Message;
            }
            return ClsMensaje;
        }

        public static ObjMensaje Cambiar_Contraseña(int Id, Login Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = Metodos.EjecutarConsultaEnDataSet("SPT_Sesion_Modificar_Contraseña '" + Id + "', '" + Obj.Contraseña + "', '" + Obj.ContraseñaNueva + "'");
            if (ds.Tables.Count > 0)
            {
                msg.Error = Convert.ToInt16(ds.Tables[0].Rows[0][0].ToString());
                msg.Mensaje = ds.Tables[0].Rows[0][1].ToString();
            }
            ds.Dispose();
            return msg;
        }
      
    }
}
