using DataLayer.Models;
using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.DeliveryServices;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.DeliveryFactory
{
    public class DeliveryOfficeServiceFactory : IOfficeServiceFactory
    {
        public IOfficeService GetOfficeService()
        {
            IOfficeService officeServ = new DeliveryOfficeService();
            Console.WriteLine($"You are in contact with the Delivery Office now!"); ;
            return officeServ;
        }
    }
}
