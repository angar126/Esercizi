using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotiData
{
    public class DataBase
    {
        public Song[] SongDB {get;set;}
        public Radio[] RadioDB { get; set; }
        public Playlist[] PlaylistDB { get; set; }
        public Artist[] ArtistDB { get; set; }
        public Album[] AlbumDB { get; set; }
        public Director[] DirectorDB { get; set; }
        public Film[] FilmDB { get; set; }
        public UserListener User { get; set; }
        
    }
}
