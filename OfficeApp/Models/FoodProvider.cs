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
        static bool _control = true;
        //private Queue<Order<Food>> orderQueue = new Queue<Order<Food>>();
        public override async Task EnqueueOrder(Order<Food> order)
        {
            orderQueue.Enqueue(order);
            Console.WriteLine($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
            //if(fornelli.Count == 0 ) await ProcessOrdersAsync();
            Next();
        }
        public async Task Next()
        {
            //while (orderQueue.Count > 0)
            //{
                if (_control)
                {
                    await ProcessOrdersAsync();
                }
            //}
        }
        public async Task ProcessOrdersAsync()
        {
            while (orderQueue.Count > 0)
            {
                //if (fornelli.Count <= NumberOfStoves)
                //{
                Order<Food> currentOrder = orderQueue.Dequeue();
                    await CookOrderAsync(currentOrder);
            }
        //}

        //_control = true;
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
                    _control = false;
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                cookingTasks.Add(CookFoodAsync(food));
            }
            //await Task.WhenAny(cookingTasks);

            await Task.WhenAll(cookingTasks);
            // OnOrderReady(new OrderEventArgs<Food>(order));
            await CookOrderFinishAsync(order);
            

        }
        private async Task CookOrderFinishAsync(Order<Food> order)
        {
            await OnOrderReady(new OrderEventArgs<Food>(order));
            Console.WriteLine($"Order completed: {order.Id}");
            Console.WriteLine($"N fornelli occupati: {fornelli.Count}");
            Console.WriteLine($"N coda: {orderQueue.Count}");
            _control = true;
        }
        protected virtual async Task<bool> OnOrderReady(OrderEventArgs<Food> e)
        {
            OrderReady(this, e);
            return true;
        }

        private async Task<bool> CookFoodAsync(Food food)
        {
            Console.WriteLine($"Cooking {food.Name}...");

            fornelli.Add(food);

            await Task.Delay(food.ProcessingTime);

            Console.WriteLine($"{food.Name} is ready!");

            fornelli.Remove(food);
            return true;
        }
        
    }

}
