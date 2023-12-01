using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl.DTO
{
    public class RadioDTO :ICountable
    {
        
        public string Name { get; set; }
        public int Rating { get; set; }
        public PlaylistDTO OnAirPlaylist { get; set; }
        public RadioDTO() { }
        public RadioDTO(string name)
        {
            Name = name;
        }
        public RadioDTO(string name, PlaylistDTO Playlist)
        {
            Name = name;
            OnAirPlaylist = Playlist;
        }
        public RadioDTO(string name, PlaylistDTO Playlist, int rating)
        {
            Name = name;
            OnAirPlaylist = Playlist;
            Rating = rating;
        }
    }
}
