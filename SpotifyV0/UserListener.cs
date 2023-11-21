using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyV0
{
    class UserListener: User
    {
        Playlist _favouriteSongs;
        bool _isPremium;
        Radio[] _radioFavourites;
        Playlist[] _playlists;

        public Playlist FavouriteSongs { get{return _favouriteSongs ;} }
        public Radio[] RadioFavourites { get { return _radioFavourites ;} }
        public bool IsPremium { get { return _isPremium ;} set { _isPremium = value ; } }
        public UserListener(string Name):base(Name)
        {
            _isPremium = false;
            _playlists = new Playlist[0];
            _radioFavourites = new Radio[0];
            _favouriteSongs = new Playlist();
        }
        public void AddPlaylist(Playlist playlist)
        {
            _playlists = _playlists.Append(playlist).ToArray();
        }
        public void RemovePlaylist(Playlist playlist)
        {
           _playlists =  _playlists.Where(i=> i!= playlist ).ToArray() ;
          
        }
        public void AddFavouriteSong(Song song)
        {
            _favouriteSongs.AddSong(song) ;
        }
        public void RemoveFavouriteSong(Song song)
        {
            _favouriteSongs.RemoveSong(song);
        }
        public void AddFavouriteRadio(Radio radio)
        {
            _radioFavourites = _radioFavourites.Append(radio).ToArray();
        }
        public void RemoveFavouriteRadio(Radio radio)
        {
            _radioFavourites = _radioFavourites.Where(i => i != radio).ToArray();
        }

    }
}
