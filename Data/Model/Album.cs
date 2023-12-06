using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public class Album
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public Song[] Songs { get; set; } = Array.Empty<Song>();
        public Artist Artist { get; set; }
        public string Genre { get; set; }
    }
}
