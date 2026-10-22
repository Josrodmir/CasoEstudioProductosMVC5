using System.ComponentModel.DataAnnotations;
namespace CasoEstudioProductosMVC5.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El código es obligatorio.")][StringLength(12, ErrorMessage = "Máximo 12 caracteres.")][Display(Name = "Código")] public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")][StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 80 caracteres.")] public string Nombre { get; set; }
        [Required(ErrorMessage = "La categoría es obligatoria.")][StringLength(40, ErrorMessage = "Máximo 40 caracteres.")] public string Categoria { get; set; }
        [Required(ErrorMessage = "Seleccione cómo se vende el producto.")][Display(Name = "Se vende por")] public TipoProducto TipoProducto { get; set; } = TipoProducto.PorUnidad;
        [Range(0.01, 9999999, ErrorMessage = "El precio debe ser mayor que cero.")][Display(Name = "Precio por unidad / kg")] public decimal Precio { get; set; }
        [Range(0, 9999, ErrorMessage = "La existencia debe estar entre 0 y 9999.")] public int Existencia { get; set; }
        public bool Activo { get; set; } = true;
    }
}
