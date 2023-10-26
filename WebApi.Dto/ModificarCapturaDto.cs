using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class ModificarCapturaDto
    {
        public int Id { get; set; }
        public int FkUsuarioCaptura { get; set; }      
        public int Empleado { get; set; }
        public Int64 ImporteCredito { get; set; }
        public int FkPlazo { get; set; }
        public int FkTipoPago { get; set; }
        public int FkBanco { get; set; }
        public string Cuenta { get; set; }
    }
}
