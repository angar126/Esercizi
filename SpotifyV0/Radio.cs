using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class Radio
    {
        string _name;
        Playlist _onAirPlaylist;

        public string Name { get { return _name; } }
        public Radio (string Name)
        {
            _name = Name;
        }
        public Playlist OnAirPlaylist { get { return _onAirPlaylist; } set { _onAirPlaylist = value; } }
    }
}
