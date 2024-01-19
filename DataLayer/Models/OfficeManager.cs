using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class OfficeManager
    {
        private static OfficeManager istance;
        public string Name { get; set; }
        public delegate void OrderStatusHandlerForJudge(IOrder order, string status);
        public event OrderStatusHandlerForJudge OrderOnTheTable;

        private OfficeManager(IStore foodProvider) {
            Name = "Abigail Golden";  
            foodProvider.OrderOnTheGo += HandleOrderOnTheGo;
            foodProvider.OrderArrived += HandleOrderArrived;
        }
        public virtual void OnOrderOnTheTable(IOrder order)
        {
            OrderOnTheTable?.Invoke(order, "On the go");
        }

        private void HandleOrderOnTheGo(IOrder order, string status)
        {
            Console.WriteLine($"NOTIFICATION FOR OFFICE MANAGER: Order {order.Id} is on the go!");
        }

        private void HandleOrderArrived(IOrder order, string status)
        {
            Console.WriteLine($"NOTIFICATION FOR OFFICE MANAGER: Order {order.Id} has arrived!");
        }
      public static OfficeManager GetIstance(IStore foodprovider) {
            if (istance == null) { istance = new OfficeManager(foodprovider); }

            return istance; }
    }

      
}
