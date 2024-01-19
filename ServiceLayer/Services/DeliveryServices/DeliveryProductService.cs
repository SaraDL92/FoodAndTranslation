using DataLayer.Models;
using DataLayer.Models.Interfaces;
using Microsoft.VisualBasic;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ServiceLayer.Services.DeliveryServices
{
    public class DeliveryProductService : IProductService
    {

        private static DeliveryProductService _instance;
        private readonly List<IProduct> _products;
        private readonly Queue<IOrder> _orders;

        public DeliveryProductService()
        {
            _orders = new Queue<IOrder>();
            _products = new List<IProduct>();
            var storeService = DeliveryStoreService.Instance;
        }



        public IOrder CreateOrder(IStore store, OfficeManager officeManager)
        {
            var list = GetProducts();
            List<IProduct> foodList = new List<IProduct>();
            Random rand = new Random();
            int id = rand.Next(0, 300);
            foreach (var item in list)
            {
                FoodProduct foodProduct = new FoodProduct()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    PreparationTime = item.PreparationTime
                };

                foodList.Add(foodProduct);
            }
            decimal totalPrice = 0;

            foreach (var item in foodList) { totalPrice = totalPrice + item.Price; }
            FoodOrder foodOrder = new FoodOrder() { Id = id, Status = "ORDER PLACED", TotalPrice = totalPrice, Products = foodList };

            foreach (var product in list) { totalPrice += product.Price; }
            Console.WriteLine("DO YOU WANT TO SEND THE ORDER?Y/N");
            var input = Console.ReadLine();
            if (input == "y" || input == "Y")
            {
                if (foodOrder.TotalPrice == 0)
                {
                    Console.WriteLine("The order is empty. Retry");

                }
                else
                {
                    lock (store.orderQueue)
                    {
                        store.EnqueueOrder(foodOrder);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"THE ORDERS IN QUEUE OF STORE {store.Name} are:");
                        Console.ResetColor();
                        foreach (var order in store.orderQueue)
                        {
                            Console.WriteLine(order.Id);
                        }
                        Console.WriteLine("WE ARE SENDING THE ORDER...");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("We will send you some notifications with the update of the order status, you can continue to browse the store if you want and place orders!");
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("NOTIFICATION:");
                        Console.ResetColor();
                        Console.WriteLine($"The order {foodOrder.Id}- with total price {foodOrder.TotalPrice}- with these products:");
                        foreach (var item in foodOrder.Products)
                        {
                            Console.WriteLine(item.Name);
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"WAS SENT TO THE RESTAURANT {store.Name}");



                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("YOU CAN CONTINUE TO ANSWER THE CONSOLE'S PAST QUESTIONS.");
                        Console.ResetColor();
                        Console.WriteLine("------------------------------------------");
                        SendTheOrderAsync(store, foodOrder, officeManager);

                    }
                }


            }
            return foodOrder;

        }
        public async Task<IOrder> SendTheOrderAsync(IStore store, IOrder foodOrder, OfficeManager officeManager)
        {



            if (store.orderQueue.Peek().Id == foodOrder.Id)
            {
                await PrepareAndCompleteOrder(store, officeManager);
            }

            return foodOrder;
        }

        private readonly SemaphoreSlim platesSemaphore = new SemaphoreSlim(4, 4);

        private async Task PrepareAndCompleteOrder(IStore store, OfficeManager officeManager)
        {
            while (store.orderQueue.Count > 0)
            {
                foreach (var order in store.orderQueue)
                {
                    foreach (var product in order.Products.Where(p => !p.IsBeingPrepared && !p.IsPrepared))
                    {
                        if (store.productsInPreparation.Count < 4)
                        {
                            await TryPrepareProductAsync(store, product, order);
                        }
                    }
                }
                var completedOrders = store.orderQueue.Where(o => o.Products.All(p => p.IsPrepared)).ToList();
                foreach (var completedOrder in completedOrders)
                {
                    store.orderQueue.Dequeue();
                    await Task.Delay(1000);
                    Console.WriteLine("------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("NOTIFICATION:");
                    Console.ResetColor();
                    Console.WriteLine($"THE RIDER {completedOrder.Id} TOOK THE ORDER {completedOrder.Id} FROM {store.Name}");
                    Console.WriteLine("------------------------------------------");


                    Console.ForegroundColor = ConsoleColor.Yellow;

                    store.OnOrderOnTheGo(completedOrder);



                    await Task.Delay(5000);

                    Console.ForegroundColor = ConsoleColor.Blue;
                    store.OnOrderArrived(completedOrder);


                    await Task.Delay(3000);

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    officeManager.OnOrderOnTheTable(completedOrder);
                    Console.WriteLine($"FROM {store.Name}");




                }

                await Task.Delay(1000);
            }
        }



        private async Task<bool> TryPrepareProductAsync(IStore store, IProduct product, IOrder order)
        {
            if (!product.IsBeingPrepared && await store.platesSemaphore.WaitAsync(0))
            {
                product.IsBeingPrepared = true;
                _ = PrepareProductAsync(store, product, order);
                return true;
            }
            return false;
        }


        private async Task PrepareProductAsync(IStore store, IProduct product, IOrder order)
        {
            try
            {
                Console.WriteLine("------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("NOTIFICATION:");
                Console.ResetColor();
                Console.WriteLine($"____ {store.Name} PREPARING {product.Name} OF ORDER {order.Id}. WAITING TIME: {product.PreparationTime} SECONDS _____");
                await Task.Delay(product.PreparationTime);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{product.Name} OF ORDER {order.Id} IS READY IN THE RESTOURANT {store.Name}!");
                Console.WriteLine("------------------------------------------");
            }
            finally
            {
                product.IsBeingPrepared = false;
                product.IsPrepared = true;
                store.platesSemaphore.Release();
            }
        }



        public List<IProduct> GetProducts()
        {
            return _products;
        }
        public Queue<IOrder> GetOrders()
        {
            return _orders;
        }
        public IProduct GenerateProduct(List<IProduct> products, int id)
        {
            var prod = products.Find(x => x.Id == id);

            _products.Add(prod);
            foreach (var item in _products)
            {
                Console.WriteLine("THESE ARE THE PRODUCTS IN YOUR CART:");
                Console.WriteLine(item.Name + " " + item.Price);
            }
            return prod;

        }

        public List<IProduct> AddToCart(IProduct product)
        {
            if (product == null)
            {
                Console.WriteLine("Warning: Trying to add a null product.");
                return _products;
            }

            _products.Add(product);
            Console.WriteLine($"The product {product.Name} has been added to your cart");

            Console.WriteLine("These are the products in your cart:");
            foreach (IProduct p in _products)
            {
                Console.WriteLine($"{p.Name} - ${p.Price}");
            }

            return _products;
        }

        public IProduct GenerateProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IOrder> SendTheOrderAsync(IStore store)
        {
            throw new NotImplementedException();
        }
    }
}