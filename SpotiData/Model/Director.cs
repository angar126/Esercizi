using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class Director:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
       
    }
}
