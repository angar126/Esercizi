using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class DataService
    {
        static MusicDbContext DbContext;
        static DataService instance;
        DataService()
        {
            DbContext = new MusicDbContext($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songs2.csv");
        }

        public static DataService GetInstance()
        {
            if (instance is null)
            {
                instance = new DataService();
            }
            return instance;
        }
        public MusicDto[] GetAllDTOSongs(Song[] songs, Playlist[] playlists)
        {
            List<MusicDto> musics = new List<MusicDto>();
            foreach (Song song in songs)
            {
                MusicDto m = new MusicDto();
                m.Id = song.Id;
                m.Rating = song.Rating;
                m.Title = song.Title;
                m.Album = song.Album.Name;
                m.Artist = song.Artist.Name;
                m.Genre = song.Genre;
                m.PlaylistId = song.PlaylistId;
                m.Playlist = playlists.First(p => p.PlaylistId == song.PlaylistId).Name;

                musics.Add( m );
            }
            return musics.ToArray();
        }
    }
}
