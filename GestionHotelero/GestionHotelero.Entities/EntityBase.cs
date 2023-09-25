namespace GestionHotelero.Entities
{
    public class EntityBase
    {
        public int IdCliente { get; set; }
        public bool Condicion { get; set; }

        protected EntityBase()
        {
            Condicion = true;
        }
    }
}
