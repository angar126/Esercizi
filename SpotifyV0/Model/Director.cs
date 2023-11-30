using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    public class Director : ICountable
    {
        string _name;
        int _count;
        public string Name { get { return _name; } }
        public int Count { get { return _count; } set { _count = value; } }
        public Director(string Name) {
            _name = Name;
            _count = 0;
        }
    }
}
