using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiData
{
    public class UserListenerDTO: UserDTO, ICountable
    {
        public int[] IdsPlaylists { get; set; }
        //public int[] IdsFavouriteSongs { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Rating { get; set; }

    }
}
