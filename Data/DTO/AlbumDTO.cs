using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class AlbumDTO
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public SongDTO[] SongsDTO { get; set; } = Array.Empty<SongDTO>();
        public ArtistDTO ArtistDTO { get; set; }
        public string Genre { get; set; }
    }
}
