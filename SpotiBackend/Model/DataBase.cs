using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
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
        public DataBase(Song[] songDB, Radio[] radioDB, Playlist[] playlistDB, Artist[] artistDB, Album[] albumDB, Director[] directorDB, Film[] filmDB, UserListener user)
        {
            SongDB = songDB;
            RadioDB = radioDB;
            PlaylistDB = playlistDB;
            ArtistDB = artistDB;
            AlbumDB = albumDB;
            User = user;
            DirectorDB = directorDB;
            FilmDB = filmDB;
        }
    }
}
