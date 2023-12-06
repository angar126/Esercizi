using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
