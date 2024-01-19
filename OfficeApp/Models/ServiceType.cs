using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp.Models
{
    public abstract class ServiceType
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
