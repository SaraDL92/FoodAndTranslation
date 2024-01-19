using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Judge
    {
        private static Judge istance;
        public string Name { get; set; }

        private Judge(OfficeManager officeManager)
        {
            Name = "Sarah Cole"; 
            officeManager.OrderOnTheTable += HandleOrderOnTheTable;
        }
        private void HandleOrderOnTheTable(IOrder order, string status)
        {
            Console.WriteLine($"NOTIFICATION FOR JUDGE: Order {order.Id} is on the table!");
        }

      
        public static Judge GetIstance(OfficeManager officeManager)
        {
            if (istance == null) { istance = new Judge(officeManager); }

            return istance;
        }
    }


}
