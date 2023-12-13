using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Services
{
    public interface IOrderService
    {
        public void makeOrder(Order order, User user, string Address, string subject, string body);
    }
    public interface IEmailService
    {
        public void SendEmail(User user, string toAddress, string subject, string body);
    }
    public interface IProductService
    {
        public List<Product> GetAll();
        public Product Get(int Id);
    }
    public interface IUserService
    {
        public List<User> GetAll();
        public User Get(int Id);
        public User GetByName(string Name);
    }
}
