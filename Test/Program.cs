using Restaurant.Data.Infrustructure.Helper;
using Restaurant.Domains.Models;
using System;



namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var dish = new Dish
                    {
                        Image = "Allan",
                        Catagory = "asdf",
                        Label = "asdf",
                        Description = "asdf",
                        CreatedBy = "sadf",
                        Featured = true,
                        Name = "asdf",
                        CreatedDate = DateTime.Now,
                        //UpdatedBy = "asdf",
                        Price = "asdf",
                        //UpdatedDate = DateTime.Now
                    };

                    session.Save(dish);
                    transaction.Commit();
                    Console.WriteLine("Customer Created: " + dish.Label + "\t" +
                       dish.Description);
                }

                Console.ReadKey();
            }
        }
    }
}
