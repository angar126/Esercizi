using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Interfaces;

namespace SpotifyV0.Model
{
    internal class Album : IPlaylist,ICountable
    {
        string _name;
        Artist _artist;
        Song[] _songs;
        string _genre;
        int _count;
        public int Count { get { return _count; } set { _count = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public Song[] Songs { get { return _songs; } set { _songs = value; } }
        public Artist Artist { get { return _artist; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        
        public Album(string Name, Artist artist)
        {
            _name = Name;
            _artist = artist;
        }
        public Album(string Name, Artist artist,int Count)
        {
            _name = Name;
            _artist = artist;
            _count = Count;
        }
    }
}
