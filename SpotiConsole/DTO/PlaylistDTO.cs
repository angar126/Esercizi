using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl.DTO
{
    public class PlaylistDTO:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public SongDTO[] Songs { get; set; }
        public int PlaylistId { get; set; }
        public PlaylistDTO() { }
        public PlaylistDTO(string Name)
        {
            Name = Name;
            Rating = 0;
        }
        public PlaylistDTO(string Name, SongDTO[] Songs)
        {
            Name = Name;
            Songs = Songs;
            Rating = 0;
        }
        public PlaylistDTO(string Name, SongDTO[] Songs, int Count)
        {
            Name = Name;
            Songs = Songs;
            Rating = Count;
        }
        public void AddSong(SongDTO song)
        {
            if (!Songs.Contains(song))
                Songs = Songs.Append(song).ToArray();
        }
        public void RemoveSong(SongDTO song)
        {
            Songs = Songs.Where(i => i != song).ToArray();

        }
    }
}
