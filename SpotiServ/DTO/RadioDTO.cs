using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpotiData;

namespace SpotiServ
{
    public class RadioDTO: Music, ICountable
    { 
        public string Name { get; set; }
        public int IdOnAirPlaylistDTO { get; set; }
        public RadioDTO() { }
        public RadioDTO(Radio radio) {
            Id = radio.Id;
            Rating = radio.Rating;
            Name = radio.Name;
            IdOnAirPlaylistDTO = radio.IdOnAirPlaylist;
        }
    }
}
