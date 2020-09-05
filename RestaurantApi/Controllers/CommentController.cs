using System;
using System.Collections.Generic;
using System.Linq;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IDishRepository _dishRepository;

        public CommentController(ICommentRepository commentRepository, IDishRepository dishRepository)
        {
            this._commentRepository = commentRepository;
            _dishRepository = dishRepository;
        }

        // GET: /Restaurant
        [HttpGet]
        public async Task<IList<Comment>> Get()
        {
            return await _commentRepository.GetAll();
        }

        // GET: /Restaurant/5
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<Comment> Get(int id)
        {
            return await _commentRepository.GetById(id);
        }

        // POST: api/Restaurant
        [HttpPost]
        [Authorize(Policy = Role.User)]
        public async Task<Comment> Post(Comment Comment)
        {
            Comment.Dish = await _dishRepository.GetById(Comment.dishId);
            return await _commentRepository.Create(Comment);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        [Authorize(Policy = Role.Admin)]
        public async Task<Comment> Put(int id, Comment Comment)
        {
            return await _commentRepository.Update(id, Comment);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Role.Admin)]
        public async Task<Comment> Delete(int id)
        {
            return await _commentRepository.Delete(id);
        }
    }
}
