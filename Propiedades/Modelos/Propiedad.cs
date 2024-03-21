using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propiedades.Modelos
{
    public class Propiedad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        [Required]
        public string? Descripcion { get; set; } = null!;
       
        [Required]
        public int Area { get; set; }

        [Required] public int Habitaciones { get; set; }
        public int Banios { get; set; }

        [Required] 
        public int Parqueadero { get; set; }

        [Required] 
        public double Precio { get; set; }

        [Required] 
        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaActualizacion { get; set; }
        
        public int CategoriaId { get; set; }
        
        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; } = null!;

        public virtual ICollection<ImagenPropiedad>? ImagenesPropiedad { get; set; }
    }
}
