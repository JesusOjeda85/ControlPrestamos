using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El Usuario es Requerido")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La Contraseña es Requerida")]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; }
    }
}
