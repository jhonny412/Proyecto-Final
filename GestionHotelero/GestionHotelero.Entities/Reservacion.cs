using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotelero.Entities
{
    public class Reservacion
    {
        [Key]
        public int IdReservacion { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; } = default!;
        public int IdHabitacion { get; set; }
        [ForeignKey("IdHabitacion")]
        public Habitacion Habitacion { get; set; } = default!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
