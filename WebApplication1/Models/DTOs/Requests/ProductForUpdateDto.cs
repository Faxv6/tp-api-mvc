using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs.Requests
{
    public class ProductForUpdateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        public string Name { get; set; } = "";
        [Range(0.0000001, 99999999, ErrorMessage = "El precio debe ser mayor a 0")]

        public decimal Price { get; set; }
    }
}
