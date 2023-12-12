using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public interface IPlaylist : ICountable
    {
        string Name { get; set; }
        string Songs { get; set; }
    }
}
