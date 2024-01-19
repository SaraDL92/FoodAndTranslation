using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DataLayer.Models.FoodProvider;

namespace DataLayer.Models.Interfaces
{
    public interface IStore
    {
        string Name { get; set; }
        TimeSpan OpeningHours { get; set; }
        TimeSpan ClosingHours { get; set; }
        List<IProduct> ProductList { get; set; }
        int NumberOfOrdersInQueue { get; }
        Queue<IOrder> orderQueue { get; set; }
        List<IProduct> productsInPreparation { get; set; }
        public SemaphoreSlim platesSemaphore { get; set; }
        
        public event OrderStatusHandler OrderOnTheGo;
        
        public event OrderStatusHandler OrderArrived;
        string Type { get; set; }
        void OnOrderArrived(IOrder order);
        void OnOrderOnTheGo(IOrder order);
        void EnqueueOrder(IOrder order);
        IOrder DequeueOrder();
    }
}
