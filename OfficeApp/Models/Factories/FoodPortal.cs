using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;

namespace OfficeApp.Models.Factories
{
    public class FoodPortal : IPortal, IFoodProvider
    {
        List<FoodProvider>? _foodProviders;
        private static FoodPortal _instance;

        private FoodPortal()
        {
            _foodProviders = new List<FoodProvider>()
            {
                new BreakfastProvider(){Name = "Caffe del corso"},
                new BreakfastProvider(){Name = "StarCaffe"},
                new LunchProvider(){Name = "Da Mauro"},
                new LunchProvider(){Name = "Da Stefano"},
                new DinnerProvider(){Name = "Ristorante la sera"},
                new DinnerProvider(){Name = "Ristorante le stelle"}

            };
        }
        public static FoodPortal GetInstance()
        {
            if (_instance is null)
            {
                _instance = new FoodPortal();
            }
            return _instance;
        }
        public FoodProvider GetProvider()
        {
            TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
            Random random = new Random();
            var provider = _foodProviders
                .Where(provider => provider.OpenTime <= timeOfDay && provider.CloseTime >= timeOfDay)
                .OrderBy(_ => random.Next())
                .FirstOrDefault();
            return provider;
        }
        public event EventHandler<OrderEventArgs<Food>>? OrderReady;

        protected virtual void OnOrderReady(OrderEventArgs<Food> e)
        {
            OrderReady?.Invoke(this, e);
        }

        internal async Task SendOrder(Order<Food> order, Provider<Food> provider)
        {
            provider.EnqueueOrder(order);
            await provider.ProcessOrdersAsync();
        }
    }
}
