using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class DatosCaptura
    {
        public int IdUsuario { get; set; }
        public int FkOrganismo { get; set; }
        public int Empleado { get; set; }
        public string FechaSolicitud { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }        
        public string CvePagaduria { get; set; }
        public string DesPagaduria { get; set; }
        public string CveCategoria { get; set; }
        public string DesCategoria { get; set; }
        public string CveAdscripcion { get; set; }
        public string DesAdscripcion { get; set; }
        public Int64 ImporteCredito { get; set; }
        public int FkPlazo { get; set; }
        public int FkTipoPago { get; set; }
        public int FkBanco { get; set; }
        public Int64 Cuenta { get; set; }
    }
}
