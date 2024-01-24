using System.ComponentModel.DataAnnotations;

namespace ClienteBlogBlazorWASM.Modelos
{
    public class UsuarioRegistro
    {

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreDeUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }

      
    }
}
