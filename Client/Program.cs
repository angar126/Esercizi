using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Services;
using DataLayer;
using Microsoft.Extensions.Options;
using static Client.Program;
using System.Collections.Generic;

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


            MyService service = serviceProvider.GetService<MyService>();
            service.DoSomething();

            if (setting != null)
            {
                string pathUserRepo = setting.UserRepo;
                string pathProductRepo = setting.ProductRepo;
                string emailToOrder = setting.OrderEmail;

                Console.WriteLine(pathUserRepo + pathProductRepo + emailToOrder);
            }
            else
            {
                Console.WriteLine("MySetting is null. Check configuration.");
            }

            List<User> list = UserService.GetInstance(setting.UserRepo).GetAll();
            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }
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
