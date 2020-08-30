using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models.ViewModels
{
    public class MenuViewModel : BaseModel
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public string parent { get; set; }
    }
}
