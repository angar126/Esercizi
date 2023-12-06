using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Song: Music
    {
       //public int Id {get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public string ReleaseDate { get; set; }
        public int Rating { get; set; }
        public int PlaylistId { get; set; }
        public double TimeMillis { get ; set; }

        public Song() { }
        public Song(SongDTO song)
        {
            Id = song.Id;
            Title = song.Title;
        }

    }
}
