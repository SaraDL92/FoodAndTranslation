using DataLayer.Models;
using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.Interfaces
{
    public interface IOfficeManagerFactory
    {
        public OfficeManager Create(string name,IStore store);
    }
}
