using System.ComponentModel.DataAnnotations;

namespace Propiedades.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreCategoria { get; set; } = null!;

        public string? Descripcion { get; set; } = null!;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<Propiedad>? Propiedades { get; set; }
    }
}
 