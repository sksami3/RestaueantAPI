using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Infrustructure.Mappers
{
    public class FeedBackMap :ClassMap<Feedback>
    {
        public FeedBackMap()
        {
            Table("FeedBacks");
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.TelNum);
            Map(x => x.Message);
            Map(x => x.Agree);
            Map(x => x.ContactType);
            Map(x => x.Email);
            Map(x => x.CreatedBy).Column("username");
            Map(x => x.CreatedDate);
            //Map(x => x.UpdatedBy).Column("updatedby");
            Map(x => x.UpdatedDate).Column("modifieddate");
        }
    }
}
