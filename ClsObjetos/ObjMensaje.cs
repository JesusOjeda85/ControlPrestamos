using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsObjetos
{
   
        public class ObjMensaje
        {
            public int Error { get; set; }
            public string Mensaje { get; set; }
            public object Data { get; set; }
            public string Datos { get; set; }

            public ObjMensaje()
            {
                this.Error = 0;
            }
        }
    
}
