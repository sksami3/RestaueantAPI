﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Domains.Models;
using Restaurant.Domain.Interfaces;

namespace RestaurantApi.Controllers
{
    [Route("leadership")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        // GET: api/Leader
        private readonly ILeaderRepository _leaderRepository;

        public LeaderController(ILeaderRepository leaderRepository)
        {
            this._leaderRepository = leaderRepository;
        }
        // GET: api/Leader
        [HttpGet]
        public async Task<IList<Leader>> Get()
        {
            return await _leaderRepository.GetAll();
        }

        // GET: /Restaurant/5
        [HttpGet("{id}", Name = "GetLeader")]
        public async Task<Leader> Get(int id)
        {
            return await _leaderRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        public async Task<Leader> Post(Leader leader)
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            leader.CreatedBy = userId;

            leader.Image = Path.Combine("Images", "ProfilePictures") + "/" + leader.Image;
            return await _leaderRepository.Create(leader);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public async Task<Leader> Put(int id, Leader Leader)
        {
            return await _leaderRepository.Update(id, Leader);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<Leader> Delete(int id)
        {
            return await _leaderRepository.Delete(id);
        }
    }
}
