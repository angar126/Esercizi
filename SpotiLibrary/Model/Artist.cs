using SpotifyV0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0.Model
{
    class Artist:ICountable
    {
        string _alias;
        //Album[] _albums;
        string _genre;
        int _count;
        public int Count { get { return _count; } set { _count = value; } }
        public string Alias { get { return _alias; } }
        //public Album[] Albums { get { return _albums; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public Artist() { }
        public Artist(string Alias)
        {
            _alias = Alias;
            _count = 0;
        }
        public Artist(string Alias, int Count)
        {
            _alias = Alias;
            _count = Count;
        }

    }
}
