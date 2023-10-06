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
        public static string[] GUARDAR_CAPTURA(DatosCaptura obDatos)
        {
            string[] result = { "", "", "" };          
            string respuesta = Llamar_Api.PostItem("Captura/Guardar_Captura", obDatos);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }
    }
}