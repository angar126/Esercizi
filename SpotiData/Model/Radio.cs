using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public class Radio :Music, ICountable
    {
        
        public string Name { get; set; }
        public int OnAirPlaylist { get; set; }
        public Radio() { }
       
    }
}
