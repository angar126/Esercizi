using OfficeApp.Models.Events;
using OfficeApp.Models.Providers;

namespace OfficeApp.Models.Factories
{
    public class TranslationOffice
    {
        private static TranslationOffice _instance;
        private TranslationOffice() { }
        public static TranslationOffice GetInstance()
        {
            if (_instance is null)
            {
                _instance = new TranslationOffice();
            }
            return _instance;
        }
        public TranslationProvider GetProvider()
        {
            TranslationPortal portal = TranslationPortal.GetInstance();
            portal.OrderOnWay -= HandleOrderCooming;
            portal.OrderOnWay += HandleOrderCooming;
            return portal.GetProvider();
        }
        public void SendOrder(Order<Translation> order)
        {
            //Task.Delay(TimeSpan.FromSeconds(10));
            Log.Add($"Order {order.Id} is in the office's mail");
        }

        private void HandleOrderCooming(object sender, OrderEventArgs<Translation> e)
        {
            Log.Add($"DeliveryOffice handling OrderCooming event for order {e.Order.Id}");
            SendOrder(e.Order);
        }
    }
}
