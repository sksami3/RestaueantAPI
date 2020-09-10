using Restaurant.Domain.Domains.Base;
using Restaurant.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using Restaurant.Data.Infrustructure.Helper;
using System.Transactions;

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
            try
            {
                T.CreatedDate = DateTime.Now;
                T.UpdatedDate = DateTime.Now;
                using (var transaction = _session.BeginTransaction())
                {

                    _session.Save(T);
                    transaction.Commit();
                    return Task.Run(() =>
                    {
                        return T;
                    });
                }
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<T> Delete(int id)
        {
            try
            {
                using (var transaction = _session.BeginTransaction())
                {
                    var entity = await GetById(id);
                    _session.Delete(entity);
                    _session.Flush();
                    transaction.Commit();

                    return entity;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public void Dispose()
        {
            if (_session == null) return;
            //_session.Close();
            _session.Dispose();
        }

        public Task<IList<T>> GetAll()
        {
            return _session.QueryOver<T>().ListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _session.QueryOver<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task<T> Update(int id, T T)
        {
            var entity = await GetById(id);
            try
            {
                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(entity);
                    transaction.Commit();
                    return entity;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
