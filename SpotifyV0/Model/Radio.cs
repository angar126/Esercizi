using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Interfaces;

namespace SpotifyV0.Model
{
    class Radio : ICountable
    {
        string _name;
        Playlist _onAirPlaylist;
        int _count;
        public int Count { get { return _count; } set { _count = value; } }
        public string Name { get { return _name; } }
        public Radio(string Name)
        {
            _name = Name;
        }
        public Radio(string Name, Playlist Playlist)
        {
            _name = Name;
            _onAirPlaylist = Playlist;
        }
        public Radio(string Name, Playlist Playlist, int Count)
        {
            _name = Name;
            _onAirPlaylist = Playlist;
            _count = Count;
        }
        public Playlist OnAirPlaylist { get { return _onAirPlaylist; } set { _onAirPlaylist = value; } }
    }
}
