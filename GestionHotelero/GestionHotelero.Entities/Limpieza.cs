using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionHotelero.Entities
{
    public class Limpieza
    {
        [Key]
        public int IdLimpieza { get; set; }
        public int IdHabitacion { get; set; }
        [ForeignKey("IdHabitacion")]
        public Habitacion Habitacion { get; set; } = default!;
        public int IdEmpleado { get; set; }
        [ForeignKey("IdEmpleado")]
        public Empleado Empleado { get; set; } = default!;
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha valida")]
        public DataType Fecha { get; set; }
        [DataType(DataType.Time, ErrorMessage = "Ingrese una hora válida")]
        public DateTime HoraInicio { get; set; }
        [DataType(DataType.Time, ErrorMessage = "Ingrese una hora válida")]
        public DateTime HoraFinal { get; set; }
    }
}
