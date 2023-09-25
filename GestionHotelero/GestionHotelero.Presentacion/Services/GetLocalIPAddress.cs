#nullable disable
using System.Net;

namespace GestionHotelero.Presentacion.Services
{
    public class GetLocalIPAddress
    {
        public static string GetLocalIPAddressWithNetwork()
        {
            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            return ipEntry.AddressList[1].ToString() + " (" + ipEntry.HostName + ")";
        }
    }
}
