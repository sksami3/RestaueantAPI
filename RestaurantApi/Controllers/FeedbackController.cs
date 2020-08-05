using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            this._feedbackRepository = feedbackRepository;
        }
        // GET: api/Feedback
        [HttpGet]
        public async Task<IList<Feedback>> Get()
        {
            return await _feedbackRepository.GetAll();
        }

        // GET: /Restaurant/5
        [HttpGet("{id}", Name = "GetFeedback")]
        public async Task<Feedback> Get(int id)
        {
            return await _feedbackRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<Feedback> Post(Feedback Feedback)
        {
            return await _feedbackRepository.Create(Feedback);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public async Task<Feedback> Put(int id, Feedback Feedback)
        {
            return await _feedbackRepository.Update(id, Feedback);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Feedback> Delete(int id)
        {
            return await _feedbackRepository.Delete(id);
        }
    }
}
