using SpotiControl.DTO;
using System;
using System.Collections.Generic;
using System.IO;


namespace SpotiControl
{
    public class SongService
    {
        static SpotifyDbContext DbContext;
        static SongService instance;
        SongService()
        {
            DbContext = new SpotifyDbContext($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songs.csv");
        }

        public static SongService GetInstance()
        {
            if (instance is null)
            {
                instance = new SongService();
            }
            return instance;
        }
        public List<SongDTO> GetAllSongs()
        {
            return DbContext.Songs;
        }
    }
}
