using EF_HMW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp
{
    internal class EF_HMW
    {
        NorthwindContext db = new NorthwindContext();
        public void RunHMWCode()
        {
            //Exc1
            Console.WriteLine("_______________ EXCERCISE 1 _______________\n");
            var exc1 = (from rg in db.Regions
                        select rg).ToList();

            //Exc2
            Console.WriteLine("_______________ EXCERCISE 2 _______________\n");
            var exc2 = from rg in db.Regions
                       select rg.RegionDescription;

            //Exc3
            Console.WriteLine("_______________ EXCERCISE 3 _______________\n");
            var exc3 = (from tr in db.Territories
                        select tr).ToList();

            //Exc4
            Console.WriteLine("_______________ EXCERCISE 4 _______________\n");
            var exc4 = from tr in db.Territories
                       select tr.TerritoryDescription;

            //Exc5
            Console.WriteLine("_______________ EXCERCISE 5 _______________\n");
            var exc5 = from rg in db.Regions
                       join tr in db.Territories
                       on rg.RegionId equals tr.RegionId
                       select new { Region = rg.RegionDescription, territory = tr.TerritoryDescription };

            //Exc6
            Console.WriteLine("_______________ EXCERCISE 6 _______________\n");
            OrderDetail order1 = new() { ProductId = 11, UnitPrice = 95, Quantity = 3 };
            OrderDetail order2 = new() { ProductId = 56, UnitPrice = 47, Quantity = 6 };
            OrderDetail order3 = new() { ProductId = 74, UnitPrice = 120, Quantity = 5 };

            db.Orders.Add(new Order()
            {
                CustomerId = "FRANK",
                EmployeeId = 6,
                OrderDate = DateTime.Now,
                ShipAddress = "7 Piccadilly Rd.",
                ShipCity = "New York",
                ShipCountry = "New York"
            });

            db.SaveChanges();

            db.OrderDetails.Add(order1);
            db.OrderDetails.Add(order2);
            db.OrderDetails.Add(order3);

            //Exc7
            Console.WriteLine("_______________ EXCERCISE 7 _______________\n");
            var exc7 = from ord in db.Orders
                       join det in db.OrderDetails
                       on ord.OrderId equals det.OrderId
                       join prod in db.Products
                       on det.ProductId equals prod.ProductId
                       join emp in db.Employees
                       on ord.EmployeeId equals emp.EmployeeId
                       select new { orderId = ord.OrderId, product = prod.ProductName, employee = emp.FirstName };


            //Exc8
            Console.WriteLine("_______________ EXCERCISE 8 _______________\n");
            var exc8 = db.Orders.ToList();

            foreach (var item in exc8)
            {
                if(item.EmployeeId == 6)
                {
                    item.EmployeeId = 5;
                }
            }

            //Exc9
            Console.WriteLine("_______________ EXCERCISE 9 _______________\n");
            var exc9 = db.Orders.ToList();
            foreach (var item in exc9)
            {
                if(item.OrderId == 56)
                {
                    db.Orders.Remove(item);
                }
            }
           
        }
    }
}
