using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Interfaces;

namespace SpotifyV0.Model
{
    internal class Playlist : IPlaylist,ICountable
    {
        string _name;
        Song[] _songs;
        int _count;
        public int Count { get { return _count; } set { _count = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public Song[] Songs { get { return _songs; } set { _songs = value; } }
        public Playlist() { }
        public Playlist(string Name)
        {
            _name = Name;
        }
        public Playlist(string Name, Song[] Songs)
        {
            _name = Name;
            _songs = Songs;
        }
        public Playlist(string Name, Song[] Songs,int Count)
        {
            _name = Name;
            _songs = Songs;
            _count = Count;
        }
        public void AddSong(Song song)
        {
            if(!_songs.Contains(song))
            _songs = _songs.Append(song).ToArray();
        }
        public void RemoveSong(Song song)
        {
            _songs = _songs.Where(i => i != song).ToArray();

        }
    }
}
