using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class PlaylistDTO: ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public SongDTO[] SongsDTO { get; set; } = Array.Empty<SongDTO>();
        public int PlaylistIdDTO { get; set; }
        public void AddSong(SongDTO song)
        {
            if (!SongsDTO.Contains(song))
                SongsDTO = SongsDTO.Append(song).ToArray();
        }
    }
}
