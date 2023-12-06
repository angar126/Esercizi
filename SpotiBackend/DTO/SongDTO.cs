using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class SongDTO :Music
    {
        //public int Id {get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public ArtistDTO ArtistDTO { get; set; }
        public AlbumDTO AlbumDTO { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }
        public int PlaylistId { get; set; }
        public SongDTO() { }
        public SongDTO(Song song) {
            
            Id = song.Id;
            Title = song.Title;
        }


    }
}
