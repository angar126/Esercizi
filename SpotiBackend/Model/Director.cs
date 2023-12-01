using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Director : ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
