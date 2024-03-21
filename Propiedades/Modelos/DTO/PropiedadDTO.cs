using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Timers;

namespace Propiedades.Modelos.DTO
{
    public class PropiedadDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "El campo{0} debe tener entre {1} y {2} caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "El campo{0} debe tener entre {1} y {2} caracteres")]
        public string? Descripcion { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1,5000,ErrorMessage = "El valor ingresado en el campo {0} debe ser entre {1} y {2}")]
        public int Area { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, 15, ErrorMessage = "El valor ingresado en el campo {0} debe ser entre {1} y {2}")]
        public int Habitaciones { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, 10, ErrorMessage = "El valor ingresado en el campo Baños debe ser entre {1} y {2}")]
        public int Banios { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, 5, ErrorMessage = "El valor ingresado en el campo {0} debe ser entre {1} y {2}")]
        public int Parqueadero { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public bool Activo { get; set; }

        public int CategoriaId { get; set; }
    }
}
