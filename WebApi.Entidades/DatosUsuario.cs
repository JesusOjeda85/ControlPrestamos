using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidades
{
    public class DatosUsuario
    {
        public int Idusuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string ContraseñaNueva { get; set; }
        public string APPaterno { get; set; }
        public string APMaterno { get; set; }
        public string Nombres { get; set; }
        public Int16 Estatus { get; set; }
        public Int16 Administrador { get; set; }
    }
}
