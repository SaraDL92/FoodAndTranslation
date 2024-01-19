using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories
{
    public class OfficeManagerFactory:IOfficeManagerFactory
    {
        public OfficeManager Create(string name,IStore store)
        {
            var officemanager = OfficeManager.GetIstance(store);
            officemanager.Name = name;
            return officemanager  ;
        }
    }
}
