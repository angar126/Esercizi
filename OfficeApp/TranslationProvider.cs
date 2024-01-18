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

        //private Queue<Order<Food>> orderQueue = new Queue<Order<Food>>();
        public override async Task EnqueueOrder(Order<Translation> order)
        {
            orderQueue.Enqueue(order);
            Console.WriteLine($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
            //ProcessOrdersAsync();

        }
        public override async Task ProcessOrdersAsync()
        {
            while (orderQueue.Count > 0)
            {
                Order<Translation> currentOrder = orderQueue.Dequeue();
                await TranslateOrderAsync(currentOrder);
            }
        }
        private async Task TranslateOrderAsync(Order<Translation> order)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Translation order: {order.Id}");
            Console.ResetColor();
            List<Task> cookingTasks = new List<Task>();

            foreach (var food in order.List)
            {

                cookingTasks.Add(TranslateAsync(food));
            }

            await Task.WhenAll(cookingTasks);

            Console.WriteLine($"Order completed: {order.Id}");

            OnOrderReady(new OrderEventArgs<Translation>(order));
        }
        protected virtual void OnOrderReady(OrderEventArgs<Translation> e)
        {
            OrderReady.Invoke(this, e);
        }

        private async Task TranslateAsync(Translation translation)
        {
            Console.WriteLine($"{translation.Name} Translation on the job...");

            await Task.Delay(translation.ProcessingTime);

            Console.WriteLine($"{translation.Name} Translation is ready!");

        }
    }
}
