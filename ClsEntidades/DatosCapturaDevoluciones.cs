using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosCapturaDevoluciones
    {
        public int Id { get; set; }
        public int FkCredito { get; set; }
        public double Importe { get; set; }
        public string ChequeRecibo { get; set; }
    }
}
