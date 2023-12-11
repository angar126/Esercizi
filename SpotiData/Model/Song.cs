using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Song : Music, IPlayable
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int IdArtist { get; set; }
        public int IdAlbum { get; set; }
        public string ReleaseDate { get; set; }
        public int PlaylistId { get; set; }
        public double TimeMillis { get ; set; }

        
    }
}
