using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    public class Playlist : IPlaylist
    {
        string _name;
        Song[] _songs;
        int _count;
        public string Name { get { return _name; } set { _name = value; } }
        public int Count { get { return _count; } set { _count = value; } }
        
        public Song[] Songs { get { return _songs; } set { _songs = value; } }
        public Playlist() { }
        public Playlist(string Name)
        {
            _name = Name;
            _count = 0;
        }
        public Playlist(string Name, Song[] Songs)
        {
            _name = Name;
            _songs = Songs;
            _count = 0;
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
