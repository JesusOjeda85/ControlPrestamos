using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class DatosPagosExternos
    {
        public int Id { get; set; }
        public decimal Importe { get; set; }
        public string FecCaptura { get; set; }
        public string Observaciones { get; set; }
    }
}
