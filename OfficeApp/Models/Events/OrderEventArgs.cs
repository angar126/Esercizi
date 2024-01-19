using OfficeApp.Models.Factories;
using OfficeApp.Models.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Events
{
    public class OrderEventArgs<T>: EventArgs where T: ServiceType
    {

        public Order<T> Order { get; }
        //public FoodProvider FoodProvider { get; set; }
        //public FoodPortal FoodPortal { get; set; }
        public OrderEventArgs(Order<T> order)
        {
            Order = order;
        }

    }
}
