using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Infrustructure.Mappers
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Table("Comments");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.Rating);
            Map(x => x.ViewersComment).Column("comment");
            Map(x => x.Date).Column("createddate");
            Map(x => x.Author);
            //Map(x => x.UpdatedBy).Column("updatedby");
            //Map(x => x.UpdatedDate).Column("updateddate");
            References(x => x.Dish).ForeignKey("dish_id");
        }
    }
}
