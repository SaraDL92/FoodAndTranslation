using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Services.DeliveryServices;

namespace ServiceLayer.Factories.DeliveryFactory
{
    public class DeliveryStoreServiceFactory : IStoreServiceFactory
    {
        public IStoreService GetStoreService()
        {
            return DeliveryStoreService.Instance;
        }
    }
}

