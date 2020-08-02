using Restaurant.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface IDishRepository : IDisposable
    {
        Task<IList<Dish>> GetAll();
        Task<Dish> GetById(int id);
        Task<IList<Dish>> GetByFeatured();
        Task<Dish> Create(Dish dish);
        Task<Dish> Delete(int id);
        Task<Dish> Update(int id, Dish dish);
    }
}
