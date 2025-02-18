using ClsEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlDescuentos.Archivos.Captura
{
    public partial class Captura_Vista_Previa : System.Web.UI.Page
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