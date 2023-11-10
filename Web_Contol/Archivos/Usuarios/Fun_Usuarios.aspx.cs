using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace ControlDescuentos.Archivos.Usuarios
{
    public partial class Fun_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_USUARIOS()
        {
            string[] result = { "", "", "" };                
            string respuesta = Llamar_Api.GetItem("Usuarios/Listar_Usuarios");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_DATOS_USUARIO(FiltroIdUsuario objusuario)
        {
            string[] result = { "", "", "" };
            JavaScriptSerializer js = new JavaScriptSerializer();          
            string jsonobj = JsonConvert.SerializeObject(objusuario);
            string respuesta = Llamar_Api.PostItem("Usuarios/Buscar_Usuario", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_USUARIO(DatosUsuario objusuario)
        {
            string[] result = { "", "" };           
            string jsonobj = JsonConvert.SerializeObject(objusuario);
            string respuesta = Llamar_Api.PostItem("Usuarios/Guardar_Usuario", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_PERFILES()
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            FiltroIdUsuario obj = new FiltroIdUsuario();
            obj.Idusuario = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(obj);

            string respuesta = Llamar_Api.PostItem("Permisos/Listar_Perfiles", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_MENUS()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Permisos/Listar_Menus");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_REPORTES()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Permisos/Listar_Reportes");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_PERMISOS(DatosPermisos objpermisos)
        {
            string[] result = { "", "" };
            string jsonobj = JsonConvert.SerializeObject(objpermisos);
            string respuesta = Llamar_Api.PostItem("Permisos/Guardar_Permisos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] CARGAR_PERMISOS(FiltroIdUsuario objusuario)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(objusuario);
            string respuesta = Llamar_Api.PostItem("Permisos/Cargar_Permisos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

    }
}