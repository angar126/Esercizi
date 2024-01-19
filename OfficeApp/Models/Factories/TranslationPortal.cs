using OfficeApp.Models.Events;
using OfficeApp.Models.Providers;

namespace OfficeApp.Models.Factories
{
    internal class TranslationPortal
    {
        List<TranslationProvider> _translationProviders;
        private static TranslationPortal _instance;
        
        private TranslationPortal()
        {
            _translationProviders = new List<TranslationProvider>()
            {
                new FirstTranslationProvider(),
            };
        }
        public static TranslationPortal GetInstance()
        {
            if (_instance is null)
            {
                _instance = new TranslationPortal();
            }
            return _instance;
        }
        public TranslationProvider GetProvider()
        {
            
            var provider = _translationProviders.First();
            provider.OrderReady -= OrderIsFinish;
            provider.OrderReady += OrderIsFinish;
            return provider;
        }
        public event EventHandler<OrderEventArgs<Translation>> OrderOnWay;

        internal void SendOrder(Order<Translation> order)
        {
            Log.Add($"Sending order {order.Id}...");
            
            //Console.WriteLine($"Sending order {order.Id}...");
            OrderOnWay(this, new OrderEventArgs<Translation>(order));
        }

        public void OrderIsFinish(object sender, OrderEventArgs<Translation> e)
        {
            Log.Add($"TranslationPortal handling OrderReady event for order {e.Order.Id}");
            SendOrder(e.Order);
        }
    }

}
