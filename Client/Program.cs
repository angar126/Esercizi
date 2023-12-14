﻿using Microsoft.Extensions.Configuration;
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
            serviceCollection.Configure<MySetting>(configuration.GetSection("MyServiceSettings"));
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddServiceLayerServices<User, User, User>(configuration);
            serviceCollection.AddServiceLayerServices<Product, Product, Product>(configuration);
            serviceCollection.AddServiceLayerServices<Order, Order, Order>(configuration);
            //serviceCollection.AddTransient<IRepository<User, User, User>, Repository<User, User, User>>();
            //serviceCollection.AddTransient<IRepository<Product, Product, Product>, Repository<Product, Product, Product>>();
            //serviceCollection.AddTransient<IRepository<Order, Order, Order>, Repository<Order, Order, Order>>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //var setting = serviceProvider.GetService<IOptions<MySetting>>()?.Value;

            //string pathUserRepo= setting.UserRepo; ;
            //string pathProductRepo = setting.ProductRepo;
            //string pathOrderRepo = setting.OrderRepo;
            //string emailToOrder = setting.OrderEmail;

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
            orderService.makeOrder(order,user, emailToOrder, ""+order.Id,TemplateEmail.Text(user,order));
        }
    }
}
