
using System;
using System.Collections.Generic;
using System.IO;
using SpotiData;


namespace SpotiServ
{
    public class MusicService: IDataService
    {
        static MusicDbContext DbContext;
        static MusicService instance;
        MusicService()
        {
            DbContext = new MusicDbContext($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songs.csv");
        }

        public static MusicService GetInstance()
        {
            if (instance is null)
            {
                instance = new MusicService();
            }
            return instance;
        }
        public Song[] GetAllSongs()
        {
            return DbContext.Songs.ToArray(); 
        }
        public Artist[] GetAllArtists()
        {
            return DbContext.Artists.ToArray();
        }
        public Album[] GetAllAlbums()
        {
            return DbContext.Albums.ToArray();
        }
        public Playlist[] GetAllPlaylists()
        {
            return DbContext.Playlists.ToArray();
        }
    }
}
