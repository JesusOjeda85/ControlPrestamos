using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosCaptura
    {
        public int idusuario { get; set; }
        public int fkorganismo { get; set; }
        public int Empleado { get; set; }
        public string fechasolicitud { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public string nombres { get; set; }
        public string nombrecompleto { get; set; }
        public string cvepagaduria { get; set; }
        public string despagaduria { get; set; }
        public string cvecategoria { get; set; }
        public string descategoria { get; set; }
        public string cveadscripcion { get; set; }
        public string desadscripcion { get; set; }
        public Int64 importecredito { get; set; }
        public int fkplazo { get; set; }

    }
}
