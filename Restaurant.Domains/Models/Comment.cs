using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models
{
    public class Comment : BaseModel
    {
        public virtual int Rating { get; set; }
        public virtual string ViewersComment { get; set; }
        public virtual string Author { get; set; }
        public virtual int Date { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
