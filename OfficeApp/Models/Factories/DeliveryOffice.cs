using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeApp.Models.FoodProvider;

namespace OfficeApp.Models.Factories
{
    public class DeliveryOffice : IOffice
    {
        public DeliveryOffice() { }
        public FoodProvider GetProvider()
        {
            FoodPortal portal = FoodPortal.GetInstance();
            portal.OrderOnWay += HandleOrderCooming;
            return portal.GetProvider();
        }
        public void SendOrder(Order<Food> order)
        {
          //Task.Delay(TimeSpan.FromSeconds(10));
          Console.WriteLine($"Order {order.Id} is in the office");
        }
        
        private void HandleOrderCooming(object sender, OrderEventArgs<Food> e)
        {
            Console.WriteLine($"DeliveryOffice handling OrderCooming event for order {e.Order.Id}");
            //e.FoodPortal.OrderOnWay -= HandleOrderCooming;
            
            SendOrder(e.Order);
        }
    }
}
