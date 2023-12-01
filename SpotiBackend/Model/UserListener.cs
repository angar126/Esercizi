using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiBackend
{
    public class UserListener : User
    {
        Playlist[] Playlists { get; set; }
        public Playlist FavouriteSongs { get; set; }
        public Radio[] RadioFavourites { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }
        
    }
}
