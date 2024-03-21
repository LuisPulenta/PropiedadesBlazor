using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Propiedades.Modelos
{
    public class ImagenPropiedad
    {
        [Key]
        public int Id { get; set; }

        public int PropiedadId { get; set; }

        public string UrlImagenPropiedad { get; set; } = null!;
        
        [ForeignKey("PropiedadId")]
        public Propiedad Propiedad { get; set; } = null!;
    }
}
