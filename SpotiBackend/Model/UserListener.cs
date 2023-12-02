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
        public UserListener() { }
        public UserListener(string Name, TimeSpan Time) : base(Name)
        {
            IsGold = false;
            Playlists = new Playlist[0];
            RadioFavourites = new Radio[0];
            FavouriteSongs = new Playlist();
            TimeSpan = Time;
        }
        public void AddPlaylist(Playlist playlist)
        {
            Playlists = Playlists.Append(playlist).ToArray();
        }
        public void RemovePlaylist(Playlist playlist)
        {
            Playlists = Playlists.Where(i => i != playlist).ToArray();

        }
        public void AddFavouriteSong(Song song)
        {
            FavouriteSongs.AddSong(song);
        }
        public void RemoveFavouriteSong(Song song)
        {
            FavouriteSongs.RemoveSong(song);
        }
        public void AddFavouriteRadio(Radio radio)
        {
            RadioFavourites = RadioFavourites.Append(radio).ToArray();
        }
        public void RemoveFavouriteRadio(Radio radio)
        {
            RadioFavourites = RadioFavourites.Where(i => i != radio).ToArray();
        }

    }
}
