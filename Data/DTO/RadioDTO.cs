using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RadioDTO
    {
        
        public string Name { get; set; }
        public int Rating { get; set; }
        public PlaylistDTO OnAirPlaylistDTO { get; set; }
        
    }
}
