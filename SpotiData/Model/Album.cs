using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class Album:Music, ICountable
    {
        public string Name { get; set; }

        public int[] IdSongs { get; set; } = Array.Empty<int>();
        public int IdArtist { get; set; }
        public string Genre { get; set; }
       
    }
}
