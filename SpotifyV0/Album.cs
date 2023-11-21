using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    internal class Album
    {
        string _name;
        Artist _artist;
        Song[] _songs;

        public string Name {  get { return _name; } }
        public Artist Artist { get { return _artist; } }
        public Song[] Songs { get { return _songs; } }
        public Album (string Name, Artist artist)
        {
            _name = Name;
            _artist = artist;
        }
    }
}
