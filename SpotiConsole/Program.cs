using System;
using System.Diagnostics;
using System.Xml;
using SpotiUtil;
using SpotiBackend;
using SpotiControl.Services;
using System.IO;
using SpotiBackend;

namespace SpotiControl
{
    class Program
    {
        static void Main(string[] args)
        {
            ////////RIGHE PER PROVARE FUNZIONALITA'///////
            Console.WriteLine($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songs.csv");
            Artist artist1 = new Artist("Artista1");
            Artist artist2 = new Artist("Artista2");

            Album album11 = new Album("Album1", artist1);
            Album album12 = new Album("Album2", artist1);
            Album album21 = new Album("AlbumA", artist2);
            Album album22 = new Album("AlbumB", artist2);

            Song song111 = new Song("TITOLO11", artist1, album11, 100000);
            Song song112 = new Song("TITOLO12", artist1, album11, 100000);
            Song song121 = new Song("TITOLO21", artist1, album12, 100000);
            Song song122 = new Song("TITOLO22", artist1, album12, 100000);

            Song song211 = new Song("TITOLO11", artist2, album21, 100000);
            Song song212 = new Song("TITOLO12", artist2, album21, 100000);
            Song song221 = new Song("TITOLO21", artist2, album22, 100000);
            Song song222 = new Song("TITOLO22", artist2, album22, 100000);

            Song[] songDB = new Song[] { song111, song112, song121, song122, song211, song212, song221, song222 };


            Playlist playlist1 = new Playlist("PLAYLIST1", songDB, 1);
            Playlist playlist2 = new Playlist("PLAYLIST2", songDB, 3);
            Playlist playlist3 = new Playlist("PLAYLIST3", songDB, 2);

            Playlist[] playlistDB = new Playlist[] { playlist1, playlist2, playlist3 };


            Radio radio1 = new Radio("RADIO1", playlist1, 2);
            Radio radio2 = new Radio("RADIO2", playlist1, 1);
            Radio radio3 = new Radio("RADIO3", playlist1, 3);

            Radio[] radioDB = new Radio[] { radio1, radio2, radio3 };
            Artist[] artistDB = new Artist[] { artist1, artist2 };
            Album[] albumDB = new Album[] { album11, album12, album21, album22 };

            Director director1 = new Director("Director1");
            Director director2 = new Director("Director2");

            Film film1 = new Film("Film1", director1);
            Film film2 = new Film("Film2", director1);
            Film film3 = new Film("Film3", director2);
            Film film4 = new Film("Film4", director2);

            Film[] filmDB = new Film[] { film1, film2, film3, film4 };
            Director[] directorDB = new Director[] { director1, director2};
            //Se è free o premium gli carico le ore inerenti al suo abbonamento 
            //non mi sembra sia necessario aggiungere una classe o una struttura 

            TimeSpan timespan = TimeSpan.FromMinutes(5);

            UserListener user = new UserListener("User",timespan);


            MusicService m = MusicService.GetInstance();

            songDB = m.GetAllSongs().ToArray();
            playlistDB=m.GetAllPlaylists().ToArray();
            artistDB=m.GetAllArtists().ToArray();
            albumDB=m.GetAllAlbums().ToArray();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            try
            {
                DataBase b = new DataBase(songDB, radioDB, playlistDB, artistDB, albumDB, directorDB, filmDB, user);
                //ControlMusic c = new ControlMusic(songDB, radioDB, playlistDB, artistDB, albumDB, directorDB, filmDB, user);
                MenuLeng.CreateMenu(b);
                
                //c.CreateMenuMusic();
            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
            }
            finally
            { 
                //posso metterlo sia qua che quando faccio il play della canzone...
                Logger.LogInfo($"User time span: {XmlConvert.ToString(user.TimeSpan)}");
                Logger.CloseLog();
            }
            
            Console.ReadLine();

        }
    }
}
