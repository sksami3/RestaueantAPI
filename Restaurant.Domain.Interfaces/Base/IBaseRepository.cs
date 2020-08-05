using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces.Base
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T T);
        Task<T> Delete(int id);
        Task<T> Update(int id, T T);

    }
}
