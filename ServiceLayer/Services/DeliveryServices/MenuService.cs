using DataLayer.Models;
using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DeliveryServices
{
    public class MenuService
    {

        public List<IProduct> BreakfastMenu()
        {
            List<IProduct> breakfastlist = new List<IProduct>();
            FoodProduct p1 = new FoodProduct()
            {
                Id = 1,
                Name = "COFFEE",
                PreparationTime = new TimeSpan(0, 0, 20),
                Price = 1
            };
            FoodProduct p2 = new FoodProduct()
            {
                Id = 2,
                Name = "ORANGE JUICE",
                PreparationTime = new TimeSpan(0, 0, 10),
                Price = 2.50M
            };
            FoodProduct p3 = new FoodProduct()
            {
                Id = 3,
                Name = "CROISSANT",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 2
            };
            FoodProduct p4 = new FoodProduct()
            {
                Id = 4,
                Name = "TOAST",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 3.50M
            };
            FoodProduct p5 = new FoodProduct()
            {
                Id = 5,
                Name = "DONUT",
                PreparationTime = new TimeSpan(0, 0, 10),
                Price = 4
            };
            breakfastlist.Add(p1);
            breakfastlist.Add(p2);
            breakfastlist.Add(p3);
            breakfastlist.Add(p4);
            breakfastlist.Add(p5);



            return breakfastlist;
        }

        public List<IProduct> BrunchMenu()
        {
            List<IProduct> brunchlist = new List<IProduct>();
            FoodProduct p1 = new FoodProduct()
            {
                Id = 1,
                Name = "MIXED FRUIT",
                PreparationTime = new TimeSpan(0, 0, 40),
                Price = 10
            };
            FoodProduct p2 = new FoodProduct()
            {
                Id = 2,
                Name = "PIZZA (5 small pieces)",
                PreparationTime = new TimeSpan(0, 0, 20),
                Price = 7
            };
            FoodProduct p3 = new FoodProduct()
            {
                Id = 3,
                Name = "MIXED CURED MEATS",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 10
            };
            FoodProduct p4 = new FoodProduct()
            {
                Id = 4,
                Name = "TOAST",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 3.50M
            };
            FoodProduct p5 = new FoodProduct()
            {
                Id = 5,
                Name = "DONUT",
                PreparationTime = new TimeSpan(0, 0, 20),
                Price = 4
            };
            brunchlist.Add(p1);
            brunchlist.Add(p2);
            brunchlist.Add(p3);
            brunchlist.Add(p4);
            brunchlist.Add(p5);



            return brunchlist;
        }
        public List<IProduct> LunchMenu()
        {
            List<IProduct> lunchlist = new List<IProduct>();
            FoodProduct p1 = new FoodProduct()
            {
                Id = 1,
                Name = "PASTA",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 7
            };
            FoodProduct p2 = new FoodProduct()
            {
                Id = 2,
                Name = "SPAGHETTI",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 7
            };
            FoodProduct p3 = new FoodProduct()
            {
                Id = 3,
                Name = "HOT DOG",
                PreparationTime = new TimeSpan(0, 0, 40),
                Price = 5
            };
            FoodProduct p4 = new FoodProduct()
            {
                Id = 4,
                Name = "TOAST",
                PreparationTime = new TimeSpan(0, 0, 20),
                Price = 3.50M
            };
            FoodProduct p5 = new FoodProduct()
            {
                Id = 5,
                Name = "SAUSAGE",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 9
            };
            lunchlist.Add(p1);
            lunchlist.Add(p2);
            lunchlist.Add(p3);
            lunchlist.Add(p4);
            lunchlist.Add(p5);



            return lunchlist;
        }

        public List<IProduct> DinnerMenu()
        {
            List<IProduct> dinnerlist = new List<IProduct>();
            FoodProduct p1 = new FoodProduct()
            {
                Id = 1,
                Name = "PASTA",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 7
            };
            FoodProduct p2 = new FoodProduct()
            {
                Id = 2,
                Name = "SPAGHETTI",
                PreparationTime = new TimeSpan(0, 0, 40),
                Price = 7
            };
            FoodProduct p3 = new FoodProduct()
            {
                Id = 3,
                Name = "PIZZA",
                PreparationTime = new TimeSpan(0, 0, 50),
                Price = 5
            };
            FoodProduct p4 = new FoodProduct()
            {
                Id = 4,
                Name = "SUSHI",
                PreparationTime = new TimeSpan(0, 0, 30),
                Price = 15
            };
            FoodProduct p5 = new FoodProduct()
            {
                Id = 5,
                Name = "SAUSAGE",
                PreparationTime = new TimeSpan(0, 0, 40),
                Price = 9
            };
            dinnerlist.Add(p1);
            dinnerlist.Add(p2);
            dinnerlist.Add(p3);
            dinnerlist.Add(p4);
            dinnerlist.Add(p5);



            return dinnerlist;
        }

    }
}
