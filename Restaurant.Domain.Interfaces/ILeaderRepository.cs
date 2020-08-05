using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Interfaces
{
    public interface ILeaderRepository : IBaseRepository<Leader>
    {
        Task<IList<Leader>> GetByFeaturedLeaders(bool featured);
    }
}
