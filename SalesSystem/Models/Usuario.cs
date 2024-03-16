using System.ComponentModel.DataAnnotations;

namespace SalesSystem.Models
{
    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string ConfirmarContraseña { get; set; }
        [Required(ErrorMessage = "El usuario es obligatorio.")]

        public string Contraseña { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 3)]

        public string ErrorMessage { get; set; }
    }
}
