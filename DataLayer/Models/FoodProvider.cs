using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class FoodProvider : IStore
    {
        public string Name { get; set; }
        public TimeSpan OpeningHours { get; set; }
        public TimeSpan CloseingHours { get; set; }
        public List<IProduct> ProductList { get; set; }
        public string Type { get; set; }
        public Queue<IOrder> orderQueue { get; set; }
        public List<IProduct> productsInPreparation { get; set; }
        public SemaphoreSlim platesSemaphore { get; set; }
        public int NumberOfOrdersInQueue { get; set; }
        
        private readonly object queueLock = new object();
        
        public delegate void OrderStatusHandler(IOrder order, string status);


        public event OrderStatusHandler OrderOnTheGo;
        public event OrderStatusHandler OrderArrived;

        public FoodProvider()
        {
            orderQueue = new Queue<IOrder>();
            productsInPreparation = new List<IProduct>();
            ProductList = new List<IProduct>();
            platesSemaphore = new SemaphoreSlim(4, 4);
        }

        public object QueueLock
        {
            get { return queueLock; }
        }
        public virtual void OnOrderOnTheGo(IOrder order)
        {
            OrderOnTheGo?.Invoke(order, "On the go");
        }

        public virtual void OnOrderArrived(IOrder order)
        {
            OrderArrived?.Invoke(order, "Arrived");
        }
        public TimeSpan ClosingHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public void EnqueueOrder(IOrder order)
        {
            lock (queueLock)
            {
                orderQueue.Enqueue(order);
                NumberOfOrdersInQueue = orderQueue.Count;
            }
        }

        public IOrder DequeueOrder()
        {
            lock (queueLock)
            {
                if (orderQueue.Count == 0) return null;
                var order = orderQueue.Dequeue();
                NumberOfOrdersInQueue = orderQueue.Count;
                return order;
            }
        }



    }
}



