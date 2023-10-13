using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDescuentos.Archivos.Menu
{
    public partial class Fun_Menus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] CARGAR_PERMISOS()
        {
            string[] result = { "", "", "","","" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            string jsonobj = JsonConvert.SerializeObject(objusuario);
            string respuesta = Llamar_Api.PostItem("Permisos/Cargar_Permisos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            result[3] = objusuario.Nombre.ToString();
            result[4] = objusuario.Administrador.ToString();
            return result;
        }
    }
}