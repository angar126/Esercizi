using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService
    {
        readonly Repository<Order, Order, Order> _Repository;
        readonly EmailService _EmailService;

        static OrderService instance;
        OrderService(String path)
        {
            _Repository = new Repository<Order, Order, Order>(path);
            _EmailService = new EmailService();
        }
        public static OrderService GetInstance(String path)
        {
            if (instance is null)
            {
                instance = new OrderService(path);
            }
            return instance;
        }
        public void makeOrder(Order order,User user,string Address, string subject,string body)
        {
            _Repository.Update(order);
            _EmailService.SendEmail(user, Address, subject, body);
        }
    }
}
