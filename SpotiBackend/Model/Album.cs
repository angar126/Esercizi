using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public class Album:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Song[] Songs { get; set; }
        public Artist Artist { get; set; }
        public string Genre { get; set; }
        public Album() { }
        public Album(string name, Artist artist)
        {
            Name = name;
            Artist = artist;
            Rating = 0;
        }
        public Album(string name, Artist artist, int rating)
        {
            Name = name;
            Artist = artist;
            Rating = rating;
        }
        public void AddSong(Song song)
        {
            if (!Songs.Contains(song))
                Songs = Songs.Append(song).ToArray();
        }
    }
}
