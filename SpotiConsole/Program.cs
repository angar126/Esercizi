using System;
using System.Diagnostics;
using System.Xml;
using SpotiUtil;
using SpotiControl.DTO;


namespace SpotiControl
{
    class Program
    {
        static void Main(string[] args)
        {

            ArtistDTO artist1 = new ArtistDTO("Artista1");
            ArtistDTO artist2 = new ArtistDTO("Artista2");

            AlbumDTO album11 = new AlbumDTO("Album1", artist1);
            AlbumDTO album12 = new AlbumDTO("Album2", artist1);
            AlbumDTO album21 = new AlbumDTO("AlbumA", artist2);
            AlbumDTO album22 = new AlbumDTO("AlbumB", artist2);

            SongDTO song111 = new SongDTO("TITOLO11", artist1, album11, 100000);
            SongDTO song112 = new SongDTO("TITOLO12", artist1, album11, 100000);
            SongDTO song121 = new SongDTO("TITOLO21", artist1, album12, 100000);
            SongDTO song122 = new SongDTO("TITOLO22", artist1, album12, 100000);

            SongDTO song211 = new SongDTO("TITOLO11", artist2, album21, 100000);
            SongDTO song212 = new SongDTO("TITOLO12", artist2, album21, 100000);
            SongDTO song221 = new SongDTO("TITOLO21", artist2, album22, 100000);
            SongDTO song222 = new SongDTO("TITOLO22", artist2, album22, 100000);

            SongDTO[] songDB = new SongDTO[] { song111, song112, song121, song122, song211, song212, song221, song222 };


            PlaylistDTO playlist1 = new PlaylistDTO("PLAYLIST1", songDB, 1);
            PlaylistDTO playlist2 = new PlaylistDTO("PLAYLIST2", songDB, 3);
            PlaylistDTO playlist3 = new PlaylistDTO("PLAYLIST3", songDB, 2);

            PlaylistDTO[] playlistDB = new PlaylistDTO[] { playlist1, playlist2, playlist3 };


            RadioDTO radio1 = new RadioDTO("RADIO1", playlist1, 2);
            RadioDTO radio2 = new RadioDTO("RADIO2", playlist1, 1);
            RadioDTO radio3 = new RadioDTO("RADIO3", playlist1, 3);

            RadioDTO[] radioDB = new RadioDTO[] { radio1, radio2, radio3 };
            ArtistDTO[] artistDB = new ArtistDTO[] { artist1, artist2 };
            AlbumDTO[] albumDB = new AlbumDTO[] { album11, album12, album21, album22 };

            DirectorDTO director1 = new DirectorDTO("Director1");
            DirectorDTO director2 = new DirectorDTO("Director2");

            FilmDTO film1 = new FilmDTO("Film1", director1);
            FilmDTO film2 = new FilmDTO("Film2", director1);
            FilmDTO film3 = new FilmDTO("Film3", director2);
            FilmDTO film4 = new FilmDTO("Film4", director2);

            FilmDTO[] filmDB = new FilmDTO[] { film1, film2, film3, film4 };
            DirectorDTO[] directorDB = new DirectorDTO[] { director1, director2};
            //Se è free o premium gli carico le ore inerenti al suo abbonamento 
            //non mi sembra sia necessario aggiungere una classe o una struttura 

            TimeSpan timespan = TimeSpan.FromMinutes(5);

            UserListenerDTO user = new UserListenerDTO("User",timespan);
            
            Control c = new Control(songDB, radioDB, playlistDB, artistDB, albumDB, directorDB, filmDB,user);
            
            try
            {
                MenuLogin.CreateMenu(c);
                
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
