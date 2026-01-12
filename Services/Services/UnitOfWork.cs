
using Domain.Entities;
using Infrastructure.Persistence_Context;
using Infrastructure.Repositories;
using Services.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UnitOfWork: IUnitOfWork 
    {
        private readonly AppDbContext _context;

        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

    

        public async Task<int> commit()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepositoryEntityBase<TId, T> Repository<TId, T>() where T : DBClass<TId>
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repo = new RepositoryEntityBase<TId,T>(_context);
                _repositories[type] = repo;
            }

            return (IRepositoryEntityBase<TId, T>)_repositories[type];
        }

        public async Task<int> Commit()
        {
        return  await  _context.SaveChangesAsync();
        }
    }
}
