using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class TranslationStore : IStore
    {
        public string Name { get; set; }
        public TimeSpan OpeningHours { get; set; }
        public TimeSpan CloseingHours { get; set; }
        public List<IProduct> ProductList { get; set; }
        public int NumberOfOrdersInQueue {  get; set; }
        public Queue<IOrder> Queue { get; set; }
        public string Type { get; set; }
        public TimeSpan ClosingHours { get ; set ; }
        public Queue<IOrder> orderQueue { get ; set ; }
        public List<IProduct> productsInPreparation { get; set; }
        public SemaphoreSlim platesSemaphore { get; set; }

        public event FoodProvider.OrderStatusHandler OrderOnTheGo;
        public event FoodProvider.OrderStatusHandler OrderArrived;

        public IOrder DequeueOrder()
        {
            throw new NotImplementedException();
        }

        public void EnqueueOrder(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void OnOrderArrived(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void OnOrderOnTheGo(IOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
