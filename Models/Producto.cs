using System.ComponentModel.DataAnnotations;


namespace CatalogoProductos.Models
{
    public class Producto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 999999)]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 10000)]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaRegistro{ get; set;}
}
}