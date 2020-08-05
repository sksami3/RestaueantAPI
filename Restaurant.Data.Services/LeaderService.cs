using Restaurant.Data.Services.Base;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Data.Services
{
    public class LeaderService : BaseService<Leader>, ILeaderRepository
    {
        public Task<IList<Leader>> GetByFeaturedLeaders(bool featured)
        {
            return _session.QueryOver<Leader>().Where(x => x.Featured == featured).ListAsync();
        }
    }
}
