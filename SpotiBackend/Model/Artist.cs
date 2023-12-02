using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public class Artist:ICountable
    {
        public string Name { get; set; }
        public Album[] Albums { get; set; } = Array.Empty<Album>();
        public string Genre { get; set; }
        public int Rating { get; set; }
        public Artist() { }
        public Artist(string name)
        {
            Name = name;
            Rating = 0;
        }
        public Artist(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
        public void AddAlbum(Album album)
        {
            if (!Albums.Contains(album))
                Albums = Albums.Append(album).ToArray();
        }
    }
}
