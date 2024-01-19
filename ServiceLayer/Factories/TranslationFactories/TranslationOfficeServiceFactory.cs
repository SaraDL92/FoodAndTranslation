using DataLayer.Models;
using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Services.DeliveryServices;

namespace ServiceLayer.Factories.TranslationFactories
{
    public class TranslationOfficeServiceFactory : IOfficeServiceFactory
    {

        public IOfficeService GetOfficeService()
        {
            IOfficeService officeServ = new DeliveryOfficeService();
            Console.WriteLine($"You are in contact with the Translation Office now!");
            return officeServ;
        }
    }
}

