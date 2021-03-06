﻿using Microsoft.IdentityModel.Tokens;
using Restaurant.Data.Services.Base;
using Restaurant.Data.Services.Helpers;
using Restaurant.Domain.Domains.Models.AuthModels;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Data.Services.Helpers;
using Microsoft.Extensions.Options;
using BCrypt.Net;

namespace Restaurant.Data.Services
{
    public class UserService : BaseService<User>, IUserRepository
    {
        private readonly AppSettings _appSettings;
 

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            //var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            User user = await GetByUsernameAndPass(username, password);

            // return null if user not found
            if (user == null)
                return null;

            GenerateToken(user);
            return user.WithoutPassword();
        }

        private User GenerateToken(User user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            try
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName ),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<User> GetByEmail(string email)
        {
            User user = await _session.QueryOver<User>().Where(x => x.Email == email).SingleOrDefaultAsync();
            GenerateToken(user);
            return user.WithoutPassword();
        }

        public async Task<User> GetByUsernameAndPass(string username, string password)
        {
            try
            {
                User user = await _session.QueryOver<User>().Where(x => x.Username == username).SingleOrDefaultAsync();
                if (user!= null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    return user;
                else
                {
                    user = null;
                    return null;
                }
                    
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
