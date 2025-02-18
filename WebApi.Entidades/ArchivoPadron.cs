using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class ArchivoPadron
    {
        public int Empleado { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombre { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public string TipoPuesto { get; set; }

    }
}
