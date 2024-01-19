using OfficeApp.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models.Providers
{
    public class TranslationProvider : Provider<Translation>
    {

        public delegate void OnOrderRecivedEventHandler(object sender, OrderEventArgs<Translation> e);

        public event OnOrderRecivedEventHandler OrderReady;
        public override List<Translation> ListOfItems { get; set; }

        static private int NumberOftranslators = 1;

        static List<Translation> Slot = new List<Translation>();

        static protected Queue<Order<Translation>> orderQueue = new Queue<Order<Translation>>();
        static bool _control = true;
        public override async Task EnqueueOrder(Order<Translation> order)
        {
            orderQueue.Enqueue(order);
            Log.Add($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
            await Next();
        }
        public async Task Next()
        {
            if (_control)
            {
                await ProcessOrdersAsync();
            }
        }
        public async Task ProcessOrdersAsync()
        {
            while (orderQueue.Count > 0)
            {
                Order<Translation> currentOrder = orderQueue.Dequeue();
                await TranslationOrderAsync(currentOrder);
            }
        }
        private async Task TranslationOrderAsync(Order<Translation> order)
        {
            Log.Add($"Translation order: {order.Id}");
            List<Task> traslationTasks = new List<Task>();

            foreach (var txt in order.List)
            {
                while (Slot.Count >= NumberOftranslators)
                {
                    _control = false;
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                traslationTasks.Add(TraslateAsync(txt, order));
            }

            await Task.WhenAll(traslationTasks);
            await CookOrderFinishAsync(order);
        }
        private async Task CookOrderFinishAsync(Order<Translation> order)
        {
            await OnOrderReady(new OrderEventArgs<Translation>(order));
            Log.Add($"Order completed: {order.Id}");
            Log.Add($"N coda: {orderQueue.Count}");
            _control = true;
        }
        protected async Task OnOrderReady(OrderEventArgs<Translation> e)
        {
            OrderReady(this, e);
        }

        private async Task<bool> TraslateAsync(Translation txt, Order<Translation> order)
        {
            Slot.Add(txt);
            Log.Add($"Translation {txt.Name} {order.Id}...");

            await Task.Delay(txt.ProcessingTime);

            Log.Add($"{txt.Name} {order.Id} is ready!");
            Slot.Remove(txt);
            return true;
        }

    }
}
