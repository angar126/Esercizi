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
        public string IdSongs { get; set; }
        public int IdArtist { get; set; }
        public string Genre { get; set; }
       
    }
}
