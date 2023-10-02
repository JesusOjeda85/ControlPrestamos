using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   public class ObjCatalogo
    {
        public string Tabla { get; set; }
        public string Valor { get; set; }
        public string Descripcion { get; set; }
        public string Query { get; set; }
        public string CveCat { get; set; }
        public string DesCat { get; set; }
        public string Ddlobj { get; set; }
        public string Relacion { get; set; }
        public bool Selected { get; set; }       
    }
}
