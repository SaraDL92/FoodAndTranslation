using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ServiceLayer.Services.DeliveryServices
{
    public class DeliveryStoreService : IStoreService
    {

        List<FoodProvider> foodProviders { get; set; }

        public MenuService _menuService { get; set; }
        private static DeliveryStoreService instance = null;
        private static readonly object padlock = new object();
        private DeliveryStoreService()
        {
            _menuService = new MenuService();
            var _breakfast1 = new FoodProvider()
            {
                Name = "McCafé",
                ProductList = _menuService.BreakfastMenu(),
                OpeningHours = new TimeSpan(7, 0, 0),
                CloseingHours = new TimeSpan(11, 0, 0),
                Type = "breakfast"
            };
            var _breakfast2 = new FoodProvider()
            {
                Name = "Starbucks",
                ProductList = _menuService.BreakfastMenu(),
                OpeningHours = new TimeSpan(7, 0, 0),
                CloseingHours = new TimeSpan(11, 0, 0),

                Type = "breakfast"
            };
            var _brunch1 = new FoodProvider() { Name = "Brunch Time", ProductList = _menuService.BrunchMenu(), OpeningHours = new TimeSpan(7, 0, 0), CloseingHours = new TimeSpan(15, 0, 0), Type = "brunch" };
            var _brunch2 = new FoodProvider() { Name = "Brunch Me", ProductList = _menuService.BrunchMenu(), OpeningHours = new TimeSpan(7, 0, 0), CloseingHours = new TimeSpan(15, 0, 0), Type = "brunch" };
            var _lunch1 = new FoodProvider() { Name = "McDonald's", ProductList = _menuService.LunchMenu(), OpeningHours = new TimeSpan(12, 0, 0), CloseingHours = new TimeSpan(15, 0, 0), Type = "lunch" };
            var _lunch2 = new FoodProvider() { Name = "Da Nino", ProductList = _menuService.LunchMenu(), OpeningHours = new TimeSpan(12, 0, 0), CloseingHours = new TimeSpan(15, 0, 0), Type = "lunch" };
            var _dinner1 = new FoodProvider() { Name = "Hard Rock Restourant", ProductList = _menuService.DinnerMenu(), OpeningHours = new TimeSpan(19, 0, 0), CloseingHours = new TimeSpan(24, 0, 0), Type = "dinner" };
            var _dinner2 = new FoodProvider() { Name = "Sapore", ProductList = _menuService.DinnerMenu(), OpeningHours = new TimeSpan(19, 0, 0), CloseingHours = new TimeSpan(24, 0, 0), Type = "dinner" };
            foodProviders = new List<FoodProvider>();
            foodProviders.Add(_breakfast1);
            foodProviders.Add(_breakfast2);
            foodProviders.Add(_brunch1);
            foodProviders.Add(_brunch2);
            foodProviders.Add(_lunch1);
            foodProviders.Add(_lunch2);
            foodProviders.Add(_dinner1);
            foodProviders.Add(_dinner2);

        }
        public static DeliveryStoreService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DeliveryStoreService();
                    }
                    return instance;
                }
            }
        }

        public IStore ResearchResource()
        {
            DateTime date = DateTime.Now;
            TimeSpan currentTime = date.TimeOfDay;
            Console.WriteLine("----------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"THE DATE TIME NOW IS: {date}");
            Console.ResetColor();
            Console.WriteLine("----------------------");

            FoodProvider foodprovider = new();
            var validinput = false;
            while (!validinput)
            {
                Console.WriteLine("What kind of provider do you want?");
                Console.WriteLine("1. BREAKFAST");
                Console.WriteLine("2. BRUNCH");
                Console.WriteLine("3. LUNCH");
                Console.WriteLine("4. DINNER");
                Console.WriteLine("Enter the number:");



                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":



                        var breakfastProviders = foodProviders.FindAll(v => v.Type == "breakfast");
                        FoodProvider providerWithLeastOrders = null;
                        if (breakfastProviders.Any(v => v.CloseingHours < currentTime))
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine("THIS SERVICE IS NOT AVAIABLE NOW");
                            Console.WriteLine($"THE BREAKFAST SERVICE IS AVAIABLE FROM 7:00 to 11:00");
                            Console.WriteLine("---------------");

                            break;
                        }

                        Console.WriteLine("The service avaiable is: ");

                        if (breakfastProviders.Any())
                        {
                            providerWithLeastOrders = breakfastProviders[0];
                            foreach (var provider in breakfastProviders)
                            {
                                if (provider.NumberOfOrdersInQueue < providerWithLeastOrders.NumberOfOrdersInQueue)
                                {
                                    providerWithLeastOrders = provider;
                                }
                            }
                        }

                        foodprovider = providerWithLeastOrders;


                        validinput = true;
                        break;
                    case "2":


                        var brunchProviders = foodProviders.FindAll(v => v.Type == "brunch");
                        FoodProvider providerWithLeastOrders1 = null;
                        if (brunchProviders.Any(v => v.CloseingHours < currentTime))
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine("THIS SERVICE IS NOT AVAIABLE NOW");
                            Console.WriteLine($"THE BRUNCH SERVICE IS AVAIABLE FROM 7:00 TO 15:00");
                            Console.WriteLine("---------------");
                            break;

                        }


                        Console.WriteLine("The service avaiable is: ");
                        if (brunchProviders.Any())
                        {
                            providerWithLeastOrders1 = brunchProviders[0];
                            foreach (var provider in brunchProviders)
                            {
                                if (provider.NumberOfOrdersInQueue < providerWithLeastOrders1.NumberOfOrdersInQueue)
                                {
                                    providerWithLeastOrders1 = provider;
                                }
                            }
                        }
                        foodprovider = providerWithLeastOrders1;
                        validinput = true;
                        break;
                    case "3":

                        var lunchProviders = foodProviders.FindAll(v => v.Type == "lunch");
                        FoodProvider providerWithLeastOrders2 = null;
                        if (lunchProviders.Any(v => v.CloseingHours < currentTime))
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine("THIS SERVICE IS NOT AVAIABLE NOW");
                            Console.WriteLine($"THE LUNCH SERVICE IS AVAIABLE FROM 12:00 TO 15:00");
                            Console.WriteLine("---------------");
                            break;

                        }
                        Console.WriteLine("The service avaiable is: ");
                        if (lunchProviders.Any())
                        {
                            providerWithLeastOrders2 = lunchProviders[0];
                            foreach (var provider in lunchProviders)
                            {
                                if (provider.NumberOfOrdersInQueue < providerWithLeastOrders2.NumberOfOrdersInQueue)
                                {
                                    providerWithLeastOrders2 = provider;
                                }
                            }
                        }
                        foodprovider = providerWithLeastOrders2;
                        validinput = true;
                        break;
                    case "4":

                        var dinnerProviders = foodProviders.FindAll(v => v.Type == "dinner");
                        FoodProvider providerWithLeastOrders3 = null;
                        if (dinnerProviders.Any(v => v.CloseingHours < currentTime))
                        {
                            Console.WriteLine("---------------");
                            Console.WriteLine("THIS SERVICE IS NOT AVAIABLE NOW");
                            Console.WriteLine($"THE DINNER SERVICE IS AVAIABLE FROM 19:00 TO 24:00");
                            Console.WriteLine("---------------");
                            break;

                        }
                        Console.WriteLine("The service avaiable is: ");
                        if (dinnerProviders.Any())
                        {
                            providerWithLeastOrders3 = dinnerProviders[0];
                            foreach (var provider in dinnerProviders)
                            {
                                if (provider.NumberOfOrdersInQueue < providerWithLeastOrders3.NumberOfOrdersInQueue)
                                {
                                    providerWithLeastOrders3 = provider;
                                }
                            }
                        }
                        foodprovider = providerWithLeastOrders3;
                        validinput = true;
                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****" + " " + foodprovider.Name + " " + "*****");
            Console.ResetColor();
            Console.WriteLine("This is the Menu:");
            foreach (var prod in foodprovider.ProductList)
            {
                Console.WriteLine(prod.Id + " " + prod.Name + " " + prod.Price + "$");
            }


            return foodprovider;



        }


    }
}
