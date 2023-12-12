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
        public string IdSongs { get; set; }
        public int PlaylistId { get; set; }
       
    }
}
