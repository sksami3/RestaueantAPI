using Restaurant.Domain.Domains.Base;
using Restaurant.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Restaurant.Data.Infrustructure.Helper;

namespace Restaurant.Data.Services.Base
{
    public class BaseService<T> : IBaseRepository<T> where T : BaseModel
    {
        protected ISession _session;
        public BaseService()
        {
            if (_session == null)
                _session = NHibernateHelper.OpenSession();
        }
        public Task<T> Create(T T)
        {
            return Task.Run(() =>
            {
                _session.SaveAsync(T);
                return T;
            });
        }

        public Task<T> Delete(int id)
        {
            try
            {
                var entity = GetById(id);
                _session.Delete(entity);
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Task<IList<T>> GetAll()
        {
            return _session.QueryOver<T>().ListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _session.QueryOver<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task<T> Update(int id, T T)
        {
            var entity = GetById(id);
            try
            {
               _session.UpdateAsync(entity);
                return entity;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
