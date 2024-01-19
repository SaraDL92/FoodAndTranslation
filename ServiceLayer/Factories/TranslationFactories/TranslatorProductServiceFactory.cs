using ServiceLayer.Factories.Interfaces;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services.TranslationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.TranslationFactories
{
    public class TranslatorProductServiceFactory : IProductServiceFactory
    {
        public IProductService GetProductService()
        {
            return TranslatorProductService.Instance;
        }
    }
}
