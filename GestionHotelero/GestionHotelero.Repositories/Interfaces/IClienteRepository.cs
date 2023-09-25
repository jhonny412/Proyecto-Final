using GestionHotelero.Dto.Response;
using GestionHotelero.Entities;

namespace GestionHotelero.Repositories.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<ICollection<ClienteDtoResponse>> GetAllAsync(string? filter);
    }
}
