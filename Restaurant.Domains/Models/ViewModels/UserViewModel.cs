using Microsoft.AspNetCore.Http;
using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models.ViewModels
{
    public class UserViewModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string image { get; set; }
    }
}
