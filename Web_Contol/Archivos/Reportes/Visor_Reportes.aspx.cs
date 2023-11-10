using ClsEntidades;
using ClsObjetos;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDescuentos.Archivos.Reportes
{
    public partial class Visor_Reportes : System.Web.UI.Page
    {
        string Reporte = "";
        int Organismo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reporte = Request.QueryString["Reporte"].ToString();
            Organismo = Convert.ToInt16(Request.QueryString["fkorg"].ToString());

            if (!IsPostBack)
            {
                Impresion();
            }

            SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];

            if (objusuario == null)
            {
                Response.Redirect("../../Login.aspx");
            }
        }
        [System.Web.Services.WebMethod]
        public static bool GetResponse()
        {
            return true;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public void Impresion()
        {           
            rvVista.LocalReport.ReportPath = Server.MapPath("~/Archivos/Reportes/"+ Reporte + ".rdlc");
           
            //SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            //string jsonobj = JsonConvert.SerializeObject(objusuario);
            //string respuesta = Llamar_Api.PostItem("Permisos/Cargar_Permisos", jsonobj);
            //ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
           
            rvVista.LocalReport.DataSources.Clear();

            //ReportDataSource dsDatGen = new ReportDataSource("DatosGenerales", ds.Tables[0]);
            //rvVista.LocalReport.DataSources.Add(dsDatGen);
          
            rvVista.LocalReport.Refresh();
        }
    }
}