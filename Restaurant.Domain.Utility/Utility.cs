using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.Domains.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Restaurant.Domain.Utility
{
    public class Utility
    {
        
        public IList<MenuViewModel> GetAllMenus(string connectionString)
        {
            string sqlGetAllMenus = "SELECT * FROM Menus;";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<MenuViewModel>(sqlGetAllMenus).ToList();

                //Console.WriteLine(menuList.Count);

                //FiddleHelper.WriteTable(orderDetails);
                //FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });
            }
        }
    }
}
