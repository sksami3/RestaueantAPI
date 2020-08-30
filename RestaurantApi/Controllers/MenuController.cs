using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.Domains.Models.ViewModels;
using Restaurant.Domain.Utility;

namespace RestaurantApi.Controllers
{
    [Route("menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly Utility _utility;
        private readonly IConfiguration configuration;

        public MenuController(IConfiguration config)
        {
            _utility = new Utility();
            configuration = config;
        }
        // GET: api/Menu
        [HttpGet]
        public IList<MenuViewModel> GetMenus()
        {
            return _utility.GetAllMenus(configuration.GetConnectionString("RestaurantConnection"));
        }

        // GET: api/Menu/5
        //[HttpGet("{id}", Name = "Get")]
        //public string GetMenu(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Menu
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Menu/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
