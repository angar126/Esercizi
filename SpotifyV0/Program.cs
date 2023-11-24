using System;
using SpotifyV0.Model;

namespace SpotifyV0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Artist artist1 = new Artist("Artista1");
            Artist artist2 = new Artist("Artista2");

            Album album11 = new Album("Album1", artist1);
            Album album12 = new Album("Album2", artist1);
            Album album21 = new Album("AlbumA", artist2);
            Album album22 = new Album("AlbumB", artist2);

            Song song111 = new Song("TITOLO11", artist1, album11, 10000);
            Song song112 = new Song("TITOLO12", artist1, album11, 10000);
            Song song121 = new Song("TITOLO21", artist1, album12, 10000);
            Song song122 = new Song("TITOLO22", artist1, album12, 10000);

            Song song211 = new Song("TITOLO11", artist2, album21, 10000);
            Song song212 = new Song("TITOLO12", artist2, album21, 10000);
            Song song221 = new Song("TITOLO21", artist2, album22, 10000);
            Song song222 = new Song("TITOLO22", artist2, album22, 10000);

            Song[] songDB = new Song[] {song111, song112, song121 , song122 , song211 , song212 , song221 , song222 };


            Playlist playlist1 = new Playlist("PLAYLIST1", songDB,1);
            Playlist playlist2 = new Playlist("PLAYLIST2", songDB,3);
            Playlist playlist3 = new Playlist("PLAYLIST3", songDB,2);

            Playlist[] playlistDB =new Playlist[] {playlist1, playlist2, playlist3};


            Radio radio1 = new Radio("RADIO1", playlist1,2);
            Radio radio2 = new Radio("RADIO2", playlist1,1);
            Radio radio3 = new Radio("RADIO3", playlist1,3);

            Radio[] radioDB = new Radio[] { radio1 , radio2 , radio3};
            Artist[] artistDB=new Artist[] { artist1, artist2 };
            Album[] albumDB = new Album[] {album11, album12, album21, album22};

            ConsoleUI c = new ConsoleUI(songDB,radioDB,playlistDB,artistDB,albumDB);
            //MenuMediaSource.CreateMenu(c);
            c.CreateMenuMusic();


        }
    }
}
