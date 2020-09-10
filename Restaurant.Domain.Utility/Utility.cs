using Dapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Restaurant.Domain.Domains.Models.AuthModels;
using Restaurant.Domain.Domains.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        public bool IsAlreadyExists(string connectionString, string username, string email)
        {
            string sqlGetAllMenus = "SELECT * FROM users WHERE username = '" + username + "' or email = '" + email + "'; ";

            using (var connection = new SqlConnection(connectionString))
            {
                int count = 0;
                try
                {
                    count = connection.Query<User>(sqlGetAllMenus).ToList().Count();
                }
                catch (Exception e)
                {

                }

                if (count > 0)
                    return true;
                else
                    return false;
            }
        }
        #region Email
        public bool SendEmail(User user)
        {
            #region
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "EmailTemplate", "reset.txt");
            string body = System.IO.File.ReadAllText(file);
            if (!string.IsNullOrEmpty(body))
            {
                body = body.Replace("$websitelink$", user.Token.ToString());
                body = body.Replace("$resetlink$", (user.Token+"/changePassword"+user.ResetId).ToString());
            }
            #endregion
            try
            {
                // create email message
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse("rakibchowdhury01942@gmail.com");
                email.To.Add(MailboxAddress.Parse(user.Email));
                email.Subject = "Test Email Subject";
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("rakibchowdhury01942@gmail.com", "shusil00");
                smtp.Send(email);
                smtp.Disconnect(true);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
    }
}
