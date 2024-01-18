using OfficeApp.Models.Events;
using OfficeApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public interface IFoodProvider
    {
        event EventHandler<OrderEventArgs<Food>> OrderReady;
    }
    public abstract class FoodProvider : Provider<Food>
    {
        public delegate void OnOrderRecivedEventHandler(object sender, OrderEventArgs<Food> e);

        public event OnOrderRecivedEventHandler OrderReady;
        public abstract TimeSpan OpenTime { get; }
        public abstract TimeSpan CloseTime { get; }
        public override List<Food> ListOfItems { get; set; }

        static private int NumberOfStoves = 4;

        static List<Food> fornelli = new List<Food>();

        static protected Queue<Order<Food>> orderQueue = new Queue<Order<Food>>();

        //private Queue<Order<Food>> orderQueue = new Queue<Order<Food>>();
        public override async Task EnqueueOrder(Order<Food> order)
        {
            orderQueue.Enqueue(order);
            Console.WriteLine($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
            //ProcessOrdersAsync();
            if(fornelli.Count == 0 ) await ProcessOrdersAsync();
        }
        public  async Task ProcessOrdersAsync()
        { 
            while (orderQueue.Count > 0)
            {
                //while (fornelli.Count >= NumberOfStoves)
                //{
                //    await Task.Delay(TimeSpan.FromSeconds(1));
                //}
                Order<Food> currentOrder = orderQueue.Dequeue();
                await CookOrderAsync(currentOrder);
            }
        }
        private async Task CookOrderAsync(Order<Food> order)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cooking order: {order.Id}");
            Console.ResetColor();
            List<Task> cookingTasks = new List<Task>();

            foreach (var food in order.List)
            {
                while (fornelli.Count >= NumberOfStoves)
                {
                    //Random rd = new Random();
                    //await Task.Delay(TimeSpan.FromSeconds(rd.Next(5)));
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                cookingTasks.Add(CookFoodAsync(food));
            }
            //await Task.WhenAny(cookingTasks);

            await Task.WhenAll(cookingTasks);

            Console.WriteLine($"Order completed: {order.Id}");
            Console.WriteLine($"N fornelli: {fornelli.Count}");

            OnOrderReady(new OrderEventArgs<Food>(order));
            
        }
        protected virtual void OnOrderReady(OrderEventArgs<Food> e)
        {
            OrderReady?.Invoke(this,e);
        }

        private async Task CookFoodAsync(Food food)
        {
            Console.WriteLine($"Cooking {food.Name}...");

            fornelli.Add(food);

            await Task.Delay(food.ProcessingTime);

            Console.WriteLine($"{food.Name} is ready!");

            fornelli.Remove(food);
        }
        
    }

}
