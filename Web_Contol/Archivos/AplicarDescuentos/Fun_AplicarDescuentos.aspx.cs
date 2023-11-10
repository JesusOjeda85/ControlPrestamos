using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ControlDescuentos.Archivos.AplicarDescuentos
{
    public partial class Fun_AplicarDescuentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Cargar_Descuentos(BuscarEmpleado Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.IdUsuario = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Aplicacion/Cargar_Descuentos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] MODIFICAR_CAPTURA(DatosCaptura Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioCaptura = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Modificar_Captura", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] APLICAR_DESCUENTOS(DatosAplicar Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioAutoriza = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Aplicacion/Aplicar_Descuentos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_QUINCENAS()
        {
            string[] result = { "", "", "" };                       
            string respuesta = Llamar_Api.GetItem("Aplicacion/Listar_Quincenas");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }
    }
}