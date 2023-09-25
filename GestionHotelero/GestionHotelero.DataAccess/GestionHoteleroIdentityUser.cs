using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GestionHotelero.DataAccess
{
    public class GestionHoteleroIdentityUser : IdentityUser
    {
        [StringLength(50)]
        public string Nombre { get; set; } = default!;

        [StringLength(50)]
        public string Apellido { get; set; } = default!;
    }
}