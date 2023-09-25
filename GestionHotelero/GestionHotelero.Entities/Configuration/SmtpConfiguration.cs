namespace GestionHotelero.Entities.Configuration
{
    public class SmtpConfiguration
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Server { get; set; } = default!;
        public int PortNumber { get; set; }
        public string FromName { get; set; } = default!;
        public bool EnableSsl { get; set; }
    }
}