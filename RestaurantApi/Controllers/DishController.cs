using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Domains.Models.AuthModels;
using Restaurant.Domain.Interfaces;

namespace RestaurantApi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IList<Dish>> Get()
        {
            return await _dishRepository.GetAll();
        }

        // GET: /Restaurant/5
        [AllowAnonymous]
        [HttpGet("{id}", Name = "Get")]
        public async Task<Dish> Get(int id)
        {
            return await _dishRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        [Authorize(Policy = Role.Admin)]
        public async Task<Dish> Post(Dish dish)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            dish.CreatedBy = userId;

            dish.Image = Path.Combine("Images", "ProfilePictures") + "/" + dish.Image;
            return await _dishRepository.Create(dish);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        [Authorize(Policy = Role.Admin)]
        public async Task<Dish> Put(int id,Dish dish)
        {
            return await _dishRepository.Update(id,dish);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Role.Admin)]
        public async Task<Dish> Delete(int id)
        {
            return await _dishRepository.Delete(id);
        }
    }
}
