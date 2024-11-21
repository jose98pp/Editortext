using System.ComponentModel.DataAnnotations;

namespace Editortext.Models
{
    public class ArchivoEditor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Titulo { get; set; } // Título del archivo

        [Required]
        public string Contenido { get; set; } // Contenido HTML generado por TinyMCE

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; }
    }
}
