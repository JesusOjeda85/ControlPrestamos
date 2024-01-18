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
            //Reporte = Request.QueryString["Reporte"].ToString();
            //Organismo = Convert.ToInt16(Request.QueryString["fkorg"].ToString());

            if (!IsPostBack)
            {
                Impresion();
            }

            //SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            //if (objusuario == null)
            //{
            //    Response.Redirect("../../Login.aspx");
            //}
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
            ReportDataSource DsDatos = new ReportDataSource();
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;

            if (Reporte == "Pagare")
            {
                viewer.LocalReport.ReportPath = Server.MapPath("~/Archivos/" + Reporte + ".rdlc");

                FiltroPagare filtro = new FiltroPagare();
                filtro.FkOrganismo = 1;
                filtro.Condicion = "";

                string jsonobj = JsonConvert.SerializeObject(filtro);
                string respuesta = Llamar_Api.PostItem("Reportes/Listar_Pagare", jsonobj);
                ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);

                string jsondt = JsonConvert.SerializeObject(msg.Data);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondt, typeof(DataTable));

                DsDatos = new ReportDataSource("dtPagare", dt);               

            }
            /*pasar parametros al reporte*/
            //ReportParameter[] repParameters = new ReportParameter[1];
            //repParameters[0] = new ReportParameter();
            //repParameters[0].Name = "Batch";
            //repParameters[0].Values.Add("Test");

            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(DsDatos);
            viewer.LocalReport.Refresh();
        }
    }
}