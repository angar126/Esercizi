using OfficeApp.Front;
using OfficeApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OfficeApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ConsoleApp consoleApp = new ConsoleApp();
            //consoleApp.GetService();
            ConsoleApp consoleApp = new ConsoleApp();
            consoleApp.GetService();

        }
    }
}