using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class UserListener : User
    {
        public string IdPlaylists { get; set; }
        public int FavouriteSongs { get; set; }
        public string RadioFavourites { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }

    }
}
