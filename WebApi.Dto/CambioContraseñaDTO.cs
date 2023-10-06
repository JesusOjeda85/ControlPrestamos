using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class CambioContraseñaDTO
    {
        [Required(ErrorMessage = "Id del Usuario es Requerido")]
        [Display(Name = "Id Usuario")]
        public int Idusuario { get; set; }
        [Required(ErrorMessage = "La Contraseña es Requerida")]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
        [Display(Name = "Contraseña Nueva")]
        public string ContraseñaNueva { get; set; }
    }
}
