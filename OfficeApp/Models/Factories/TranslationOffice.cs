using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Factories
{
    public class TranslationOffice : IOffice
    {
        private static TranslationOffice _instance;
        private TranslationOffice() { }
        //public IPortal CreateFoodOrder()
        //{
        //    return new TranslationPortal();
        //}
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
            //portal.OrderOnWay += HandleOrderCooming;
            return portal.GetProvider();
        }
        //public void SendOrder(Order<Food> order)
        //{
        //    //Task.Delay(TimeSpan.FromSeconds(10));
        //    Console.WriteLine($"Order {order.Id} is in the office");
        //}

        //private void HandleOrderCooming(object sender, OrderEventArgs<Food> e)
        //{
        //    Console.WriteLine($"DeliveryOffice handling OrderCooming event for order {e.Order.Id}");
        //    //e.FoodPortal.OrderOnWay -= HandleOrderCooming;

        //    SendOrder(e.Order);
        //}
    }
}
