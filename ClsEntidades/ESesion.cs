using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClsEntidades.Inicio
{
    public class ESesion
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string VigenciaIni { get; set; }
        public string Area { get; set; }
        public string QuinMulti { get; set; }
        public string QuiAct { get; set; }
        public string AñoAct { get; set; }
        public string Error { get; set; }
        public string Mensaje { get; set; }
        public string TipoQuin { get; set; }
    }
}
