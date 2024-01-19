using DataLayer.Models;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TranslationServices
{
    public class TranslationOfficeService : IOfficeService
    {

        public IStoreService ContactTheStore()
        {
            return new TranslationStoreService();
            Console.WriteLine($"You are in contact with the Translation Store!");
        }
    }
}
