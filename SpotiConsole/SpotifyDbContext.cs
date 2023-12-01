using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiControl.DTO;

namespace SpotiControl
{
    public class SpotifyDbContext : DbContext
    {
        public List<SongDTO> Songs { get; set; }
        public List<ArtistDTO> Artists { get; set; }
        public List<AlbumDTO> Albums { get; set; }
        public List<PlaylistDTO> Playlists { get; set; }
        public List<RadioDTO> Radios { get; set; }
        public List<UserListenerDTO> UserListeners { get; set; }
        

        public SpotifyDbContext(string Path): base(Path) {

            Songs= ReadFromCsv<SongDTO>(Path + typeof(SongDTO).Name.ToString() + ".csv");
            Artists = ReadFromCsv<ArtistDTO>(Path + typeof(ArtistDTO).Name.ToString() + ".csv");
            Albums = ReadFromCsv<AlbumDTO>(Path + typeof(AlbumDTO).Name.ToString() + ".csv");
            Playlists = ReadFromCsv<PlaylistDTO>(Path + typeof(PlaylistDTO).Name.ToString() + ".csv");
            Radios = ReadFromCsv<RadioDTO>(Path + typeof(RadioDTO).Name.ToString() + ".csv");
            UserListeners = ReadFromCsv<UserListenerDTO>(Path + typeof(UserListenerDTO).Name.ToString() + ".csv");
            MergerData();
        }
        private void MergerData()
        {
            foreach (var artist in Artists)
            {
                AlbumDTO[] albums = Albums.Where(a => a.Artist == artist).ToArray();

                artist.Albums = albums;
            }
            foreach (var album in Albums)
            {
                SongDTO[] songsArr = Songs.Where(s => s.Album == album).ToArray();

                album.Songs = songsArr;
            }
            foreach (var playlist in Playlists)
            {
                SongDTO[] songs = Songs.Where(i => i.PlaylistId == playlist.PlaylistId).ToArray();

                playlist.Songs = songs;
            }
            
        }
    }
}
