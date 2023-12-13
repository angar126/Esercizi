using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class TemplateEmail
    {
        static public string Text(User user, Order order)
        {
            if (user.Type == 1)
            {
                return $"Loyal user - Order by {user.Name} : Id Product {order.IdProduct}";
            }
            return $"Order by {user.Name} : Id Product {order.IdProduct}";
        }
    }
}
