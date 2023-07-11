using System.ComponentModel.DataAnnotations;

namespace MovimientosBodegaSensible.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "No cerrar la sesión")]
        public bool Recuerdame { get; set; }
    }
}
