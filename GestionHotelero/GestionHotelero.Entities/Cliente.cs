using System.ComponentModel.DataAnnotations;

namespace GestionHotelero.Entities;

public class Cliente : EntityBase
{
    [Key]
    public int IdCliente { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "La maxima cantidad de caracteres es de 50")]
    public string Nombre { get; set; } = default!;
    [StringLength(50, ErrorMessage = "La maxima cantidad de caracteres es de 50")]
    public string Apellido { get; set; } = default!;
    public string NroDocumento { get; set; } = default!;
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Telefono { get; set; } = default!;
    public string Direccion { get; set; } = default!;
    public DateTime FechaNacimiento { get; set; }
    //[Display(Name = "Condicion")]
    //public bool Condicion { get; set; } = true;
}
