using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepositoryEntityBase<Tid,T> where T : DBClass<Tid>
    {
        IQueryable<T> GetAll();
        Task AddAsync(T Entity);
        Task UpdateAsync(T Entity);
        Task<T> GetByIdAsync(Tid id);
        Task DeleteAsync(Tid id);
    }
}
