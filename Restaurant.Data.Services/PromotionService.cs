using Restaurant.Data.Services.Base;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Data.Services
{
    public class PromotionService : BaseService<Promotion>, IPromotionRepository
    {
        public Task<IList<Promotion>> GetByFeaturedPromotions(bool featured)
        {
            return _session.QueryOver<Promotion>().Where(x => x.Featured.Equals(featured)).ListAsync();
        }
    }
}
