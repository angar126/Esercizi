using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    internal class Playlist
    {
        string _name;
        Song[] _songs;

        public string Name {  get { return _name; } }
        public Song[] Songs { get { return _songs; } }
        public Playlist() { }
        public Playlist(string Name)
        {
            _name = Name;
        }
        public void AddSong( Song song)
        {
            _songs = _songs.Append(song).ToArray();
        }
        public void RemoveSong(Song song)
        {
            _songs = _songs.Where(i => i != song).ToArray();

        }
    }
}
