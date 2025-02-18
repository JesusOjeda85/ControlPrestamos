using ClsEntidades;
using ClsObjetos;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;


namespace ControlDescuentos.Archivos.ArchivosRdlc
{
    public partial class Fun_Archivos : System.Web.UI.Page
    {
        static string Reporte = "";
        static int Organismo = 0;
        private static DataTable dtdetalle = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Generar_Archivos(string FkOrganismo, string Filtros, string Reporte,string Proceso,string Modulo,int ChequesNulos,string ImpresionCH)
        {
            string[] result = { "", "", "","" };
            string[] streamIds;
            Warning[] warnings;
            string mineType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string[] valprocesos= Proceso.Split('@');   


            ReportDataSource DsDatos = new ReportDataSource();            
           // ReportDataSource DsDetalle = new ReportDataSource();
           
            ReportViewer viewer = new ReportViewer();
            //PageSettings pg = new PageSettings();
            //PaperSize size = new PaperSize();

           
            viewer.ProcessingMode = ProcessingMode.Local;
            
            var rutareporte = HttpContext.Current.Server.MapPath(Reporte + ".rdlc");
            viewer.LocalReport.ReportPath = rutareporte;
                     
            FiltroPagare filtro = new FiltroPagare();
            filtro.FkOrganismo = FkOrganismo;
            filtro.Condicion = Filtros;
            filtro.Modulo = Modulo;
            filtro.ChequesNulos = ChequesNulos;
            filtro.ImpresionCH = ImpresionCH;

            string jsonobj = JsonConvert.SerializeObject(filtro);
            string respuesta = Llamar_Api.PostItem("Reportes/" + valprocesos[0], jsonobj);
            ObjMensaje msg = JsonConvert.DeserializeObject<ObjMensaje>(respuesta);

            if (msg.Error == 0)
            {
                List<string> lsttbl = JsonConvert.DeserializeObject<List<string>>(msg.Data.ToString());

                msg.Data = "";

                DataTable dtcredito = (DataTable)JsonConvert.DeserializeObject(lsttbl[0], typeof(DataTable));
                DsDatos = new ReportDataSource(valprocesos[1], dtcredito);
                //dtdetalle = (DataTable)JsonConvert.DeserializeObject(lsttbl[1], typeof(DataTable));
                //DsDetalle = new ReportDataSource("dtDetalle", dtdetalle);

                viewer.LocalReport.DataSources.Clear();
                viewer.LocalReport.DataSources.Add(DsDatos);
                // viewer.LocalReport.DataSources.Add(DsDetalle);
                

                //viewer.LocalReport.SubreportProcessing +=
                //     new SubreportProcessingEventHandler(DemoSubreportProcessingEventHandler);
               
                try
                {                   
                    var Ruta = HttpContext.Current.Server.MapPath(Reporte+ ".pdf");

                    if (File.Exists(Ruta))
                    { File.Delete(Ruta); }

                    viewer.LocalReport.Refresh();

                    byte[] bytes = viewer.LocalReport.Render("PDF", null, out mineType, out encoding, out extension, out streamIds, out warnings);
                    File.WriteAllBytes(Ruta, bytes);

                    var Rutaxls = HttpContext.Current.Server.MapPath(Reporte + ".xls");
                    if (File.Exists(Rutaxls))
                    { File.Delete(Rutaxls); }

                    byte[] reportData = viewer.LocalReport.Render("excel");
                    using (Stream stream = new FileStream(Rutaxls, FileMode.Create))
                    {
                        stream.Write(reportData, 0, reportData.Length);
                    }                    

                     dtcredito.Dispose();
                                        
                    result[0] = "0";
                    result[1] = "";
                    result[2] = Reporte+".pdf" ;                  
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
                result[3] = null;
            }
            return result;
        }
      
        private static void DemoSubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new ReportDataSource("dtDetalle", dtdetalle));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static string[] Exportar_Reporte(string Reporte)
        {
            string[] result = { "", "", "" };
            return result;
        }
    }
}