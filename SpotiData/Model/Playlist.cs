using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Playlist:Music, ICountable
    {
        public string Name { get; set; }
        public int[] IdSongs { get; set; } = Array.Empty<int>();
        public int PlaylistId { get; set; }
       
    }
}
