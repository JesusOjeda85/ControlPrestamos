using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class ArchivoSalida
    {
        public int IdUsuario { get; set; }
        public int CvePerfil { get; set; }
        public int FkOrganismo { get; set; }
        public string Quincena { get; set; }

    }
}
