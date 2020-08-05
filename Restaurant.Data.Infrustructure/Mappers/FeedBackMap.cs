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
            Map(x => x.firstname);
            Map(x => x.lastname);
            Map(x => x.telnum);
            Map(x => x.message);
            Map(x => x.agree);
            Map(x => x.contacttype);
            Map(x => x.email);
            Map(x => x.CreatedBy).Column("username");
            Map(x => x.CreatedDate);
            //Map(x => x.UpdatedBy).Column("updatedby");
            Map(x => x.UpdatedDate).Column("modifieddate");
        }
    }
}
