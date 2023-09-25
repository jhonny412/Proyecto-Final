using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotelero.Entities
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "La maxima cantidad de caracteres es de 50"), MinLength(5, ErrorMessage = "Debe ingresar por lo menos 5 caracteres")]
        public string Nombre { get; set; } = default!;
        [StringLength(50, ErrorMessage = "La maxima cantidad de caracteres es de 50"), MinLength(5, ErrorMessage = "Debe ingresar por lo menos 5 caracteres")]
        public string? Apellido { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        [Required]
        public required string Puesto { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salario { get; set; }
        //[Required]
        //[DisplayName("Condicion")]
        //public bool Condicion { get; set; }
    }
}
