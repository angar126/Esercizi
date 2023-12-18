using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiData
{
    public interface IDataService
    {
        Song[] GetAllSongs();
        Playlist[] GetAllPlaylists();
        Artist[] GetAllArtists();
        Album[] GetAllAlbums();
    }
}
