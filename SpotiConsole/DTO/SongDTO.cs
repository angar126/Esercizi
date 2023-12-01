using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl.DTO
{
    public class SongDTO : IPlayable
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public ArtistDTO Artist { get; set; }
        public AlbumDTO Album { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }
        public int PlaylistId { get; set; }
        public double TimeMillis { get ; set; }

        public SongDTO(string title, ArtistDTO artist, AlbumDTO album, double timeMillis)
        {
            Title = title;
            Artist = artist;
            Album = album;
            TimeMillis = timeMillis;
        }
        public SongDTO(string title, ArtistDTO artist, AlbumDTO album, double timeMillis, int rating)
        {
            Title = title;
            Artist = artist;
            Album = album;
            TimeMillis = timeMillis;
            Rating = rating;
            
        }
        public SongDTO(string title) { Title = title; }
        public SongDTO() { }
    }
}
