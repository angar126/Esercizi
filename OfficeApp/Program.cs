using OfficeApp.Front;
using OfficeApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OfficeApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleApp consoleApp = new ConsoleApp();
            consoleApp.GetService();
            //List<Food> list = new List<Food>();
            //Food caffe = new Food("caffe", TimeSpan.FromSeconds(30));
            //list.Add(caffe);
            //var foodProvider = new BreakfastProvider();
            //var order1 = new Order(1, new List<Food> { new Food("Pizza", TimeSpan.FromSeconds(5)), new Food("av1", TimeSpan.FromSeconds(3)), new Food("av2", TimeSpan.FromSeconds(3)), new Food("av3", TimeSpan.FromSeconds(3)), new Food("av4", TimeSpan.FromSeconds(3)), });
            //var order2 = new Order(2, new List<Food> { new Food("Burger", TimeSpan.FromSeconds(3)), new Food("Fries", TimeSpan.FromSeconds(2)) });

            //foodProvider.EnqueueOrder(order1);
            //foodProvider.EnqueueOrder(order2);
            //// Avviare un thread per l'elaborazione degli ordini
            //var processOrdersTask = foodProvider.ProcessOrdersAsync();

            //// Creare alcuni ordini di esempio e accodarli
            

            //// Attendere la fine dell'elaborazione degli ordini
            //await processOrdersTask;
        }
    }
}