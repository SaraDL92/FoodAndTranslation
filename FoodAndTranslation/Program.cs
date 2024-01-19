using DataLayer.Models;
using Presentation.MenuViews;
using ServiceLayer.Factories;
using ServiceLayer.Factories.DeliveryFactory;
using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Factories.TranslationFactories;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace FoodAndTranslation
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            IOfficeServiceFactory deliveryOfficeFactory = new DeliveryOfficeServiceFactory();
            IOfficeServiceFactory translationOfficeFactory = new TranslationOfficeServiceFactory();
            IStoreServiceFactory deliveryStoreServiceFactory = new DeliveryStoreServiceFactory();
            IStoreServiceFactory translationStoreServiceFactory = new TranslationStoreServiceFactory();
            IProductServiceFactory translatorServiceFactory = new TranslatorProductServiceFactory();
            IProductServiceFactory deliveryServiceFactory = new FoodProductServiceFactory();
            TranslationMenu translationmenu=new TranslationMenu();
            DeliveryMenu deliveryMenu=new DeliveryMenu();

           

          

            bool choiceMade = false;

            while (!choiceMade)
            {
                Console.WriteLine("Choose the Office that you want");
                Console.WriteLine("1- TRANSLATION OFFICE");
                Console.WriteLine("2- DELIVERY OFFICE");
                var input = Console.ReadLine();
                if (input == "1") {  translationmenu.Menu(translationOfficeFactory, input, translationStoreServiceFactory, translatorServiceFactory);}
                   
                else if (input == "2")
                {
                    deliveryMenu.Menu(deliveryOfficeFactory, input, deliveryStoreServiceFactory, deliveryServiceFactory);
                   
                }
                else
                {
                    Console.WriteLine("Invalid input, please retry!");
                }
            }
        }
    }
}
