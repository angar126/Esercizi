using OfficeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
{
    public abstract class Provider<T>
        where T : ServiceType
    {
        public string Name { get; set; }
        public abstract List<T> ListOfItems { get; set; }

        //static protected Queue<Order<T>> orderQueue = new Queue<Order<T>>();
        public abstract Task EnqueueOrder(Order<T> order);
        //public abstract Task ProcessOrdersAsync();

    }
    public abstract class ServiceType
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
