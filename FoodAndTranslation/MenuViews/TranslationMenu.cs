using DataLayer.Models.Interfaces;
using ServiceLayer.Factories;
using ServiceLayer.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.MenuViews
{
    public class TranslationMenu
    {

        public void Menu(IOfficeServiceFactory translationOfficeFactory, string input, IStoreServiceFactory translationStoreServiceFactory, IProductServiceFactory translatorserviceFactory)
        {



            OfficeManagerFactory officeManagerFactory = new OfficeManagerFactory();

            translationOfficeFactory.GetOfficeService();

            bool continueOrdering = true;
            while (continueOrdering)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("WOULD YOU LIKE TO MAKE AN ORDER TO THE TRANSLATION SHOP?Y/N");
                Console.ResetColor();
                var input1 = Console.ReadLine();
                if (input1 == "y" || input1 == "Y")
                {
                    var storeService = translationStoreServiceFactory.GetStoreService();
                    var store = storeService.ResearchResource();
                    var theOfficeManager = officeManagerFactory.Create("Sarah Cole", store);

                    Console.WriteLine("MAKE YOUR ORDER!");
                    var translatorServiceFactory = translatorserviceFactory.GetProductService();
                    var product = translatorServiceFactory.GenerateProduct();

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("DO YOU WANT TO BUY IT? Y/N");
                    Console.ResetColor();
                    var input3 = Console.ReadLine();
                    if (input3 == "y" || input3 == "Y")
                    {
                        translatorServiceFactory.AddToCart(product);

                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("DO YOU WANT TO ADD ANOTHER PRODUCT TO YOUR CART? Y/N ");
                            Console.ResetColor();
                            var input5 = Console.ReadLine();

                            if (input5 == "Y" || input5 == "y")
                            {
                                while (true)
                                {
                                    var pr = translatorServiceFactory.GenerateProduct();
                                    if (pr.Price > 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("DO YOU WANT TO ADD THE PRODUCT TO YOUR CART? Y/N");
                                        Console.ResetColor();
                                        var input6 = Console.ReadLine();
                                        if (input6 == "Y" || input6 == "y")
                                        {
                                            var list = translatorServiceFactory.AddToCart(pr);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The selected product has an invalid price. Please try again.");
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("DO YOU WANT TO SEND THE ORDER? Y/N");
                        Console.ResetColor();
                        var input7 = Console.ReadLine();
                        if (input7 == "y" || input7 == "Y")
                        {
                            translatorServiceFactory.SendTheOrderAsync(store);

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("WOULD YOU LIKE TO MAKE ANOTHER ORDER? Y/N");
                            Console.ResetColor();
                            var inputMakeAnotherOrder = Console.ReadLine();
                            if (!(inputMakeAnotherOrder == "y" || inputMakeAnotherOrder == "Y"))
                            {
                                continueOrdering = false;

                            }
                        }
                        else
                        {
                            continueOrdering = false;
                        }
                    }
                    else
                    {
                        continueOrdering = false;
                    }
                }
                else
                {
                    break;
                }
                Console.ResetColor();
            }
        }
    }
}

