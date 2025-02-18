using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class DatosPadron
    {
        public int IdUsuario { get; set; }
        public int CvePerfil { get; set; }
        public int FkOrganismo { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
    }
}
