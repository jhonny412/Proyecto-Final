using GestionHotelero.Dto.Response;

namespace GestionHotelero.Presentacion.Models
{
    public class ClienteView
    {
        public ICollection<ClienteDtoResponse> Clientes { get; set; } = new List<ClienteDtoResponse>();

        public DeleteConfirmationModel Delete { get; set; } = new() { Controlador = "Clientes" };
    }
}
