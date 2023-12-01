using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotiControl.DTO
{
    public class UserListenerDTO : UserDTO
    {
        PlaylistDTO[] Playlists { get; set; }
        public PlaylistDTO FavouriteSongs { get; set; }
        public RadioDTO[] RadioFavourites { get; set; }
        public bool IsGold { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public UserListenerDTO() { }
        public UserListenerDTO(string Name, TimeSpan Time) : base(Name)
        {
            IsGold = false;
            Playlists = new PlaylistDTO[0];
            RadioFavourites = new RadioDTO[0];
            FavouriteSongs = new PlaylistDTO();
            TimeSpan = Time;
        }
        public void AddPlaylist(PlaylistDTO playlist)
        {
            Playlists = Playlists.Append(playlist).ToArray();
        }
        public void RemovePlaylist(PlaylistDTO playlist)
        {
            Playlists = Playlists.Where(i => i != playlist).ToArray();

        }
        public void AddFavouriteSong(SongDTO song)
        {
            FavouriteSongs.AddSong(song);
        }
        public void RemoveFavouriteSong(SongDTO song)
        {
            FavouriteSongs.RemoveSong(song);
        }
        public void AddFavouriteRadio(RadioDTO radio)
        {
            RadioFavourites = RadioFavourites.Append(radio).ToArray();
        }
        public void RemoveFavouriteRadio(RadioDTO radio)
        {
            RadioFavourites = RadioFavourites.Where(i => i != radio).ToArray();
        }

    }
}
