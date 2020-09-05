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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IList<Promotion>> Get()
        {
            return await _promotionRepository.GetAll();
        }

        // GET: /Restaurant/5
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetPromotion")]
        public async Task<Promotion> Get(int id)
        {
            return await _promotionRepository.GetById(id);
        }

        // POST: api/Restaurant
        [Authorize(Policy = Role.Admin)]
        [HttpPost]
        public async Task<Promotion> Post(Promotion promotion)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            promotion.CreatedBy = userId;

            promotion.Image = Path.Combine("Images", "ProfilePictures") + "/" + promotion.Image;
            return await _promotionRepository.Create(promotion);
        }

        // PUT: api/Restaurant/5
        [Authorize(Policy = Role.Admin)]
        [HttpPut("{id}")]
        public async Task<Promotion> Put(int id, Promotion Promotion)
        {
            return await _promotionRepository.Update(id, Promotion);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize(Policy = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<Promotion> Delete(int id)
        {
            return await _promotionRepository.Delete(id);
        }
    }
}
