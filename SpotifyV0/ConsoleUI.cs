using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SpotifyV0.Interfaces;
using SpotifyV0.Model;
using static SpotifyV0.ConsoleUI;

namespace SpotifyV0
{
    class ConsoleUI
    {
        Song[] _songDB;
        Radio[] _radioDB;
        Artist[] _artistDB;
        Album[] _albumDB;
        Playlist[] _playlistDB;
        char[] _botton = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'L', 'R', 'E', 'H', 'Q' };
        char[] _numb = new char[0];
        Song _song;
        Song[] _songs;
        int n;
        Playlist _currentPlaylist;
        List<Song> _songsPlayed = new List<Song>();
        List<Song> _songsAdded = new List<Song>();
        UserListener _user;
        MediaPlayer _mediaPlayer;
        public ConsoleUI(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, UserListener User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
        }
        public ConsoleUI(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB,Director[] DirectorDB, Film[] FilmDB, UserListener User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
            _directorDB = DirectorDB;
            _filmDB = FilmDB;
        }
        //ConsoleUI(Song song)
        //{
        //    _song = song;
        //    Song[] _songs = new Song[] { song };
        //    _mediaPlayer = new MediaPlayer(_songs);
        //}
        //public MenuPlayer(IPlaylist IPlaylist)
        //{
        //    Song[]  _songs = IPlaylist.Songs;
        //    _mediaPlayer = new MediaPlayer(_songs);
        //    _song = _songs[_mediaPlayer.CurrentIndex];
        //}
        //public Song Song {  get { return _song; } set { _song = value; } }
        public void CreateMenuMusic()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                // Mostra il menu
                if (_song != null)
                {
                    ShowMenuMusic();
                    ShowList(_songs.Select(song => song.Title).ToArray());
                    ShowMenuOnlySong();
                }
                else ShowMenuMusic();

                // Ottieni l'input dell'utente
                userInput = GetValidInputSong();
                //Console.Clear();
                // Gestisci l'input dell'utente
                HandleInputSong(userInput, _mediaPlayer);
                //Console.Clear();
            }
        }
        void ShowMenuOnlySong()
        {
            ShowPlaying(_song);

            if (_currentPlaylist != null)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Add Song to last selected Playlist ({_currentPlaylist.Name}):Q ");
                Console.ResetColor();
                _songsPlayed.Add(_song);
            }
        }
        //void ShowList()
        //{
        //    for (int i = 0; i < _songs.Length; i++)
        //    {
        //        Console.WriteLine($"{i + 1}. {_songs[i].Title}");
        //    }
        //}
        void ShowList(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {strings[i]}");
            }
        }
        void TopMenu()
        {
            Console.Clear();
            Console.Write("            ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  MENU:M  ");
            Console.ResetColor();
            Console.Write("  ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("  PROFILE:C ");
            Console.ResetColor();
            Console.WriteLine();
        }
        void Button(string String, ConsoleColor BackgroundColor, ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Write(String);
            Console.ResetColor();
        }
        void MiddleMenuSong()
        {
            Button("Artist:A", ConsoleColor.Magenta, ConsoleColor.White);
            Console.Write(" ");
            Button("Albums:D", ConsoleColor.Red, ConsoleColor.White);
            Console.Write(" ");
            Button("Playlists:L", ConsoleColor.Green, ConsoleColor.Black);
            Console.Write(" ");
            Button("Radio:R", ConsoleColor.Yellow, ConsoleColor.Black);
            Console.Write(" ");
            Button("Exit:E", ConsoleColor.White, ConsoleColor.Black);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        void ShowMenuMusic()
        {
            TopMenu();
            MiddleMenuSong();
        }

        char GetValidInputSong()
        {
            char userInput;
            bool validInput = false;

            do
            {
                if (validInput)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong character, try again");
                    Console.ResetColor();
                    Thread.Sleep(200);
                    CreateMenuMusic();
                    //continue;
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                n = (int)Char.GetNumericValue(userInput);
                Console.WriteLine();

            } while (validInput = !(_botton.Contains(userInput) || _songs != null && _songs.Length != 0 && n > 0 && n <= _songs.Length));

            return userInput;
        }
        void ShowPlaying(IPlayable playable)
        {
            Console.WriteLine("--------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {playable.Title}");
            Console.ResetColor();
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
        }
        void HandleInputSong(char userInput, MediaPlayer Mediaplayer)
        {

            switch (userInput)
            {
                case 'F':
                    //Console.WriteLine("Next pressed.");
                    HandleNext(Mediaplayer);
                    break;
                case 'B':
                    //Console.WriteLine("Previous pressed.");
                    HandlePrevious(Mediaplayer);
                    break;
                case 'P':
                    //Console.WriteLine("Pause pressed.");
                    HandlePause(Mediaplayer);
                    break;
                case 'S':
                    //Console.WriteLine("Stop pressed.");
                    HandleStop(Mediaplayer);
                    break;
                case 'M':
                    HandleMusic(Mediaplayer);
                    break;
                case 'C':
                    HandleProfile();
                    break;
                case 'H':
                    //Console.WriteLine("Search.");
                    break;
                case 'A':
                    //Console.WriteLine("Artist.");
                    //DEVO FARE REFACTORING DI TUTTI QUESTI METODI QUASI UGUALI
                    HandleArtist();
                    break;
                case 'D':
                    //Console.WriteLine("Albums.");
                    HandleAlbum();
                    break;
                case 'L':
                    //Console.WriteLine("Playists.");
                    HandlePlaylist();
                    break;
                case 'R':
                    //Console.WriteLine("Radio.");
                    HandleRadio();
                    break;
                case 'Q':
                    HandleAddSongToPlaylist();
                    break;
                case var _ when char.IsDigit(userInput):
                    HandleSelectSong();
                    break;
                case 'E':
                    Exit();
                    break;
            }
        }
        private void Exit()
        {
            Console.WriteLine("Exiting the program.");
            try
            {

                DataStreamL<Song>.WriteonFile($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songsplayd.csv", _songsPlayed);
            }
            catch (Exception ex) { Console.WriteLine($"Error writing to songsadded.csv: {ex.Message}"); }
            try
            {
                DataStreamL<Song>.WriteonFile($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songsadded.csv", _songsAdded);
            }
            catch (Exception ex) { Console.WriteLine($"Error writing to songsadded.csv: {ex.Message}"); }
            //Environment.Exit(0);
        }
        static public class TopItemsProvider
        {
            static public T[] GetTopItems<T>(T[] array) where T : ICountable
            {
                return array.OrderByDescending(item => item.Count).Take(5).ToArray();
            }
        }
        //PROVA REFACTORING

        /*private void HandlerObj<T>(T[] categoryArray, Func<T, string> selector, ConsoleColor foregroundColor, ConsoleColor backgroundColor) where T : ICountable
        {
            {
                T[] items = categoryArray;
                string[] itemList = categoryArray.Select(selector)
                                        .Distinct()
                                        .ToArray();

                ShowMenu();
                int selectedItemIndex = MenuItems.CreateMenu(itemList, foregroundColor, backgroundColor);

                if (selectedItemIndex == -1)
                {
                    items = TopItemsProvider.GetTopItems(categoryArray);
                    itemList = items.Select(selector)
                                 .Distinct()
                                 .ToArray();

                    do
                    {
                        ShowMenu();
                        selectedItemIndex = MenuItems.CreateMenu(itemList, foregroundColor, backgroundColor);
                    } while (selectedItemIndex == -1);
                }

                Console.ResetColor();
                _songs = categoryArray.Where(item => selector(item) == itemList[selectedItemIndex]).ToArray();
                _mediaPlayer = new MediaPlayer(_songs);
                _song = _songs[_mediaPlayer.CurrentIndex];
                ShowMenuOnlySong();
            }
        }*/
        void HandleSelectSong()
        {
            _song = (Song)playItem(_songs[n - 1]);
        }
        void HandleAddSongToPlaylist()
        {
            if (_currentPlaylist != null)
            {
                _currentPlaylist.AddSong(_song);
                _songsAdded.Add(_song);
            }
        }
        void HandleArtist()
        {
            Artist[] ar = _artistDB;
            string[] artistList = _songDB.Select(song => song.Artist.Name)
                       .Distinct()
                       .ToArray();

            ShowMenuMusic();
            int chooseArtist = MenuItems.CreateMenu(artistList, ConsoleColor.Magenta, ConsoleColor.White);
            if (chooseArtist == -1)
            {
                ar = TopItemsProvider.GetTopItems(_artistDB);

                artistList = ar.Select(artist => artist.Name)
                       .Distinct()
                       .ToArray();

                do
                {
                    ShowMenuMusic();
                    chooseArtist = MenuItems.CreateMenu(artistList, ConsoleColor.Magenta, ConsoleColor.White);
                } while (chooseArtist == -1);
            }
            Console.ResetColor();
            _songs = _songDB.Where(song => song.Artist.Name == artistList[chooseArtist]).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandleAlbum()
        {
            Album[] al = _albumDB;
            string[] albumList = al.Select(album => album.Name)
                       .Distinct()
                       .ToArray();

            ShowMenuMusic();
            int chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
            if (chooseAlbums == -1)
            {
                al = TopItemsProvider.GetTopItems(_albumDB);
                //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                albumList = al.Select(album => album.Name)
                       .Distinct()
                       .ToArray();
                ShowMenuMusic();

                chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                do
                {
                    ShowMenuMusic();

                    chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                } while (chooseAlbums == -1);
            }
            Console.ResetColor();
            _songs = _songDB.Where(song => song.Album.Name == albumList[chooseAlbums]).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandlePlaylist()
        {
            Playlist[] pl = _playlistDB;
            string[] playList = pl.Select(playlist => playlist.Name)
                       .Distinct()
                       .ToArray();

            ShowMenuMusic();
            int choosePlaylist = MenuItems.CreateMenu(playList, ConsoleColor.Green, ConsoleColor.Black);
            if (choosePlaylist == -1)
            {
                pl = TopItemsProvider.GetTopItems(_playlistDB);
                //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                string[] playList2 = pl.Select(playlist => playlist.Name)
                       .Distinct()
                       .ToArray();
                ShowMenuMusic();

                choosePlaylist = MenuItems.CreateMenu(playList2, ConsoleColor.Green, ConsoleColor.Black);
                do
                {
                    ShowMenuMusic();

                    choosePlaylist = MenuItems.CreateMenu(playList2, ConsoleColor.Green, ConsoleColor.Black);
                } while (choosePlaylist == -1);

            }
            Console.ResetColor();
            _songs = pl[choosePlaylist].Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            _currentPlaylist = pl[choosePlaylist];
            ShowMenuOnlySong();
        }
        void HandleRadio()
        {
            //Console.WriteLine("Radio.");
            Radio[] rd = _radioDB;
            string[] playRadio = rd.Select(radio => radio.Name)
                       .Distinct()
                       .ToArray();

            ShowMenuMusic();
            int chooseRadio = MenuItems.CreateMenu(playRadio, ConsoleColor.Yellow, ConsoleColor.Black);
            if (chooseRadio == -1)
            {
                rd = TopItemsProvider.GetTopItems(_radioDB);
                //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                string[] playRadio2 = rd.Select(playlist => playlist.Name)
                       .Distinct()
                       .ToArray();
                ShowMenuMusic();

                chooseRadio = MenuItems.CreateMenu(playRadio2, ConsoleColor.Yellow, ConsoleColor.Black);
                do
                {
                    ShowMenuMusic();

                    chooseRadio = MenuItems.CreateMenu(playRadio2, ConsoleColor.Yellow, ConsoleColor.Black);
                } while (chooseRadio == -1);
            }
            Console.ResetColor();
            _songs = rd[chooseRadio].OnAirPlaylist.Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = _songs[_mediaPlayer.CurrentIndex];
            ShowMenuOnlySong();
        }
        IPlayable playItem(IPlayable play)
        {
            if (play is Song)
            {
                Song song= play as Song;
                if (_user.TimeSpan < TimeSpan.FromMilliseconds(0))
                {
                    Random random = new Random();
                    song = _songDB[random.Next(_songDB.Length)];
                }
                _user.TimeSpan = TimeSpan.FromMilliseconds(song.TimeMillis);
                play = (IPlayable) song;
            }
            //Logger.LogInfo($"User time span: {XmlConvert.ToString(_user.TimeSpan)}");
            return play;
        }
        void HandleNext(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    _song = (Song)playItem(Mediaplayer.Next());
                else _film = (Film)playItem(Mediaplayer.Next());
        }

        private void HandlePrevious(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    _song = (Song)playItem(Mediaplayer.Previous());
                else _film = (Film)playItem(Mediaplayer.Previous());
        }

        private void HandlePause(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    Mediaplayer.Pause();
        }

        private void HandleStop(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    Mediaplayer.Stop();
        }

        private void HandleMusic(MediaPlayer Mediaplayer)
        {
            CreateMenuMusic();
        }

        private void HandleProfile()
        {

        }



        //////////////////////////////////////////////FILM///////////////////////////////////////////

        Film[] _films;
        Film _film;
        Film[] _filmDB;
        Director[] _directorDB;
        char[] _bottonFilm = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'E' }; //'L', 'R', 'H', 'Q'

        void MiddleMenuFilm()
        {
            Button("Films:A", ConsoleColor.Magenta, ConsoleColor.White);
            Console.Write(" ");
            Button("Director:D", ConsoleColor.Red, ConsoleColor.White);
            Console.Write(" ");
            Button("Exit:E", ConsoleColor.White, ConsoleColor.Black);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        void ShowMenuFilm()
        {
            TopMenu();
            MiddleMenuFilm();
        }
        public void CreateMenuFilm()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_film != null)
                {
                    ShowMenuFilm();
                    ShowList(_films.Select(film => film.Title).ToArray());
                    ShowPlaying(_film);
                }
                else ShowMenuFilm();

                userInput = GetValidInputFilm();

                HandleInputVideo(userInput, _mediaPlayer);

            }
        }
        char GetValidInputFilm()
        {
            char userInput;
            bool validInput = false;

            do
            {
                if (validInput)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong character, try again");
                    Console.ResetColor();
                    Thread.Sleep(200);
                    CreateMenuFilm();
                    //continue;
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                n = (int)Char.GetNumericValue(userInput);
                Console.WriteLine();

            } while (validInput = !(_bottonFilm.Contains(userInput) || _films != null && _films.Length != 0 && n > 0 && n <= _films.Length));

            return userInput;
        }
        void HandleInputVideo(char userInput, MediaPlayer Mediaplayer)
        {

            switch (userInput)
            {
                case 'F':
                    HandleNext(Mediaplayer);
                    break;
                case 'B':
                    HandlePrevious(Mediaplayer);
                    break;
                case 'P':
                    HandlePause(Mediaplayer);
                    break;
                case 'S':
                    HandleStop(Mediaplayer);
                    break;
                case 'M':
                    HandleMusic(Mediaplayer);
                    break;
                case 'C':
                    HandleProfile();
                    break;
                //case 'H':
                //    //Console.WriteLine("Search.");
                //    break;
                case 'A':
                    //Console.WriteLine("Artist.");
                    HandleFilms();
                    break;
                case 'D':
                    //Console.WriteLine("Albums.");
                    HandleDirector();
                    break;
                //case 'L':
                //    //Console.WriteLine("Playists.");
                //    //HandlePlaylist();
                //    break;
                //case 'R':
                //    //Console.WriteLine("Radio.");
                //   //HandleRadio();
                //    break;
                //case 'Q':
                //    //HandleAddSongToPlaylist();
                //    break;
                case var _ when char.IsDigit(userInput):
                    _film = _films[n - 1];
                    break;
                case 'E':
                    Exit();
                    break;
            }
        }
        void HandleFilms()
        {
            //Console.WriteLine("Radio.");
            Film[] fl = _filmDB;
            string[] play = fl.Select(film => film.Title)
                       .Distinct()
                       .ToArray();

            ShowMenuFilm();
            int choose = MenuItems.CreateMenu(play, ConsoleColor.Magenta, ConsoleColor.White);
            if (choose == -1)
            {
                fl = TopItemsProvider.GetTopItems(_filmDB);
                //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                string[] play2 = fl.Select(playlist => playlist.Title)
                       .Distinct()
                       .ToArray();
                ShowMenuFilm();

                choose = MenuItems.CreateMenu(play2, ConsoleColor.Magenta, ConsoleColor.White);
                do
                {
                    ShowMenuFilm();

                    choose = MenuItems.CreateMenu(play2, ConsoleColor.Magenta, ConsoleColor.White);
                } while (choose == -1);
            }
            Console.ResetColor();
            _films = fl;
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            ShowPlaying(_film);
        }

        void HandleDirector()
        {
            
            Director[] dr = _directorDB;
            string[] play1 = dr.Select(director => director.Name)
                       .Distinct()
                       .ToArray();

            ShowMenuFilm();
            int choose = MenuItems.CreateMenu(play1, ConsoleColor.Red, ConsoleColor.White);
            if (choose == -1)
            {
                dr = TopItemsProvider.GetTopItems(_directorDB);
                

                string[] play2 = dr.Select(director => director.Name)
                       .Distinct()
                       .ToArray();
                ShowMenuFilm();

                choose = MenuItems.CreateMenu(play2, ConsoleColor.Red, ConsoleColor.White);
                do
                {
                    ShowMenuFilm();

                    choose = MenuItems.CreateMenu(play2, ConsoleColor.Red, ConsoleColor.White);
                } while (choose == -1);
            }
            Console.ResetColor();
            _films = _filmDB.Where(film => film.Director.Equals(dr[choose])).ToArray();
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            ShowPlaying(_film);
        }
    }
}
