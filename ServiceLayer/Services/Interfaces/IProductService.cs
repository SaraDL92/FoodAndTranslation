using DataLayer.Models;
using DataLayer.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IProductService
    {
        public IProduct GenerateProduct();
        public List<IProduct> AddToCart(IProduct product);
        public List<IProduct> GetProducts();
       
        public Task<IOrder> SendTheOrderAsync(IStore store, IOrder foodOrder, OfficeManager officeManager);
        public Task<IOrder> SendTheOrderAsync(IStore store);
        public IProduct GenerateProduct(List<IProduct> products, int id);
       
        public IOrder CreateOrder(IStore store, OfficeManager officeManager);
    }
}
