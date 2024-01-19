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
        static DeliveryOffice _instance;
        FoodPortal _portal;
        private DeliveryOffice() {  }
        public FoodProvider GetProvider()
        {
            _portal = FoodPortal.GetInstance();
            _portal.OrderOnWay -= HandleOrderCooming;
            _portal.OrderOnWay += HandleOrderCooming;
            //_portal = portal;
            return _portal.GetProvider();
        }
        public static DeliveryOffice GetInstance()
        {
            if (_instance is null)
            {
                _instance = new DeliveryOffice();
            }
            return _instance;
        }
        public async void SendOrder(Order<Food> order)
        {
          await Task.Delay(TimeSpan.FromSeconds(10));
          Console.WriteLine($"Order {order.Id} is in the office");
        }
        
        private void HandleOrderCooming(object sender, OrderEventArgs<Food> e)
        {
            Console.WriteLine($"DeliveryOffice handling OrderCooming event for order {e.Order.Id}");
            SendOrder(e.Order);
        }
        public void Dispose()
        {
            if (_portal != null)
            {
                _portal.OrderOnWay -= HandleOrderCooming;
            }
        }

    }
}
