using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class SongDTO :Music, IPlayable
    {
        //public int Id {get; set;}
        public string Title { get; set; }
        public Artist ArtistDTO { get; set; }
        public Album AlbumDTO { get; set; }
        public int PlaylistId { get; set; }
        public SongDTO() { }
        public SongDTO(Song song) {
            
            Id = song.Id;
            Title = song.Title;
        }
    }
}
