using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Playlist:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Song[] Songs { get; set; }
        public int PlaylistId { get; set; }
        public Playlist() { }
        public Playlist(string Name)
        {
            Name = Name;
            Rating = 0;
        }
        public Playlist(string Name, Song[] Songs)
        {
            Name = Name;
            Songs = Songs;
            Rating = 0;
        }
        public Playlist(string Name, Song[] Songs, int Count)
        {
            Name = Name;
            Songs = Songs;
            Rating = Count;
        }
        public void AddSong(Song song)
        {
            if (!Songs.Contains(song))
                Songs = Songs.Append(song).ToArray();
        }
        public void RemoveSong(Song song)
        {
            Songs = Songs.Where(i => i != song).ToArray();

        }
    }
}
