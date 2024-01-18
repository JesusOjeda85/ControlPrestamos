using ClsEntidades;
using ClsObjetos;
using Microsoft.Reporting.WebForms;
using Microsoft.ReportingServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace ControlDescuentos.Archivos.Reportes
{
    public partial class Fun_Reportes : System.Web.UI.Page
    {
       static string Reporte = "";
       static int Organismo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Buscar_Empleados(BuscarEmpleado Obj)
        {
            string[] result = { "", "", "" };
            //SesionDto objusuario = (SesionDto)HttpContext.Current.Session["Sesion"];
            //Obj.IdUsuario = objusuario.Idusuario;
            string jsonobj = JsonConvert.SerializeObject(Obj);
            string respuesta = Llamar_Api.PostItem("Reportes/Listar_Empleados", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);
            result[0] = msg.Error.ToString();
            result[1] = msg.Mensaje;
            result[2] = JsonConvert.SerializeObject(msg.Data);
            return result;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Generar_Archivos(int FkOrganismo,string Filtros,string Reporte)
        {
            string[] result = { "", "", "" };
            string[] streamIds;
            Warning[] warnings;
            string mineType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
           

             ReportDataSource DsDatos = new ReportDataSource();
            ReportDataSource DsDetalle = new ReportDataSource();
            //LocalReport localReport = new LocalReport();
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;

            //if (Reporte == "Pagare")
            //{
                viewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(Reporte + ".rdlc");

                FiltroPagare filtro = new FiltroPagare();
                filtro.FkOrganismo = FkOrganismo;
                filtro.Condicion = Filtros;

                string jsonobj = JsonConvert.SerializeObject(filtro);
                string respuesta = Llamar_Api.PostItem("Reportes/Listar_Pagare", jsonobj);
                ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);

            List<string> lsttbl = JsonConvert.DeserializeObject<List<string>>(msg.Data.ToString());

            //string jsondt = JsonConvert.SerializeObject(msg.Data);
            DataTable dtcredito = (DataTable)JsonConvert.DeserializeObject(lsttbl[0], typeof(DataTable));             
            DsDatos = new ReportDataSource("dtPagare", dtcredito);

            DataTable dtdetalle = (DataTable)JsonConvert.DeserializeObject(lsttbl[1], typeof(DataTable));
            DsDetalle = new ReportDataSource("dtDetalle", dtdetalle);


            //}
            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(DsDatos);
            viewer.LocalReport.DataSources.Add(DsDetalle);

            try
            {
                  var Ruta = HttpContext.Current.Server.MapPath("Archivos/" + Reporte + ".pdf");
               
                if (File.Exists(Ruta))
                { File.Delete(Ruta); }

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mineType, out encoding, out extension, out streamIds, out warnings);
                File.WriteAllBytes(Ruta, bytes);

                viewer.LocalReport.Refresh();
                //System.Diagnostics.Process.Start(Ruta);

                result[0] = "0";
                result[1] = "";
                result[2] = "Archivos/" + Reporte + ".pdf";
            }
            catch (Exception ev)
            {
                result[0] = "1";
                result[1] = ev.ToString();
            }
            return result;           
        }
    }
}