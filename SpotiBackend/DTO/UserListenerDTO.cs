using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public class UserListenerDTO
    {
        PlaylistDTO[] Playlists { get; set; }
        public PlaylistDTO FavouriteSongs { get; set; }
        public RadioDTO[] RadioFavourites { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }

    }
}
