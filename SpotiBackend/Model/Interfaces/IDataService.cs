using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackend
{
    public interface IDataService
    {
        Song[] GetAllSongs();
        Playlist[] GetAllPlaylists();
        Artist[] GetAllArtists();
        Album[] GetAllAlbums();
    }
}
