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
        char _typeMenu;
        bool _timeOver = false;


        int n;
        Playlist _currentPlaylist;
        List<Song> _songsPlayed = new List<Song>();
        List<Song> _songsAdded = new List<Song>();
        UserListener _user;
        MediaPlayer _mediaPlayer;
        public char TypeMenu { get { return _typeMenu; } set { _typeMenu = value; } }
        public ConsoleUI(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, UserListener User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
            _typeMenu = 'M';
            _timeOver = User.TimeSpan < TimeSpan.Zero;
        }

        public ConsoleUI(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, Director[] DirectorDB, Film[] FilmDB, UserListener User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
            _timeOver = User.TimeSpan < TimeSpan.Zero;
            _directorDB = DirectorDB;
            _filmDB = FilmDB;
        }

        public void CreateMenuMusic()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_song != null)
                {
                    ShowMenuMusic();
                    ShowList(_songs.Select(song => song.Title).ToArray());
                    ShowMenuOnlySong();
                }
                else ShowMenuMusic();
                userInput = GetValidInputSong();
                HandleInputSong(userInput, _mediaPlayer);
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
                    ErrorMsgMenu();
                }
                userInput = UserInput();
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
            if (_timeOver)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Time is Over!");
                Console.ResetColor();
            }
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
            int choose = chooseObj<Artist>(ar, artist => artist.Name, ConsoleColor.Magenta, ConsoleColor.White);
            _songs = _songDB.Where(song => song.Artist.Name == ar[choose].Name).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandleAlbum()
        {
            Album[] al = _albumDB;
            int choose = chooseObj<Album>(al, album => album.Name, ConsoleColor.Red, ConsoleColor.White);
            _songs = _songDB.Where(song => song.Album.Name == al[choose].Name).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandlePlaylist()
        {
            Playlist[] pl = _playlistDB;
            int choose = chooseObj<Playlist>(pl, playlist => playlist.Name, ConsoleColor.Green, ConsoleColor.Black);
            _songs = pl[choose].Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            _currentPlaylist = pl[choose];
            ShowMenuOnlySong();
        }
        void HandleRadio()
        {
            Radio[] rd = _radioDB;
            int choose = chooseObj<Radio>(rd, radio => radio.Name, ConsoleColor.Yellow, ConsoleColor.Black);
            _songs = rd[choose].OnAirPlaylist.Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = _songs[_mediaPlayer.CurrentIndex];
            ShowMenuOnlySong();
        }
        IPlayable playItem(IPlayable play)
        {
            if (play is Song)
            {
                Song song = play as Song;
                if (_timeOver||_user.TimeSpan < TimeSpan.Zero)
                {
                    Random random = new Random();
                    song = _songDB[random.Next(_songDB.Length)];
                    _timeOver = true;
                }
                _user.TimeSpan = TimeSpan.FromMilliseconds(song.TimeMillis);
                play = (IPlayable)song;
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

        private void HandleProfile() { }

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
                    ErrorMsgMenu();
                }
                userInput = UserInput();
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
                    HandleFilms();
                    break;
                case 'C':
                    HandleProfile();
                    break;
                case 'A':
                    HandleFilms();
                    break;
                case 'D':
                    HandleDirector();

                    break;
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
            Film[] fl = _filmDB;
            int choose = chooseObj<Film>(fl, film => film.Title, ConsoleColor.Magenta, ConsoleColor.White);
            _films = fl;
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            ShowPlaying(_film);
        }
        int chooseItem<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            string[] play1 = list.Select(selector)
                       .Distinct()
                       .ToArray();
            ShowMenu();
            return MenuItems.CreateMenu(play1, backgroundColor, foregroundColor);
        }
        int chooseObj<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor) where T : ICountable
        {
            int choose = chooseItem<T>(list, selector, backgroundColor, foregroundColor);
            if (choose == -1)
            {
                list = TopItemsProvider.GetTopItems(list);
                //choose = chooseItem<T>(list, selector, backgroundColor, foregroundColor);
                do
                {
                    ShowMenuFilm();
                    choose = chooseItem<T>(list, selector, backgroundColor, foregroundColor);
                } while (choose == -1);
            }
            Console.ResetColor();
            return choose;
            }

        void HandleDirector()
        {
            Director[] dr = _directorDB;
            int choose = chooseObj<Director>(dr, director => director.Name, ConsoleColor.Red, ConsoleColor.White);
            _films = _filmDB.Where(film => film.Director.Equals(dr[choose])).ToArray();
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            ShowPlaying(_film);
        }
        void ShowMenu()
        {
            if (_typeMenu == 'V') ShowMenuFilm();
            else if (_typeMenu == 'M') ShowMenuMusic();
            else Console.WriteLine("Error!");
        }
        void CreateMenu()
        {
            if (_typeMenu == 'V') CreateMenuFilm();
            else if (_typeMenu == 'M') CreateMenuMusic();
            else Console.WriteLine("Error!");
        }
        void ErrorMsgMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong character, try again");
            Console.ResetColor();
            Thread.Sleep(200);
            CreateMenu();
        }
        char UserInput()
        {
            char userInput;
            Console.Write("Enter your choice: ");
            userInput = char.ToUpper(Console.ReadKey().KeyChar);
            n = (int)Char.GetNumericValue(userInput);
            Console.WriteLine();
            return userInput;
        }
    }
}
