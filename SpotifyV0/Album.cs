using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    internal class Album: IPlaylist
    {
        string _name;
        Artist _artist;
        Song[] _songs;

        public string Name { get { return _name; } set { _name = value; } }
        public Song[] Songs { get { return _songs; } set { _songs = value; } }
        public Artist Artist { get { return _artist; } }
        public Album (string Name, Artist artist)
        {
            _name = Name;
            _artist = artist;
        }
    }
}
