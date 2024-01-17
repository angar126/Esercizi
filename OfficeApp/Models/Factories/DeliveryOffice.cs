using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Factories
{
    public class DeliveryOffice : IOffice
    {
        public DeliveryOffice() { }
        public FoodProvider GetProvider()
        {
            FoodPortal portal = FoodPortal.GetInstance();
            return portal.GetProvider();
        }
        public async Task SendOrder(Order<Food> order, Provider<Food> provider)
        {
            FoodPortal portal = FoodPortal.GetInstance();
            await portal.SendOrder(order, provider);
        }
        
        // Metodo chiamato quando un ordine è pronto
        private void HandleOrderReady(object sender, OrderEventArgs<Food> e)
        {
            // Gestisci l'evento OrderReady qui
            Console.WriteLine($"DeliveryOffice handling OrderReady event for order {e.Order.Id}");
            // Puoi implementare la logica per la consegna dell'ordine qui
        }
    }
}
