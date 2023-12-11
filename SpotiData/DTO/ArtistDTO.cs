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
        public AlbumDTO[] AlbumsDTO { get; set; } = Array.Empty<AlbumDTO>();
        public string Genre { get; set; }

    }
}
