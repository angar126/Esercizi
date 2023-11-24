using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0.Model
{
    class Artist
    {
        string _alias;
        //Album[] _albums;
        string _genre;
        public string Alias { get { return _alias; } }
        //public Album[] Albums { get { return _albums; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public Artist() { }
        public Artist(string Alias)
        {
            _alias = Alias;
        }

    }
}
