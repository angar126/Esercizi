using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Radio : ICountable
    {
        public int _count;
        public string Name { get; set; }
        public int Rating { get; set; }

    }
}
