using System.ComponentModel.DataAnnotations;

namespace GestionHotelero.Presentacion.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        [StringLength(50), Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = default!;
        [StringLength(50), Required(ErrorMessage = "El {0} es obligatorio")]
        public string Apellido { get; set; } = default!;
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Ingrese un dato valido")]
        [Display(Name = "Numero Documento")]
        public string NroDocumento { get; set; } = default!;
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string Email { get; set; } = default!;
        [MaxLength(9, ErrorMessage = "Solo puede ingresar 9 numeros")]
        public string Telefono { get; set; } = default!;
        [Display(Name = "Dirección")]
        public string Direccion { get; set; } = default!;
        [DataType(DataType.Date, ErrorMessage = "Ingrese una fecha válida")]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public bool Condicion { get; set; } = default!;
    }
}
