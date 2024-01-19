using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Providers
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
}
