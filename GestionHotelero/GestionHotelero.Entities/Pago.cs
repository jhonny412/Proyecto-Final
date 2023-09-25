using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotelero.Entities
{
    public class Pago
    {
        [Key]
        public int IdEmpleado { get; set; }
        public int IdReservacion { get; set; }
        [ForeignKey("IdReservacion")]
        public Reservacion Reservacio { get; set; } = default!;
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Monto { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPago { get; set; }
    }
}
