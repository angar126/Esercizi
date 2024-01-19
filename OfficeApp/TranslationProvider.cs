using OfficeApp.Models.Events;
using OfficeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
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
            Console.WriteLine($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Translation order: {order.Id}");
            Console.ResetColor();
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
            Console.WriteLine($"Order completed: {order.Id}");
            Console.WriteLine($"N coda: {orderQueue.Count}");
            _control = true;
        }
        protected async Task OnOrderReady(OrderEventArgs<Translation> e)
        {
            OrderReady(this, e);
        }

        private async Task<bool> TraslateAsync(Translation txt, Order<Translation> order)
        {
            Slot.Add(txt);
            Console.WriteLine($"Translation {txt.Name} {order.Id}...");

            await Task.Delay(txt.ProcessingTime);

            Console.WriteLine($"{txt.Name} {order.Id} is ready!");
            Slot.Remove(txt);
            return true;
        }

    }
}
