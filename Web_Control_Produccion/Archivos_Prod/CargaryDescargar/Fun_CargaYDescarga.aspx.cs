using ClsEntidades;
using ClsObjetos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace ControlDescuentos.Archivos.CargaryDescargar
{
    public partial class Fun_CargaYDescarga : System.Web.UI.Page
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
            string respuesta = Llamar_Api.PostItem("CargayDescarga/Subir_Archivo", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = msg.Datos;
            return result;
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] SALIDA_ARCHIVO(ArchivoSalida Obj)
        {
            string[] result = { "", "", "" ,""};
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.IdUsuario = objusuario.Idusuario;
            //Obj.Quincena= HttpContext.Current.Session["Quincena"].ToString();

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("CargayDescarga/Salida_Archivo", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);           
            return result;
        }
    }
}