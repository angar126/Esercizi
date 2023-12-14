using DataLayer;
using DataLayer.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService: IOrderService
    {
        readonly IRepository<Order, Order, Order> _Repository;
        readonly EmailService _EmailService;

        //static OrderService instance;
        public OrderService(IRepository<Order, Order, Order> configuration)
        {
            _Repository = configuration;
            _EmailService = new EmailService();
        }
        public OrderService(IRepository<Order, Order, Order> configuration, IOptions<MySetting> email)
        {
            _Repository = configuration;
            _EmailService = new EmailService(email);
        }
        //public static OrderService GetInstance(IConfiguration configuration)
        //{
        //    if (instance is null)
        //    {
        //        instance = new OrderService(configuration);
        //    }
        //    return instance;
        //}
        public void makeOrder(Order order,User user,string Address, string subject,string body)
        {
            _Repository.Update(order);
            _EmailService.SendEmail(user, Address, subject, body);
        }
        public void makeOrder2(Order order, User user, string subject, string body)
        {
            _Repository.Update(order);
            _EmailService.SendEmail(user, subject, body);
        }
    }
}
