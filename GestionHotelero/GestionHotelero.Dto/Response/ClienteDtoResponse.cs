namespace GestionHotelero.Dto.Response
{
    public class ClienteDtoResponse
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = default!;
        public string Apellido { get; set; } = default!;
        public string NroDocumento { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Telefono { get; set; } = default!;
        public string Direccion { get; set; } = default!;
        public DateTime FechaNacimiento { get; set; }
    }
}
