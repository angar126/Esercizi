using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SpotiModel;
using SpotiUtil;
using SpotiView;



namespace SpotifyV0
{
    public class Control
    {
        //MENU SELECTOR//////////////////////////////////////
        char _musicChar = 'V';
        char _filmChar = 'M';
        char _typeMenu;

        //DATA//////////////////////////////////////////////////
        Song[] _songDB;
        Radio[] _radioDB;
        Artist[] _artistDB;
        Album[] _albumDB;
        Playlist[] _playlistDB;

        //SONG SWITCH///////////////////////////////////////////
        char[] _botton = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'L', 'R', 'E', 'H', 'Q' };
        Song _song;
        Song[] _songs;        

        //MHA forse è meglio passarlo///
        int n;

        //PLAYLIST////////////////////////////////////////////
        Playlist _currentPlaylist;
        List<Song> _songsPlayed = new List<Song>();
        List<Song> _songsAdded = new List<Song>();

        //SYSTEM//////////////////////////////////////////////
        UserListener _user;
        MediaPlayer _mediaPlayer;
        View _view;
        bool _timeOver = false;
        public char TypeMenu { get { return _typeMenu; } set { _typeMenu = value; } }
        public Control(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, UserListener User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
            _typeMenu = 'M';//per prove
            _timeOver = User.TimeSpan < TimeSpan.Zero;
            _view = new View();
        }

        public Control(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, Director[] DirectorDB, Film[] FilmDB, UserListener User)
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
            _view = new View();
        }

        public void CreateMenuMusic()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_song != null)
                {
                    _view.ShowMenu(_typeMenu);
                    View.ShowList(_songs.Select(song => song.Title).ToArray());
                    ShowMenuOnlySong();
                }
                else _view.ShowMenu(_typeMenu);
                userInput = GetValidInputSong();
                HandleInputSong(userInput, _mediaPlayer);
            }
        }

        //Bottom Banner Song
        void ShowMenuOnlySong()
        {
            _view.ShowPlaying(_song.Title, _timeOver);

            if (_currentPlaylist != null)
            {
                _view.AddSong(_currentPlaylist.Name);
                _songsPlayed.Add(_song);
            }
        }

        char GetValidInputSong()
        {
            char userInput;
            bool validInput = false;
            do
            {
                if (validInput)
                {
                    View.ErrorMsgMenu();
                    CreateMenu();
                }
                userInput = UserInput();
            } while (validInput = !(_botton.Contains(userInput) || _songs != null && _songs.Length != 0 && n > 0 && n <= _songs.Length));

            return userInput;
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
            View.ExitMsg();
            try
            {

                DataStreamL<Song>.WriteonFile($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songsplayd.csv", _songsPlayed);
            }
            catch (Exception ex)
            {
                _view.ExceptionDataStreamMsg("songsplayd.csv", ex.Message);
                //Console.WriteLine($"Error writing to songsplayd.csv: {ex.Message}");
            }
            try
            {
                DataStreamL<Song>.WriteonFile($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{Path.DirectorySeparatorChar}songsadded.csv", _songsAdded);
            }
            catch (Exception ex)
            {
                _view.ExceptionDataStreamMsg("songsadded.csv", ex.Message);
                //Console.WriteLine($"Error writing to songsadded.csv: {ex.Message}"); 
            }
            //Environment.Exit(0);
        }

        //TopFive
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
            int choose = chooseObj(ar, artist => artist.Name, ConsoleColor.Magenta, ConsoleColor.White);
            _songs = _songDB.Where(song => song.Artist.Name == ar[choose].Name).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandleAlbum()
        {
            Album[] al = _albumDB;
            int choose = chooseObj(al, album => album.Name, ConsoleColor.Red, ConsoleColor.White);
            _songs = _songDB.Where(song => song.Album.Name == al[choose].Name).ToArray();
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            ShowMenuOnlySong();
        }
        void HandlePlaylist()
        {
            Playlist[] pl = _playlistDB;
            int choose = chooseObj(pl, playlist => playlist.Name, ConsoleColor.Green, ConsoleColor.Black);
            _songs = pl[choose].Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = (Song)playItem(_songs[_mediaPlayer.CurrentIndex]);
            _currentPlaylist = pl[choose];
            ShowMenuOnlySong();
        }
        void HandleRadio()
        {
            Radio[] rd = _radioDB;
            int choose = chooseObj(rd, radio => radio.Name, ConsoleColor.Yellow, ConsoleColor.Black);
            _songs = rd[choose].OnAirPlaylist.Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = _songs[_mediaPlayer.CurrentIndex];
            ShowMenuOnlySong();
        }

        //When Play song/Film
        dynamic playItem(dynamic play)
        {
            if (play is Song)
            {
                Song song = play as Song;
                if (_timeOver || _user.TimeSpan < TimeSpan.Zero)
                {
                    Random random = new Random();
                    song = _songDB[random.Next(_songDB.Length)];
                    _timeOver = true;
                }
                _user.TimeSpan = TimeSpan.FromMilliseconds(song.TimeMillis);
                play = song;
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


        public void CreateMenuFilm()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_film != null)
                {
                    _view.ShowMenu(_typeMenu);
                    View.ShowList(_films.Select(film => film.Title).ToArray());
                    _view.ShowPlaying(_film.Title, _timeOver);
                }
                else _view.ShowMenu(_typeMenu); ;
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
                    View.ErrorMsgMenu();
                    CreateMenu();
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
            int choose = chooseObj(fl, film => film.Title, ConsoleColor.Magenta, ConsoleColor.White);
            _films = fl;
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        void HandleDirector()
        {
            Director[] dr = _directorDB;
            int choose = chooseObj(dr, director => director.Name, ConsoleColor.Red, ConsoleColor.White);
            _films = _filmDB.Where(film => film.Director.Equals(dr[choose])).ToArray();
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        //Prova dynamic ma sbaglio qualcosa
        //void HandleItem<T>(T[] db, ref dynamic itemPlay, ref dynamic list, dynamic listDB, Func<T, string> selector, Func<T, bool> selectorWhere, ConsoleColor backgroundColor, ConsoleColor foregroundColor) where T : ICountable
        //{
        //    int choose = chooseObj(db, selector, backgroundColor, foregroundColor);
        //    list = listDB.Where(selectorWhere).ToArray();
        //    _mediaPlayer = new MediaPlayer(list);
        //    itemPlay = playItem(list[_mediaPlayer.CurrentIndex]);
        //    _view.ShowPlaying((itemPlay.Title ?? itemPlay.Name), _timeOver);
        //}

        void CreateMenu()
        {
            if (_typeMenu == _filmChar) CreateMenuFilm();
            else if (_typeMenu == _musicChar) CreateMenuMusic();
            else _view.ErrorMsg();
        }

        char UserInput()
        {
            char userInput;
            View.EnterChoiceMsg();
            userInput = char.ToUpper(Console.ReadKey().KeyChar);
            n = (int)char.GetNumericValue(userInput);
            _view.SpaceLine();
            return userInput;
        }

        //Choose single item
        int chooseItem<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            string[] play1 = list.Select(selector)
                       .Distinct()
                       .ToArray();
            _view.ShowMenu(_typeMenu);
            return MenuItems.CreateMenu(play1, backgroundColor, foregroundColor);
        }

        //Choose complex obj
        int chooseObj<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor) where T : ICountable
        {
            int choose = chooseItem(list, selector, backgroundColor, foregroundColor);
            if (choose == -1)
            {
                list = TopItemsProvider.GetTopItems(list);
                //choose = chooseItem<T>(list, selector, backgroundColor, foregroundColor);
                do
                {
                    _view.ShowMenu(_typeMenu);
                    choose = chooseItem(list, selector, backgroundColor, foregroundColor);
                } while (choose == -1);
            }
            Console.ResetColor();
            return choose;
        }
    }
}
