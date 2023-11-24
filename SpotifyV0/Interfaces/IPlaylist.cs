using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Model;

namespace SpotifyV0.Interfaces
{
    internal interface IPlaylist : ICountable
    {
        string Name { get; set; }
        Song[] Songs { get; set; }
    }
}
