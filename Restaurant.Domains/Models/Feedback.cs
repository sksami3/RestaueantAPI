using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models
{
    public class Feedback : BaseModel
    {
        public virtual string firstname { get; set; }
        public virtual string lastname { get; set; }
        public virtual long telnum { get; set; }
        public virtual string email { get; set; }
        public virtual string agree { get; set; }
        public virtual string contacttype { get; set; }
        public virtual string message { get; set; }
    }
}
