using Restaurant.Domain.Domains.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Domains.Models
{
    public class Feedback : BaseModel
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual long TelNum { get; set; }
        public virtual string Email { get; set; }
        public virtual string Agree { get; set; }
        public virtual string ContactType { get; set; }
        public virtual string Message { get; set; }
    }
}
