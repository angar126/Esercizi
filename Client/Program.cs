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
            serviceCollection.AddTransient<MyService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();


            var setting = serviceProvider.GetService<IOptions<MySetting>>()?.Value;
            string pathUserRepo= setting.UserRepo; ;
            string pathProductRepo = setting.ProductRepo;
            string pathOrderRepo = setting.OrderRepo;
            string emailToOrder = setting.OrderEmail;

            Console.WriteLine("Inserisci nome utente(finto login): in questo momento Monique/Glover");
            string Name = Console.ReadLine();

            UserService us = UserService.GetInstance(pathUserRepo);
            User user = us.GetByName(Name);

            ProductService productService = ProductService.GetInstance(pathProductRepo);
            int idProd = MenuItems.CreateMenu(productService.GetAll().Select(item => item.Name).ToArray())+1;// +1 perchè ho riutilizzato il menu di spotify

            OrderService os = OrderService.GetInstance(pathOrderRepo);
            Order order = new Order() { Id=1,IdUser=user.Id,IdProduct = productService.Get(idProd).Id};
            os.makeOrder(order,user,emailToOrder,""+order.Id,TemplateEmail.Text(user,order));

        }
        public class MyService
        {
            private readonly MySetting _configuration;

            public MyService(IOptions<MySetting> emailSettings)
            {
                _configuration = emailSettings.Value;
            }

            public void DoSomething()
            {
                Console.WriteLine();

                Console.WriteLine($"{_configuration.UserRepo}");

            }
        }
        /*static void Main(string[] args)
        {
            var FromAddress = new MailAddress("marquis.mueller@ethereal.email", "CORSONET 2023");
            var ToAddress = new MailAddress("bruno_ferreira@hotmail.it");
            const string fromPassword = "BT6WuFezhU9FUwPVNW";


            var smtp = new SmtpClient
            {
                Host = "smtp.ethereal.email",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(FromAddress, ToAddress)
            {
                Subject = "gffgfffg",
                Body = "gfgfgfgffg"
            })
            {
                smtp.Send(message);
            }
        }*/
    }
}
