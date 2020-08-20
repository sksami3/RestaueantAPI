using Microsoft.AspNetCore.Http;
using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Domain.Domains.Models.AuthModels
{
    public class User : BaseModel
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
        public virtual string Token { get; set; }
        public virtual string Image { get; set; }
        public virtual string Email { get; set; }
    }
}