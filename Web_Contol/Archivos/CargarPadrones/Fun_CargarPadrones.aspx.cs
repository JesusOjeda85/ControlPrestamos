using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ControlDescuentos.Archivos.CargarPadrones
{
    public partial class Fun_CargarPadrones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_ARCHIVO(DatosCargar Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.IdUsuario = objusuario.Idusuario;

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("CargarPadrones/Padron_Liquidez", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = msg.Datos;
            return result;
        }
    }
}