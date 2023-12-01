using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiControl.DTO
{
    public class AlbumDTO:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public SongDTO[] Songs { get; set; }
        public ArtistDTO Artist { get; set; }
        public string Genre { get; set; }
        public AlbumDTO() { }
        public AlbumDTO(string name, ArtistDTO artist)
        {
            Name = name;
            Artist = artist;
            Rating = 0;
        }
        public AlbumDTO(string name, ArtistDTO artist, int rating)
        {
            Name = name;
            Artist = artist;
            Rating = rating;
        }
    }
}
