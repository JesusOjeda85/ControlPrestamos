using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class BuscarEmpleado
    {
        public int Desde { get; set; }
        public int Hasta { get; set; }     
        public int IdUsuario { get; set; }
        public int Id { get; set; }
        public int FkOrganismo { get; set; }
        public int FkConcepto { get; set; }
        public int FkTipoPuesto { get; set; }
        public string Busqueda { get; set; }
        public string Modulo { get; set; }  
    }
}
