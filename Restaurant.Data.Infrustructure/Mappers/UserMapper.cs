using FluentNHibernate.Mapping;
using Restaurant.Domain.Domains.Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Infrustructure.Mappers
{
    public class UserMapper : ClassMap<User>
    {
        public UserMapper()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.FirstName).Column("firstname");
            Map(x => x.CreatedBy).Column("createdby");
            Map(x => x.CreatedDate).Column("createddate");
            Map(x => x.LastName).Column("lastname");
            Map(x => x.Password).Column("password"); ;
            Map(x => x.Role).Column("role"); ;
            Map(x => x.Image).Column("image"); ;
            Map(x => x.Token).Column("token"); ;
            Map(x => x.Username).Column("username"); ;
            Map(x => x.Email).Column("email");
            //Map(x => x.UpdatedBy).Column("updatedby");
            //Map(x => x.UpdatedDate).Column("updateddate");resetId
            Map(x => x.UpdatedDate).Column("modifieddate");
            Map(x => x.ResetId).Column("resetId");
        }
    }
}
