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
        public int[] IdPlaylists { get; set; }
        //public int[] IdsFavouriteSongs { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int Rating { get; set; }

        public UserListenerDTO() { }
        public UserListenerDTO(UserListener userListener)
        { 
            Id= userListener.Id;
            Name= userListener.Name;
            IdPlaylists= userListener.IdPlaylists.Split('|').Select(s => int.Parse(s)).ToArray(); ;
            IsGold= userListener.IsGold;
            TimeSpan = userListener.TimeSpan;
            Rating = userListener.Rating;

        }
        public UserListenerDTO(string name, TimeSpan time) {
            Name = name;
            TimeSpan = time;
        }
    }
}
