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

namespace ControlDescuentos.Archivos.Devoluciones
{
    public partial class Fun_Devoluciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_DEVOLUCIONES(DatosCapturaDevoluciones Obj)
        {
            string[] result = { "", "", "", "", "" };

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Devoluciones/Guardar_Devoluciones", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_ADEUDOS_IMPRESION(FiltroAdeudos Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Devoluciones/Listar_Adeudos_Impresion", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] APLICAR_RENUMERACION(DatosNumeracion Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.fkusuario = objusuario.Idusuario;

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Devoluciones/Aplicar_Renumeracion", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }
    }
}