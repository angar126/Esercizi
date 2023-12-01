using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl.DTO
{
    public interface IPlaylist : ICountable
    {
        string Name { get; set; }
        SongDTO[] Songs { get; set; }
    }
}
