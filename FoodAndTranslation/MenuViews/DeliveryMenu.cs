using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Factories;
using ServiceLayer.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MenuViews
{
    public class DeliveryMenu
    {
        public async Task Menu(IOfficeServiceFactory deliveryOfficeFactory, string input, IStoreServiceFactory deliveryStoreServiceFactory, IProductServiceFactory deliveryservicefactory)
        {
            IOfficeManagerFactory officeManager = new OfficeManagerFactory();
            IJudgeFactory judgeFactory = new JudgeFactory();

            Queue<IOrder> queue = new Queue<IOrder>();

            deliveryOfficeFactory.GetOfficeService();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("DO YOU WANT TO CONTACT THE DELIVERY STORE? Y/N");
            Console.ResetColor();
            var inp = Console.ReadLine();

            if (inp == "y" || inp == "Y")
            {
                var store = deliveryStoreServiceFactory.GetStoreService();
                var store1 = store.ResearchResource();

                var theOfficeManager = officeManager.Create("Abigail Golden", store1);
                var theJudge = judgeFactory.Create("Sarah Cole", theOfficeManager);
                var deliveryproductservice = deliveryservicefactory.GetProductService();

                bool continueAddingProducts = true;
                while (continueAddingProducts)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("ENTER THE NUMBER OF THE PRODUCT THAT YOU WANT TO ADD TO YOUR CART!");
                    Console.ResetColor();
                    string input1 = Console.ReadLine();
                    if (int.TryParse(input1, out int val) && val > 0 && val <= store1.ProductList.Count)
                    {
                        deliveryproductservice.AddToCart(store1.ProductList[val - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid product number.");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("DO YOU WANT TO ADD ANOTHER PRODUCT TO YOUR CART? Y/N");
                    Console.ResetColor();
                    inp = Console.ReadLine();
                    continueAddingProducts = inp == "Y" || inp == "y";
                }


                var order = deliveryproductservice.CreateOrder(store1, theOfficeManager);
            }

            Console.ResetColor();
        }
    }
}

