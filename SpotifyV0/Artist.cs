using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class Artist
    {
        string _alias;
        //Album[] _albums;

        public string Alias { get { return _alias; } }
        //public Album[] Albums { get { return _albums; } }

        public Artist() { }
        public Artist(string Alias)
        {
            _alias = Alias;
        }

    }
}
