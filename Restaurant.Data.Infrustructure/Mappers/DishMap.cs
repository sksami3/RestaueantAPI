using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domains.Mappers
{
    public class DishMap : ClassMap<Dish>
    {
        public DishMap()
        {
            Table("Dishes");
            Id(x => x.Id);
            Map(x => x.Image).Column("image");
            Map(x => x.Label).Column("label");
            Map(x => x.Name).Column("name");
            Map(x => x.Price).Column("price");
            //Map(x => x.UpdatedBy).Column("updatedby");
            //Map(x => x.UpdatedDate).Column("updateddate");
            Map(x => x.Catagory).Column("catagory");
            Map(x => x.CreatedBy).Column("createdby");
            Map(x => x.CreatedDate).Column("createddate");
            Map(x => x.Description).Column("description");
            Map(x => x.Featured).Column("featured");
        }
    }
}
