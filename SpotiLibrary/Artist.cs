using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiModel
{
    public class Artist:ICountable
    {
        string _name;
        //Album[] _albums;
        string _genre;
        int _count;

        
        public string Name { get { return _name; } }
        //public Album[] Albums { get { return _albums; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public int Count { get { return _count; } set { _count = value; } }
        public Artist() { }
        public Artist(string Name)
        {
            _name = Name;
            _count = 0;
        }
        public Artist(string Name, int Count)
        {
            _name = Name;
            _count = Count;
        }

    }
}
