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

namespace ControlDescuentos.Archivos.Numeracion
{
    public partial class Descargar_Excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Fileid"] != null)
                {
                    string nombrearchivo = Request.QueryString["Fileid"].ToString();

                    System.IO.FileStream fs = null;
                    fs = System.IO.File.Open(Server.MapPath("../ArchivosRdlc/" + nombrearchivo + ".xls"), System.IO.FileMode.Open);
                    byte[] txtbyte = new byte[fs.Length];
                    fs.Read(txtbyte, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    Response.AddHeader("Content-disposition", "attachment; filename=" + nombrearchivo + ".xls");
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(txtbyte);
                    Response.End();
                }

            }
        }

    }
}