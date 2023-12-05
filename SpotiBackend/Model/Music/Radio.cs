using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Radio :ICountable
    {
        
        public string Name { get; set; }
        public int Rating { get; set; }
        public Playlist OnAirPlaylist { get; set; }
        public Radio() { }
        public Radio(string name)
        {
            Name = name;
        }
        public Radio(string name, Playlist Playlist)
        {
            Name = name;
            OnAirPlaylist = Playlist;
        }
        public Radio(string name, Playlist Playlist, int rating)
        {
            Name = name;
            OnAirPlaylist = Playlist;
            Rating = rating;
        }
    }
}
