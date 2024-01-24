using System.ComponentModel.DataAnnotations;

namespace ClienteBlogBlazorWASM.Modelos
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; }

        public string DescripcionHtml { get; set; } // Versión HTML

        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "Las etiquetas son obligatorias")]
        public string Etiquetas { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaActualizacion { get; set; }

        public int? UsuarioId { get; set; }
    }
}
