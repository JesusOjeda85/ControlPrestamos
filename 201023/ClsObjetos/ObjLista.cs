using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   public class ObjLista
    {
        public int Id { get; set; }
        public string clave { get; set; }
        public string text { get; set; }
        public string name { get; set; }
        public string nombre { get; set; }
        public string visible { get; set; }
        public int? IdPadre { get; set; }
        public string attributes { get; set; }
        public List<ObjLista> children { get; set; }
    }
}
