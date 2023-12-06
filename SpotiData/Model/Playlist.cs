using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Playlist:ICountable
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Song[] Songs { get; set; } = Array.Empty<Song>();
        public int PlaylistId { get; set; }
       
    }
}
