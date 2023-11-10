using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{    
    public class ArchivoLiquidez
    { 
        public string Rfc { get; set; }
        public string Nombre { get; set; }
        public int Empleado { get; set; }
        public double Percepciones { get; set; }
        public double DeduccionesLey { get; set; }
        public double DeduccionesSindicales { get; set; }
        public double PensionAlimenticia { get; set; }
        public double Terceros { get; set; }
        public double Liquidez { get; set; }
    }
}
