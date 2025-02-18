using ClsEntidades;
using ClsObjetos;
using ExcelLibrary.CompoundDocumentFormat;
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
        private static DataTable dtdetalle = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Buscar_Empleados(FiltroEmpleado Obj)
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
        public static string[] Generar_Archivos(string FkOrganismo,string Filtros,string Reporte)
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

           
                viewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(Reporte + ".rdlc");

                FiltroPagare filtro = new FiltroPagare();
                filtro.FkOrganismo = FkOrganismo;
                filtro.Condicion = Filtros;

            string jsonobj = JsonConvert.SerializeObject(filtro);
            string respuesta = Llamar_Api.PostItem("Reportes/Listar_Pagare", jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);

            if (msg.Error == 0)
            {
                List<string> lsttbl = JsonConvert.DeserializeObject<List<string>>(msg.Data.ToString());
               
                DataTable dtcredito = (DataTable)JsonConvert.DeserializeObject(lsttbl[0], typeof(DataTable));
                DsDatos = new ReportDataSource("dtPagare", dtcredito);

                //dtdetalle = (DataTable)JsonConvert.DeserializeObject(lsttbl[1], typeof(DataTable));
                //DsDetalle = new ReportDataSource("dtDetalle", dtdetalle);


                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(DsDatos);
                //viewer.LocalReport.DataSources.Add(DsDetalle);


                //viewer.LocalReport.SubreportProcessing +=
                //     new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);


                try
                {
                    //var Ruta = HttpContext.Current.Server.MapPath("Archivos/" + Reporte + ".pdf");
                    var Ruta = HttpContext.Current.Server.MapPath("Archivos_pdf/" + Reporte + ".pdf");

                    if (File.Exists(Ruta))
                    { File.Delete(Ruta); }

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mineType, out encoding, out extension, out streamIds, out warnings);
                    File.WriteAllBytes(Ruta, bytes);

                    viewer.LocalReport.Refresh();
                    //System.Diagnostics.Process.Start(Ruta);

                    result[0] = "0";
                    result[1] = "";
                    result[2] = "Archivos_pdf/" + Reporte + ".pdf";
                }
                catch (Exception ev)
                {
                    result[0] = "1";
                    result[1] = ev.ToString();
                }
               
            }
            else
            {
                result[0] = "1";
                result[1] = msg.Mensaje;
                result[2] = null;
            }
            return result;
        }

        private static void DemoSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("dtDetalle", dtdetalle));
        }
    }
}