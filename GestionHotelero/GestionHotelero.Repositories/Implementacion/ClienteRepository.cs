using GestionHotelero.DataAccess;
using GestionHotelero.Dto.Response;
using GestionHotelero.Entities;
using GestionHotelero.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionHotelero.Repositories.Implementacion;

public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
{
    public ClienteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ICollection<ClienteDtoResponse>> GetAllAsync(string? filter)
    {
        var query = _context.Clientes
            .OrderBy(p => p.Nombre)
            .AsQueryable();

        if (!string.IsNullOrEmpty(filter))
            query = query
                .Where(p => p.Nombre.Contains(filter));

        return await query
            .Select(x => new ClienteDtoResponse()
            {
                IdCliente = x.IdCliente,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Email = x.Email,
                Telefono = x.Telefono.ToString(),
                Direccion = x.Direccion,
                FechaNacimiento = x.FechaNacimiento,
                NroDocumento = x.NroDocumento
            })
            .ToListAsync();
    }
}
