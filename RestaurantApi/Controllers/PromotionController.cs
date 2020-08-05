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
    [Route("[controller]"+"s")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;

        public PromotionController(IPromotionRepository promotionRepository)
        {
            this._promotionRepository = promotionRepository;
        }
        // GET: api/Promotion
        [HttpGet]
        public async Task<IList<Promotion>> Get()
        {
            return await _promotionRepository.GetAll();
        }

        // GET: /Restaurant/5
        [HttpGet("{id}", Name = "GetPromotion")]
        public async Task<Promotion> Get(int id)
        {
            return await _promotionRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<Promotion> Post(Promotion Promotion)
        {
            return await _promotionRepository.Create(Promotion);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public async Task<Promotion> Put(int id, Promotion Promotion)
        {
            return await _promotionRepository.Update(id, Promotion);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Promotion> Delete(int id)
        {
            return await _promotionRepository.Delete(id);
        }
    }
}
