using GestionHotelero.DataAccess;
using GestionHotelero.Entities;
using GestionHotelero.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionHotelero.Repositories.Implementacion
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            var query = _context.Set<TEntity>()
                .AsQueryable();

            if (predicate is not null)
                query = query.Where(predicate);

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TInfo>> ListAsync<TInfo>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TInfo>> selector,
            string? relationships = null)
        {
            var query = _context.Set<TEntity>()
                .Where(predicate)
                .AsQueryable();

            // SELECT de Clientes, "TipoCliente"
            // SELECT de Producto, "Categoria, Marca"

            if (!string.IsNullOrWhiteSpace(relationships))
            {
                foreach (var tabla in relationships.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(tabla);
                }
            }

            return await query
                .Select(selector)
                .ToListAsync();
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.IdCliente;
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await FindByIdAsync(id);
            if (entity != null)
            {
                entity.Condicion = false;
                await UpdateAsync();
            }
            else
            {
                throw new InvalidOperationException($"No se encontro el registro con el id {id}");
            }
        }
    }
}
