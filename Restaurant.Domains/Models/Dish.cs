using Restaurant.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domains.Models
{
    public class Dish : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Catagory { get; set; }
        public virtual bool Featured { get; set; }
        public virtual string Label { get; set; }
        public virtual string Price { get; set; }
        public virtual string Description { get; set; }
    }
}
