using SpotiControl.DTO;
using System;
using System.Collections.Generic;


namespace SpotiControl
{
    public class SongService
    {
        static SpotifyDbContext DbContext;
        static SongService instance;
        SongService()
        {
            DbContext = new SpotifyDbContext(@"D:\logs\");
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
