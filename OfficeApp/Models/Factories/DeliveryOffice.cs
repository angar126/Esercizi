using OfficeApp.Models.Events;
using OfficeApp.Models.Providers;

namespace OfficeApp.Models.Factories
{
    public class DeliveryOffice
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
        public void SendOrder(Order<Food> order)
        {
            Task.Delay(TimeSpan.FromSeconds(10));
            Log.Add($"Order {order.Id} is in the office");
        }
        
        private void HandleOrderCooming(object sender, OrderEventArgs<Food> e)
        {
            Log.Add($"DeliveryOffice handling OrderCooming event for order {e.Order.Id}");
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
