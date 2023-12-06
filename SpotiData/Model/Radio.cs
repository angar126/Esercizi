using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Radio :ICountable
    {
        
        public string Name { get; set; }
        public int Rating { get; set; }
        public Playlist OnAirPlaylist { get; set; }
        public Radio() { }
       
    }
}
