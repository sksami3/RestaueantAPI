using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Restaurant.Domain.Domains.Models
{
    public class Comment : BaseModel
    {
        public virtual int Rating { get; set; }
        public virtual string ViewersComment { get; set; }
        public virtual string Author { get; set; }
        public virtual string Date { get; set; }
        [ForeignKey("Dish")]
        public virtual int dishId { get; set; }
        public virtual Dish Dish { get; set; }
    }
}
