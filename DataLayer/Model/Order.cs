using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdProduct { get; set; }
        public Order() { }
       
        //poi dto
        public Order(Order order) { 
            Id = order.Id;
            IdUser = order.IdUser;
            IdProduct = order.IdProduct;
        }
    }
}
