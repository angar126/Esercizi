using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SpotiBackend;
using SpotiUtil;
using SpotiView;



namespace SpotiControl
{
    public class ControlMusic : ControlPlayer
    {
        //MENU SELECTOR//////////////////////////////////////
        char _musicChar = 'V';
        char _filmChar = 'M';

        //DATA//////////////////////////////////////////////////

        Radio[] _radioDB;
        Artist[] _artistDB;
        Album[] _albumDB;
        Playlist[] _playlistDB;

        //SONG SWITCH///////////////////////////////////////////
        char[] _botton = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'L', 'R', 'E', 'H', 'Q' };


        //PLAYLIST////////////////////////////////////////////
        Playlist _currentPlaylist;
        List<Song> _songsPlayed = new List<Song>();
        List<Song> _songsAdded = new List<Song>();

        //SYSTEM//////////////////////////////////////////////

        MediaPlayer _mediaPlayer;

        public ControlMusic(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB, UserListener User): base(User)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB = ArtistDB;
            _albumDB = AlbumDB;
            _user = User;
            _timeOver = User.TimeSpan < TimeSpan.Zero;
            _view = new View();
        }
        public void CreateMenuMusic()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_song != null)
                {
                    _view.ShowMenuMusic();
                    _view.ShowList(_songs.Select(song => song.Title).ToArray());
                    ShowMenuOnlySong();
                }
                else _view.ShowMenuMusic();
                userInput = GetValidInputSong();
                HandleInputSong(userInput, _mediaPlayer);
            }
        }
        override public void CreateMenu() { 
            CreateMenuMusic(); 
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
        override public void Exit()
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
        private void HandleMusic(MediaPlayer Mediaplayer)
        {
            CreateMenuMusic();
        }
    }
}
