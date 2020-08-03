using Restaurant.Data.Services.Base;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Data.Services
{
    public class DishService : BaseService<Dish>, IDishRepository
    {
        public Task<IList<Dish>> GetByFeaturedDishes(bool featured)
        {
            return _session.QueryOver<Dish>().Where(x => x.Featured == featured).ListAsync();
        }
    }
}
