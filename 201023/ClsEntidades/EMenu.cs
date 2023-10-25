using System;
using System.Collections.Generic;

namespace ClsEntidades.Inicio
{
    public class EMenu
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public string UrlImagen { get; set; }
        public string NombreTab { get; set; }
        public string NombreRep { get; set; }
        public int? Propietario { get; set; }
        public int Orden { get; set; }
        public Boolean Visible { get; set; }
        public List<EMenu> List { get; set; }
    }
}
