using ClsEntidades;
using System;
using System.Web;

namespace ControlDescuentos.Archivos.Captura.Retiros
{
    public partial class Impresion_Revision_S : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}