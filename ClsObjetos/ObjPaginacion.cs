using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   public class ObjPaginacion
    {
        public int Desde { get; set; }

        public int Hasta { get; set; }

        public int Pagina { get; set; }
        public string Busqueda { get; set; }
       
        public string Tabla { get; set; }
        public string Multi { get; set; }
    }
}
