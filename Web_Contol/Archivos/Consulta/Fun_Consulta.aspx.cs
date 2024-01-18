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

namespace ControlDescuentos.Archivos.Consulta
{
    public partial class Fun_Consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Listar_DetalleCredito(FiltroIdCredito Obj)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Consulta/Listar_DetalleCredito", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Listar_NumCreditos(FiltroEmpleado Obj)
        {
            string[] result = { "", "", "" };
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Consulta/Listar_NumCreditos", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }
    }
}