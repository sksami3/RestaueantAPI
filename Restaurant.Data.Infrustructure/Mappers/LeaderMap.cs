using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Infrustructure.Mappers
{
    public class LeaderMap : ClassMap<Leader>
    {
        public LeaderMap()
        {
            Table("Leaderships");
            Id(x => x.Id);
            Map(x => x.abbr);
            Map(x => x.CreatedBy).Column("createdby");
            Map(x => x.CreatedDate).Column("createddate");
            Map(x => x.Description).Column("description");
            Map(x => x.Designation).Column("designation");
            Map(x => x.Featured).Column("featured");
            Map(x => x.Image).Column("image");
            Map(x => x.Name).Column("name");
            //Map(x => x.UpdatedBy).Column("updatedby");
            //Map(x => x.UpdatedDate).Column("updateddate");
            Map(x => x.UpdatedDate).Column("modifieddate");
        }
    }
}
