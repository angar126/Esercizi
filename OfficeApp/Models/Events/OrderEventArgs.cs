using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Events
{
    public class OrderEventArgs<T>: EventArgs
    {
        private Order<Food> order;

        public Order<T> Order { get; }

        public OrderEventArgs(Order<T> order)
        {
            Order = order;
        }

        public OrderEventArgs(Order<Food> order)
        {
            this.order = order;
        }
    }
}
