using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class FoodOrder:IOrder
    {
        public int Id { get; set; }
        public string Status {  get; set; }

        public List<IProduct> Products { get; set; }

        public decimal TotalPrice { get; set; }


    }
}
