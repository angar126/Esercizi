using OfficeApp.Models.Events;


namespace OfficeApp.Models.Providers
{
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
        public override async Task EnqueueOrder(Order<Food> order)
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
                Order<Food> currentOrder = orderQueue.Dequeue();
                await CookOrderAsync(currentOrder);
            }
        }
        private async Task CookOrderAsync(Order<Food> order)
        {
            Log.Add($"Cooking order: {order.Id}");
            List<Task> cookingTasks = new List<Task>();

            foreach (var food in order.List)
            {
                while (fornelli.Count >= NumberOfStoves)
                {
                    _control = false;
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                cookingTasks.Add(CookFoodAsync(food, order));
            }

            await Task.WhenAll(cookingTasks);
            await CookOrderFinishAsync(order);


        }
        private async Task CookOrderFinishAsync(Order<Food> order)
        {
            await OnOrderReady(new OrderEventArgs<Food>(order));
            Log.Add($"Order completed: {order.Id}");
            Log.Add($"N fornelli occupati: {fornelli.Count}");
            Log.Add($"N coda: {orderQueue.Count}");
            _control = true;
        }
        protected async Task OnOrderReady(OrderEventArgs<Food> e)
        {
            OrderReady(this, e);
        }

        private async Task<bool> CookFoodAsync(Food food, Order<Food> order)
        {
            Log.Add($"Cooking {food.Name} {order.Id}...");

            fornelli.Add(food);

            await Task.Delay(food.ProcessingTime);

            Log.Add($"{food.Name} {order.Id} is ready!");

            fornelli.Remove(food);
            return true;
        }

    }

}
