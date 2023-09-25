using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotelero.Entities
{
    [Index(nameof(NumeroHabitacion), IsUnique = true)]
    public class Habitacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHabitacion { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Column(TypeName = "int")]
        public int NumeroHabitacion { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoHabitacion { get; set; } = default!;

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; } = default!;

        [Required]
        [StringLength(20)]
        [DefaultValue("Disponible")]
        public string Estado { get; set; } = default!;
        //[Required]
        //[DisplayName("Condicion")]
        //public bool Condicion { get; set; }
    }
}
