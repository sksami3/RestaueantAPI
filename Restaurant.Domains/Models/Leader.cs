using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models
{
    public class Leader : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual string Image { get; set; }
        public virtual string Designation { get; set; }
        public virtual string abbr { get; set; }
        public virtual bool Featured { get; set; }
        public virtual string Description { get; set; }
    }
}
