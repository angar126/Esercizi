using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Services;
using DataLayer;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using SpotiView;
using SpotiControl;
using System.Linq;
using DataLayer.Model;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.Hosting;


namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();



            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(configuration);

            //serviceCollection.AddLogging(builder =>
            //{
            //    builder.AddConfiguration(configuration.GetSection("Logging"));
            //    builder.AddConsole();
            //    builder.AddDebug();
            //});


            //serviceCollection.Configure<MySetting>(configuration.GetSection("MyServiceSettings"));
            //serviceCollection.AddTransient<IOrderService, OrderService>();
            //serviceCollection.AddTransient<IProductService, ProductService>();
            //serviceCollection.AddTransient<IUserService, UserService>();
            //serviceCollection.AddTransient<IEmailService, EmailService>();
            //serviceCollection.AddServiceLayerServices<User, User, User>(configuration);
            //serviceCollection.AddServiceLayerServices<Product, Product, Product>(configuration);
            //serviceCollection.AddServiceLayerServices<Order, Order, Order>(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            //serilog
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(configuration)
                    //.MinimumLevel.Debug()
                    //.WriteTo.Console()
                    .CreateLogger();
                var host = CreatehosteBuilder(args, configuration).Build();
                Log.Logger.Information(" App has started.");
                var myservice = host.Services.GetService<DbContext>();


                Log.Logger.Information(" App has finished.");
            


            //finta console
            Console.WriteLine("Inserisci nome utente(finto login): in questo momento Monique/Glover");
            string Name = Console.ReadLine();
            
            var userService = serviceProvider.GetRequiredService<IUserService>();
            User user = userService.GetByName(Name);

            var productService = serviceProvider.GetRequiredService<IProductService>();
            int idProd = MenuItems.CreateMenu(productService.GetAll().Select(item => item.Name).ToArray())+1;// +1 perchè ho riutilizzato il menu di spotify

            var orderService = serviceProvider.GetRequiredService<IOrderService>();
            Order order = new Order() { Id=1,IdUser=user.Id,IdProduct = productService.Get(idProd).Id};
            string emailToOrder = serviceProvider.GetService<IOptions<MySetting>>()?.Value.OrderEmail;
            orderService.makeOrder(order, user, emailToOrder, "" + order.Id, TemplateEmail.Text(user, order));
            }
            catch (System.Exception)
            {
                Log.Logger.Error(" App has Crashed!.");

            }
        }
        public static IHostBuilder CreatehosteBuilder(string[] args, IConfiguration configuration)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(serviceCollection =>
            {
                serviceCollection.Configure<MySetting>(configuration.GetSection("MyServiceSettings"));
                serviceCollection.AddTransient<IOrderService, OrderService>();
                serviceCollection.AddTransient<IProductService, ProductService>();
                serviceCollection.AddTransient<IUserService, UserService>();
                serviceCollection.AddTransient<IEmailService, EmailService>();
                serviceCollection.AddServiceLayerServices<User, User, User>(configuration);
                serviceCollection.AddServiceLayerServices<Product, Product, Product>(configuration);
                serviceCollection.AddServiceLayerServices<Order, Order, Order>(configuration);

            }).UseSerilog();
        }
    }
}
