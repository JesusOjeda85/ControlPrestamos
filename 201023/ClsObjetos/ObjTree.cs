using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   public class ObjTree
    {
        public int Id { get; set; }
        public int clave { get; set; }
        public string strclave { get; set; }
        public string text { get; set; }        
        public string nombre { get; set; }
        public string target { get; set; }
        public string state { get; set; }
        public string url { get; set; }
        public Boolean visible { get; set; }
        public Boolean checkbox { get; set; }
        public int? IdPadre { get; set; }
        public List<ObjTree> children { get; set; }
    }
}
