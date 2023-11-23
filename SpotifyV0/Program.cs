using System;

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


            Playlist playlist1 = new Playlist("PLAYLIST1", songDB);
            Playlist playlist2 = new Playlist("PLAYLIST2", songDB);
            Playlist playlist3 = new Playlist("PLAYLIST3", songDB);

            Playlist[] playlistDB =new Playlist[] {playlist1, playlist2, playlist3};


            Radio radio1 = new Radio("RADIO1", playlist1);
            Radio radio2 = new Radio("RADIO2", playlist1);
            Radio radio3 = new Radio("RADIO3", playlist1);

            Radio[] radioDB = new Radio[] { radio1 , radio2 , radio3};


            ConsoleUI m = new ConsoleUI(songDB,radioDB,playlistDB);

            m.CreateMenuSong();


        }
    }
}
