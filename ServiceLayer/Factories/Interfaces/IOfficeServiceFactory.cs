using DataLayer.Models;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.Interfaces
{
   public interface IOfficeServiceFactory
    {
        public IOfficeService GetOfficeService();
    }
}
