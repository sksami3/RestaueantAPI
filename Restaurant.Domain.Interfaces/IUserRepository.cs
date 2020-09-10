using Restaurant.Domain.Domains.Models.AuthModels;
using Restaurant.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Authenticate(string username, string password);
        //Task<IEnumerable<User>> GetAll();
        //Task<User> GetById(int id);
        Task<User> GetByUsernameAndPass(string username, string password);
        Task<User> GetByEmail(string email);

    }
}
