using Domain.Entities;
using Infrastructure.Persistence_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryEntityBase<TId, T>
        : IRepositoryEntityBase<TId, T>
        where T : DBClass<TId>
    {
        protected readonly AppDbContext _context;

        public RepositoryEntityBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<T?> GetByIdAsync(TId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;

            _context.Set<T>().Remove(entity);
        }
    }
}
