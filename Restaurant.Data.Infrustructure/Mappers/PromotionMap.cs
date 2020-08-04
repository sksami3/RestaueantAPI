using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Infrustructure.Mappers
{
    public class PromotionMap : ClassMap<Promotion>
    {
        public PromotionMap()
        {
            Table("Promotions");
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Price).Column("price").Nullable();
            Map(x => x.CreatedBy).Nullable();
            Map(x => x.CreatedDate).Nullable();
            Map(x => x.Description).Column("description").Nullable();
            Map(x => x.Label).Nullable();
            Map(x => x.Featured).Nullable();
            Map(x => x.Image).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            //Map(x => x.UpdatedBy).Column("updatedby");
            //Map(x => x.UpdatedDate).Column("modifieddate");
        }
    }
}
