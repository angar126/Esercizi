using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace async
{
    //class Program
    //{
        //    static async Task Main(string[] args)
        //    {
        //        Hospital hospital = new Hospital();

        //        Patient Bruno = new Patient() { Name = "Bruno" };
        //        Console.WriteLine($"Sending Patient {Bruno.Name.ToUpper()}...");
        //        await hospital.DoctorAsyncParallel(Bruno);


        //        Patient Luca = new Patient() { Name = "Luca" };
        //        Console.WriteLine($"Sending Patient {Luca.Name.ToUpper()}...");
        //        await hospital.DoctorAsyncParallel(Luca);


        //        Console.ResetColor();
        //        Console.ReadLine();
        //    }
        //}
        //public class Patient
        //{
        //    public string Name { get; set; }
        //}
        //public class Hospital
        //{
        //    public async Task<string> AnalysisLab()
        //    {
        //        Console.WriteLine($"AnalysisLab: started");
        //        await Task.Delay(8000);
        //        //Console.Out.WriteLine($"-------------------------------");
        //        return "Blood OK";

        //    }
        //    public async Task<string> Radiology()
        //    {

        //        Console.WriteLine($"Radiology: started");
        //        await Task.Delay(12000);
        //        // Console.Out.WriteLine($"-------------------------------");


        //        return "TAC OK";
        //    }


        //    public async Task DoctorAsyncParallel(Patient patient)
        //    {

        //        List<Task<string>> Results = new List<Task<string>>();



        //        Task<string> RadiologyPromise = Radiology(); //Promise
        //        Task<string> AnalysisPromise = AnalysisLab(); //Promise

        //        Results.Add(RadiologyPromise);
        //        Results.Add(AnalysisPromise);




        //        //WaitAllCheckups(Results, patient);/// Runs Taks in  parallel [ Async noAwait]
        //        FluidCheckups(Results, patient);/// Runs Taks in  parallel [ Async noAwait]
        //        Console.ForegroundColor = ConsoleColor.Yellow;

        //        await Task.Run(async () =>
        //        {

        //            // Do a long task here while others tasks are running in parallel!  s
        //            Console.WriteLine($"DOCTOR CHECKUP -  STARTED for {patient.Name.ToUpper()}");
        //            await Task.Delay(new Random().Next(5000, 10000));
        //        });

        //        Console.WriteLine($"DOCTOR CHECKUP - FINISHED for {patient.Name.ToUpper()}");


        //        Console.ResetColor();
        //        // WaitAllCheckupsAndDismiss(patient);
        //        //  Console.WriteLine($"-------------------------------");


        //    }

        //    public async void WaitAllCheckups(List<Task<string>> tasks, Patient patient)
        //    {
        //        Console.WriteLine($"WaitAllCheckups:: STARTED for {patient.Name.ToUpper()}");

        //        Console.Out.WriteLine($"...Awaiting for All the exames to complete for {patient.Name.ToUpper()}...");

        //        var result = await Task.WhenAll(tasks); // Json  

        //        Console.ForegroundColor = ConsoleColor.Magenta;

        //        Console.Out.WriteLine($"{result[0]} for {patient.Name.ToUpper()} ");
        //        Console.Out.WriteLine($"-------------------------------");

        //        Console.Out.WriteLine($"{result[1]} for {patient.Name.ToUpper()}");
        //        Console.Out.WriteLine($"-------------------------------");
        //        Console.ResetColor();
        //        Console.WriteLine($"WaitAllCheckups:: FINISHED for {patient.Name.ToUpper()}");

        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"{patient.Name.ToUpper()} CAN GO HOME!");
        //        Console.ResetColor();

        //    }
        //    public async void FluidCheckups(List<Task<string>> tasks, Patient patient)
        //    {
        //        Console.WriteLine($"FluidCheckups:: STARTED for {patient.Name.ToUpper()}");

        //        while (tasks.Count > 0)
        //        {

        //            Console.Out.WriteLine($"Awaiting for any of the remaining exames to complete  for {patient.Name.ToUpper()}...");

        //            Task<string> finishedTask = await Task.WhenAny(tasks);

        //            string result = await finishedTask;

        //            if (result == "TAC OK")
        //            {
        //                Console.ForegroundColor = ConsoleColor.Green;
        //                Console.WriteLine($"{result} for {patient.Name.ToUpper()}");

        //                Console.ResetColor();
        //            }
        //            else if (result == "Blood OK")
        //            {
        //                Console.ForegroundColor = ConsoleColor.Magenta;
        //                Console.WriteLine($"{result} for {patient.Name.ToUpper()}");
        //                Console.ResetColor();
        //            }
        //            Console.ForegroundColor = ConsoleColor.Magenta;
        //            //Console.WriteLine($"-------------------------------");
        //            Console.ResetColor();

        //            // Remove the completed task from the list
        //            tasks.Remove(finishedTask);
        //        }

        //        Console.WriteLine($"FluidCheckups Finished for {patient.Name.ToUpper()}");


        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine($"{patient.Name.ToUpper()} CAN GO HOME!");
        //        Console.ResetColor();

        //        Console.WriteLine($"-------------------------------");


        //    }
        //}}
        //    static async Task Main()
        //    {
        //        Restaurant restaurant = new Restaurant();

        //        Order order1 = new Order(new List<Food> { new Pasta(), new Pizza() }) { Name = "order1" };
        //        Order order3 = new Order(new List<Food> { new Salad() }) { Name = "order3" };
        //        Order order2 = new Order(new List<Food> { new Salad(), new Steak() }) { Name = "order2" };
        //        //Order order3 = new Order(new List<Food> { new Salad()}) { Name = "order3" };
        //        await restaurant.ProcessOrdersAsync(order1, order2, order3);

        //        Console.WriteLine("All orders have been served. The restaurant is closing.");
        //    }
        //}

        //class Restaurant
        //{
        //    private const int NumberOfStoves = 4;

        //    public async Task ProcessOrdersAsync(params Order[] orders)
        //    {
        //        List<Task> cookingTasks = new List<Task>();

        //        foreach (var order in orders)
        //        {
        //            cookingTasks.Add(CookOrderAsync(order));
        //        }

        //        await Task.WhenAll(cookingTasks);
        //    }

        //    private async Task CookOrderAsync(Order order)
        //    {
        //        Console.WriteLine($"Cooking order: {string.Join(", ", order.Foods)}");

        //        List<Task> cookingTasks = new List<Task>();

        //        foreach (var food in order.Foods)
        //        {
        //            cookingTasks.Add(CookFoodAsync(food));
        //        }

        //        await Task.WhenAll(cookingTasks);

        //        Console.WriteLine($"Order completed: {order.Name}{string.Join(", ", order.Foods)}");
        //    }

        //    private async Task CookFoodAsync(Food food)
        //    {
        //        Console.WriteLine($"Cooking {food.GetType().Name}...");

        //        // Simulating cooking time
        //        await Task.Delay(food.CookingTime);

        //        Console.WriteLine($"{food.GetType().Name} is ready!");
        //    }
        //}

        //class Order
        //{
        //    public string Name { get; set; }
        //    public List<Food> Foods { get; }

        //    public Order(List<Food> foods)
        //    {
        //        Foods = foods;
        //    }
        //}

        //abstract class Food
        //{
        //    public abstract int CookingTime { get; }
        //}

        //class Pasta : Food
        //{
        //    public override int CookingTime => 3000;
        //}

        //class Pizza : Food
        //{
        //    public override int CookingTime => 3000;
        //}

        //class Salad : Food
        //{
        //    public override int CookingTime => 1000;
        //}

        //class Steak : Food
        //{
        //    public override int CookingTime => 2000;
        //}

        class Program
        {
            static async Task Main()
            {
                Restaurant restaurant = new Restaurant();

            Order order1 = new Order(new List<Food> { new Pasta(), new Pizza() }) { Name = "OR1" };
                Order order3 = new Order(new List<Food> { new Salad() }) { Name = "OR3" };
            Order order2 = new Order(new List<Food> { new Salad(), new Steak() }) { Name = "OR2" };

                restaurant.EnqueueOrder(order1);
            restaurant.EnqueueOrder(order3);
            restaurant.EnqueueOrder(order2);

                await restaurant.ProcessOrdersAsync();

                Console.WriteLine("All orders have been served. The restaurant is closing.");
            }
        }

    class Restaurant
    {
        private const int NumberOfStoves = 4;
        private Queue<Order> orderQueue = new Queue<Order>();

        public void EnqueueOrder(Order order)
        {
            orderQueue.Enqueue(order);
            Console.WriteLine($"New order added to the queue. Total orders in the queue: {orderQueue.Count}");
        }

        public async Task ProcessOrdersAsync()
        {
            while (orderQueue.Count > 0)
            {
                List<Task> cookingTasks = new List<Task>();

                for (int i = 0; i < NumberOfStoves && orderQueue.Count > 0; i++)
                {
                    Order currentOrder = orderQueue.Dequeue();
                    cookingTasks.Add(CookOrderAsync(currentOrder));
                }

                await Task.WhenAll(cookingTasks);
            }
        }

        private async Task CookOrderAsync(Order order)
        {
            Console.WriteLine($"Cooking order: {order.Name} {string.Join(", ", order.Foods)}");

            List<Task> cookingTasks = new List<Task>();

            foreach (var food in order.Foods)
            {
                cookingTasks.Add(CookFoodAsync(food));
            }

            await Task.WhenAll(cookingTasks);

            Console.WriteLine($"Order completed: {order.Name} {string.Join(", ", order.Foods)}");
        }

        private async Task CookFoodAsync(Food food)
        {
            Console.WriteLine($"Cooking {food.GetType().Name}...");

            // Simulating cooking time
            await Task.Delay(food.CookingTime);

            Console.WriteLine($"{food.GetType().Name} is ready!");
        }
    }

    class Order
    {
        public string Name { get; set; }
        public List<Food> Foods { get; }

        public Order(List<Food> foods)
        {
            Foods = foods;
        }
    }
    abstract class Food
    {
        public abstract int CookingTime { get; }
    }

    class Pasta : Food
    {
        public override int CookingTime => 2000;
    }

    class Pizza : Food
    {
        public override int CookingTime => 3000;
    }

    class Salad : Food
    {
        public override int CookingTime => 1000;
    }

    class Steak : Food
    {
        public override int CookingTime => 4000;
    }
    class Soup : Food
    {
        public override int CookingTime => 7000;
    }
    class Dessert : Food
    {
        public override int CookingTime => 1000;
    }
}