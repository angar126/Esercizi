using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    public interface IPlaylist : ICountable
    {
        string Name { get; set; }
        Song[] Songs { get; set; }
    }
}
