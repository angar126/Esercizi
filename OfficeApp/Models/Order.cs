using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public class Order<T>
    {
        public int Id { get; }
        public List<T> List { get; set; }

        public Order(int id, List<T> list)
        {
            Id = id;
            List = list;
        }
        public Order(List<T> list)
        {
            List = list;
        }
        public Order(){
            Random rd = new Random();
            Id=rd.Next(1000);
            List = new List<T>();
        }
    }
}
