using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class SpotifyDbContext : DbContext
    {
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Playlist> Playlists { get; set; }
        //public List<Radio> Radios { get; set; }
        //public List<UserListener> UserListeners { get; set; }
        

        public SpotifyDbContext(string Path): base(Path) {

            Songs= ReadFromCsv<Song>(Path + typeof(Song).Name.ToString() + ".csv");
            //Artists = ReadFromCsv<Artist>(Path + typeof(Artist).Name.ToString() + ".csv");
            //Albums = ReadFromCsv<Album>(Path + typeof(Album).Name.ToString() + ".csv");
            //Playlists = ReadFromCsv<Playlist>(Path + typeof(Playlist).Name.ToString() + ".csv");
            //Radios = ReadFromCsv<Radio>(Path + typeof(Radio).Name.ToString() + ".csv");
            //UserListeners = ReadFromCsv<UserListener>(Path + typeof(UserListener).Name.ToString() + ".csv");
            MergerData();
        }
        private void MergerData()
        {
            //foreach (var artist in Artists)
            //{
            //    Album[] albums = Albums.Where(a => a.Artist == artist).ToArray();

            //    artist.Albums = albums;
            //}
            //foreach (var album in Albums)
            //{
            //    Song[] songs = Songs.Where(s => s.Album == album).ToArray();

            //    album.Songs = songs;
            //}
            //foreach (var playlist in Playlists)
            //{
            //    Song[] songs = Songs.Where(i => i.PlaylistId == playlist.PlaylistId).ToArray();

            //    playlist.Songs = songs;
            //}
            
        }
    }
}
