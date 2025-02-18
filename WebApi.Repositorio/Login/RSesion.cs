
using ClsObjetos;
using System.Data;
using WebApi.BaseDatos;
using WebApi.Dto;



namespace WebApi.Repositorio.RSesion
{
    public class RSesion
    {
        public static ObjMensaje Iniciar_Sesion(LoginDto obj)
        {
            SesionDto sesion = new();
            ObjMensaje ClsMensaje = new();
            try
            {
                DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Sesion_Iniciar_Sesion '" + obj.Usuario + "','" + obj.Contraseña + "'");
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    sesion.Idusuario = Convert.ToInt16(ds.Tables[1].Rows[0][0].ToString());
                    sesion.Usuario = ds.Tables[1].Rows[0][1].ToString();
                    sesion.Nombre = ds.Tables[1].Rows[0][2].ToString();
                    sesion.Administrador= Convert.ToBoolean(ds.Tables[1].Rows[0][3].ToString());                    
                    ClsMensaje.Datos = ds.Tables[2].Rows[0][1].ToString()+"_"+ ds.Tables[2].Rows[0][0].ToString();
                    ClsMensaje.Data = sesion;
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
        public static ObjMensaje Cambiar_Contraseña(CambioContraseñaDTO Obj)
        {
            ObjMensaje msg = new ObjMensaje();
            DataSet ds = MetodosBD.EjecutarConsultaEnDataSet("SPT_Sesion_Modificar_Sesion '" + Obj.Idusuario + "', '" + Obj.Contraseña + "', '" + Obj.ContraseñaNueva + "'");
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
