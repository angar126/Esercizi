using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PlaylistDTO
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public SongDTO[] SongsDTO { get; set; } = Array.Empty<SongDTO>();
        public int PlaylistIdDTO { get; set; }
    }
}
