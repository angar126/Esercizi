using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public class Album : IPlaylist
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Song[] Songs { get; set; }
        public Artist Artist { get; set; }
        public string Genre { get; set; }
    }
}
