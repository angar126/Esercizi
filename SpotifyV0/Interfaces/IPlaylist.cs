using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Model;

namespace SpotifyV0.Interfaces
{
    internal interface IPlaylist
    {
        string Name { get; set; }
        Song[] Songs { get; set; }
    }
}
