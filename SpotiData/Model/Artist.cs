using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class Artist:Music, ICountable
    {
        public string Name { get; set; }
        public int[] IdAlbums { get; set; } = Array.Empty<int>();
        public string Genre { get; set; }
        
    }
}
