using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosCapturaSiniestros
    {
        public int Id { get; set; }
        public string Rfc { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombres { get; set; }
        public int FkTipoPuesto { get; set; }
        public string Beneficiario { get; set; }
        public int FkCausaMuerte { get; set; }
        public int FkConceptoSiniestro { get; set; }
        public double ImporteBruto { get; set; }
        public double ImporteAdeudo { get; set; }
        public double ImporteNeto { get; set; }
        public int FkTipoPago { get; set; }
        public int FkBanco { get; set; }
        public string Cuenta { get; set; }
        public string FechaSolicitud { get; set; }
        public int FkOrganismo { get; set; }
        public int FkUsuarioCaptura { get; set; }
        public int FkZonaPago { get; set; }
        public string TipoProceso { get; set; }
    }
}
