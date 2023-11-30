using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiModel
{
    public interface IPlaylist : ICountable
    {
        string Name { get; set; }
        Song[] Songs { get; set; }
    }
}
