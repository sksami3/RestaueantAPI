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
    [Route("[controller]"+"es")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishRepository _dishRepository;

        public DishController(IDishRepository dishRepository)
        {
            this._dishRepository = dishRepository;
        }
        // GET: /Restaurant
        [HttpGet]
        public async Task<IList<Dish>> Get()
        {
            return await _dishRepository.GetAll();
        }

        // GET: /Restaurant/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Dish> Get(int id)
        {
            return await _dishRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<Dish> Post(Dish dish)
        {
            return await _dishRepository.Create(dish);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public async Task<Dish> Put(int id,Dish dish)
        {
            return await _dishRepository.Update(id,dish);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Dish> Delete(int id)
        {
            return await _dishRepository.Delete(id);
        }
    }
}
