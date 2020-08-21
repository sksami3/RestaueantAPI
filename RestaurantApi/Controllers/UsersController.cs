using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using Restaurant.Domain.Domains.Models.AuthModels;
using Restaurant.Domain.Domains.Models.ViewModels;
using Restaurant.Domain.Interfaces;
using RestSharp;

namespace RestaurantApi.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userService;
        //private UserManager<ApplicationUser> _userManager;

        public UsersController(IUserRepository userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        //[Authorize(Policy = Role.Admin)]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }


        [Authorize(Policy = Role.User)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/Users
        //[Authorize(Roles = Role.Admin)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<User> Post(User user)
        {
            user.CreatedBy = user.Username;
            user.Image = Path.Combine("Images", "ProfilePictures")+ "/" + user.Image;
            return await _userService.Create(user);
        }

        [HttpPost("profilepictureuploader"), DisableRequestSizeLimit]
        [AllowAnonymous]
        public IActionResult ProfilePictureUploader()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images", "ProfilePictures");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(fileName);
                }
                else
                {
                    return BadRequest(new { message = "Bad request" });
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
