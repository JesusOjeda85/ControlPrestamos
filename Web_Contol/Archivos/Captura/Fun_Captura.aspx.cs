using ClsEntidades;
using ClsObjetos;
using ExcelLibrary.BinaryFileFormat;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDescuentos.Archivos.Captura
{
    public partial class Fun_Captura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_PLAZOS(FiltroIdOrganismo objorganismo)
        {
            string[] result = { "", "", "" };          
            string jsonobj = JsonConvert.SerializeObject(objorganismo);
            string respuesta = Llamar_Api.PostItem("Captura/Listar_Plazos",jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_BANCOS()
        {
            string[] result = { "", "", "" };           
            string respuesta = Llamar_Api.GetItem("Captura/Listar_Bancos");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_TIPOPAGO()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_TipoPago");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_ZONAPAGO()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_ZonaPago");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_IMPORTES_PLAZOS(FiltroIdOrganismo objorganismo)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(objorganismo);
            string respuesta = Llamar_Api.PostItem("Captura/Listar_ImportePlazos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_TIPOPUESTO()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_TipoPuesto");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_MOTIVOSBAJAS()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_MotivosBajas");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_CAUSASMUERTE()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_CausasMuerte");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_CONCEPTOSSINIESTROS()
        {
            string[] result = { "", "", "" };
            string respuesta = Llamar_Api.GetItem("Captura/Listar_ConceptosSiniestros");
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_CONCEPTOSPORPUESTO(FiltroIdTipoEmpleado obj)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(obj);
            string respuesta = Llamar_Api.PostItem("Captura/Listar_ConceptosPorPuesto", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] BUSCAR_EMPLEADOS(BuscarEmpleado obj)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(obj);
            string respuesta = Llamar_Api.PostItem("Captura/Buscar_Empleado", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_CAPTURA(DatosCaptura Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioCaptura = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Guardar_Captura", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] ELIMINAR_CAPTURA(DatosCaptura Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioCaptura = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Eliminar_Captura", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_CAPTURA_RETIROS(DatosCapturaRetiros Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioCaptura = objusuario.Idusuario;

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Guardar_Captura_Retiros", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;           
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] GUARDAR_CAPTURA_SINIESTROS(DatosCapturaSiniestros Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            Obj.FkUsuarioCaptura = objusuario.Idusuario;

            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Guardar_Captura_Siniestros", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] LISTAR_REVISION_CAPTURA(DatosNumeracion Obj)
        {
            string[] result = { "", "", "" };
            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Captura/Listar_Revision_Captura", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }
    }
}