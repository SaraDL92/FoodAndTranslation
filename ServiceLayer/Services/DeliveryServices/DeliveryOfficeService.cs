using DataLayer.Models;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.DeliveryServices
{
    public class DeliveryOfficeService : IOfficeService
    {


        public IStoreService ContactTheStore()
        {
            return DeliveryStoreService.Instance;
            Console.WriteLine($"You are in contact with the Food Delivery!");
        }


    }
}
