using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosAplicar
    {
        public int FkUsuarioAutoriza { get; set; }
        public int Quincena { get; set; }
        public int Año { get; set; }
        public string Emision { get; set; }
        public string Aplicados { get; set; }
        public string Rechazados { get; set; }
    }
}
