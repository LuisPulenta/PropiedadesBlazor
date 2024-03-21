using System.ComponentModel.DataAnnotations;

namespace Propiedades.Modelos.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string NombreCategoria { get; set; } = null!;

        public string? Descripcion { get; set; } = null!;
    }
}
