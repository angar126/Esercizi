using Microsoft.Extensions.Configuration;
using System;

namespace Serilog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

        }
    }
}
