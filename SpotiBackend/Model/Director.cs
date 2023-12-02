using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public class Director:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Director(string name)
        {
            Name = name;
            Rating = 0;
        }
    }
}
