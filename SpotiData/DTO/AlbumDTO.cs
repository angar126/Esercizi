using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class AlbumDTO: Music, ICountable
    {
        public string Name { get; set; }
        
        public SongDTO[] SongsDTO { get; set; } = Array.Empty<SongDTO>();
        public ArtistDTO[] ArtistDTO { get; set; }
        public string Genre { get; set; }
    }
}
