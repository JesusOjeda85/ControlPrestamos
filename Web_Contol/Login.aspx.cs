using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Nomina
{
    public partial class Login : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static bool GetResponse()
        {
            return true;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Iniciar_Seccion(Login obj)
        {
            string[] result = { "", "", "" };
            //ObjMensaje msg = ProcesosDeSesion.Iniciar_Seccion(obj);           
            //result[0] = msg.Error.ToString();
            //result[1] = msg.Mensaje;
            //if (msg.Error.ToString() == "0")
            //{                
            //    HttpContext.Current.Session["Usuario"] = msg.Data;
            //}
            //return result;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsondata = JsonConvert.SerializeObject(obj);
            string respuesta = Llamar_Api.PostItem("Login/Iniciar_Sesion", jsondata);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            if (msg.Error.ToString() == "0")
            {
                Sesion usu = JsonConvert.DeserializeObject<Sesion>(msg.Data.ToString());
                HttpContext.Current.Session["Usuario"] = usu;
            }
            return result;
        }
    }
}