using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.DeliveryServices;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.DeliveryFactory
{
    public class FoodProductServiceFactory : IProductServiceFactory
    {
        public IProductService GetProductService()
        {
            return new DeliveryProductService();
        }
    }
}
