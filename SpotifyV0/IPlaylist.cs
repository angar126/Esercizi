using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    internal interface IPlaylist
    {
        string Name { get; set; }
        Song[] Songs { get; set; }
    }
}
