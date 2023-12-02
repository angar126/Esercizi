using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Song : IPlayable
    {
        public int Id {get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }
        public int PlaylistId { get; set; }
        public double TimeMillis { get ; set; }

        public Song(string title, Artist artist, Album album, double timeMillis)
        {
            Title = title;
            Artist = artist;
            Album = album;
            TimeMillis = timeMillis;
        }
        public Song(string title, Artist artist, Album album, double timeMillis, int rating)
        {
            Title = title;
            Artist = artist;
            Album = album;
            TimeMillis = timeMillis;
            Rating = rating;
            
        }
        public Song(string title) { Title = title; }
        public Song() { }
    }
}
