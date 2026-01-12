using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterFaces
{
    public interface IUnitOfWork
    {
         IRepositoryEntityBase<TId, T> Repository<TId, T>() where T : DBClass<TId>;

        Task<int> Commit();
    }
}
