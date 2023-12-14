using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class ArtistDTO: Music, ICountable
    {
        public string Name { get; set; }
        public int[] IdAlbumsDTO { get; set; }

        public ArtistDTO() { }
        public ArtistDTO(Artist artist)
        {
            Id = artist.Id;
            Rating = artist.Rating;
            Name = artist.Name;
            IdAlbumsDTO = artist.IdAlbums.Split('|').Select(s => int.Parse(s)).ToArray();

        }

    }
}
