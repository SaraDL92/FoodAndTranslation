using DataLayer.Models.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Factories.Interfaces
{
    public interface IJudgeFactory
    {
        public Judge Create(string name, OfficeManager officeManager);
    }
}
