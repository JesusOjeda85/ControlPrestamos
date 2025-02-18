using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosCancelaciones
    {
        public int Id { get; set; }

        public string Observaciones { get; set; }

        public string FecCaptura { get; set; }
        
        public string Modulo { get; set; }
    }
}
