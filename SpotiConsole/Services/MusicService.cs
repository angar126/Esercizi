
using System;
using System.Collections.Generic;
using System.IO;
using SpotiBackend;


namespace SpotiControl.Services
{
    public class MusicService
    {
        static MusicDbContext DbContext;
        static MusicService instance;
        MusicService()
        {
            DbContext = new MusicDbContext($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}sonfgs.csv");
        }

        public static MusicService GetInstance()
        {
            if (instance is null)
            {
                instance = new MusicService();
            }
            return instance;
        }
        public List<Song> GetAllSongs()
        {
            return DbContext.Songs;
        }
        public List<Artist> GetAllArtists()
        {
            return DbContext.Artists;
        }
        public List<Album> GetAllAlbums()
        {
            return DbContext.Albums;
        }
        public List<Playlist> GetAllPlaylists()
        {
            return DbContext.Playlists;
        }
    }
}
