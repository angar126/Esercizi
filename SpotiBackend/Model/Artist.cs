using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Artist:ICountable
    {
        public string Name { get; set; }
        public Album[] Albums { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}
