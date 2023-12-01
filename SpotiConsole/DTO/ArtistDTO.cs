using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiControl.DTO
{
    public class ArtistDTO:ICountable
    {
        public string Name { get; set; }
        public AlbumDTO[] Albums { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public ArtistDTO() { }
        public ArtistDTO(string name)
        {
            Name = name;
            Rating = 0;
        }
        public ArtistDTO(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
    }
}
