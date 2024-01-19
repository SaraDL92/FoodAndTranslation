using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TranslationServices
{
    public class TranslatorProductService : IProductService
    {
        private static TranslatorProductService _instance;
        private readonly TranslationStoreService _storeService;
        private readonly List<IProduct> _products;

        private TranslatorProductService()
        {
            _products = new List<IProduct>();
            _storeService = new TranslationStoreService();
        }

        public static TranslatorProductService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TranslatorProductService();
                }
                return _instance;
            }
        }
        public async Task<IOrder> SendTheOrderAsync(IStore store)
        {
            var list = GetProducts();
            List<IProduct> translatorsList = new List<IProduct>();
            Random rand = new Random();
            int id = rand.Next(0, 300);
            foreach (var item in list)
            {
                Translator translator = new Translator()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price
                };

                translatorsList.Add(translator);
            }

            decimal totalPrice = 0;
            foreach (var product in list) { totalPrice = totalPrice + product.Price; }
            TranslationOrder translationOrder = new TranslationOrder() { Id = id, Status = "ORDER PLACED", TotalPrice = totalPrice, Products = translatorsList };
            Console.WriteLine($"The order {translationOrder.Id}- with total price {translationOrder.TotalPrice}- with these products:");
            foreach (var item in translatorsList)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine($"HAS BEEN PLACED");
            _products.Clear();
            return translationOrder;
        }
        public List<IProduct> GetProducts()
        {
            return _products;
        }

        public IProduct GenerateProduct()
        {
            Console.WriteLine("Insert the number of the traductor's language that you need:");
            var store = _storeService.ResearchResource();
            foreach (var item in store.ProductList)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
            var inp = Console.ReadLine();



            Translator translator = new Translator();
            switch (inp)
            {
                case "1":
                    translator.Id = 1;
                    translator.Name = "Italian";
                    translator.Price = 100;
                    phrase();


                    break;
                case "2":
                    translator.Id = 2;
                    translator.Name = "English";
                    translator.Price = 150;
                    phrase();
                    break;
                case "3":
                    translator.Id = 3;
                    translator.Name = "Japanese";
                    translator.Price = 500;
                    phrase();

                    break;
                case "4":
                    translator.Id = 4;
                    translator.Name = "German";
                    translator.Price = 300;
                    phrase();
                    break;
                case "5":
                    translator.Id = 5;
                    translator.Name = "Russian";
                    translator.Price = 400;
                    phrase();
                    break;
                default:
                    Console.WriteLine("The language you have chosen is not available");
                    break;



            };

            void phrase() { Console.WriteLine($"Package {translator.Name} is avaiable, the price is {translator.Price} $"); }


            return translator;

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

        public Task<IOrder> SendTheOrderAsync(IStore store, IOrder foodOrder, OfficeManager officeManager)
        {
            throw new NotImplementedException();
        }

        public IProduct GenerateProduct(List<IProduct> products, int id)
        {
            throw new NotImplementedException();
        }

        public IOrder CreateOrder(IStore store, OfficeManager officeManager)
        {
            throw new NotImplementedException();
        }
    }
}