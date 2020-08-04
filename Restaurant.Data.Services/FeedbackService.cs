using Restaurant.Data.Services.Base;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Data.Services
{
    public class FeedbackService : BaseService<Feedback>, IFeedbackRepository
    {
       
    }
}
