using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        List<Song>_songsAdded = new List<Song>();

        MediaPlayer _mediaPlayer;
        public ConsoleUI(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB, Artist[] ArtistDB, Album[] AlbumDB)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB = PlaylistDB;
            _artistDB=ArtistDB;
            _albumDB=AlbumDB;
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
                    ShowMenu();
                    ShowList();
                    ShowMenuOnlySong();
                }
                else ShowMenu();

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
            Console.WriteLine("--------------------------------------------");
            ShowSong(_song);
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            if (_currentPlaylist != null) Console.WriteLine($"AddToPlaylist({_currentPlaylist.Name}):Q ");
            Console.ResetColor();
            _songsPlayed.Add( _song );
        }
        void ShowList()
        {
            for (int i = 0; i < _songs.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_songs[i].Title}");
            }
        }
        void ShowMenu()
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("Artist:A");
            Console.ResetColor();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Albums:D");
            Console.ResetColor();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Playlists:L");
            Console.ResetColor();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Radio:R");
            Console.ResetColor();
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Exit:E");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");

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
        void ShowSong(Song song)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {song.Title}");
            Console.ResetColor();
        }
        void HandleInputSong(char userInput, MediaPlayer Mediaplayer)
        {

            switch (userInput)
            {
                case 'F':
                    //Console.WriteLine("Next pressed.");
                    if(Mediaplayer!=null)
                    _song = Mediaplayer.Next();

                    break;
                case 'B':
                    //Console.WriteLine("Previous pressed.");
                    if (Mediaplayer != null)
                        _song = Mediaplayer.Previous();
                    break;
                case 'P':
                    //Console.WriteLine("Pause pressed.");
                    if (Mediaplayer != null)
                        Mediaplayer.Pause();
                    break;
                case 'S':
                    //Console.WriteLine("Stop pressed.");
                    if (Mediaplayer != null)
                        Mediaplayer.Stop();
                    break;
                case 'M':
                    //Console.WriteLine("Music.");
                    goto case 'A';
                //break;
                case 'C':
                    //Console.WriteLine("Profile.");
                    break;
                case 'H':
                    //Console.WriteLine("Search.");
                    break;
                case 'A':
                    //Console.WriteLine("Artist.");
                    Artist[] ar = _artistDB;
                    string[] artistList = _songDB.Select(song => song.Artist.Alias)
                               .Distinct()
                               .ToArray();
                    
                    ShowMenu();
                    int chooseArtist = MenuItems.CreateMenu(artistList, ConsoleColor.Magenta, ConsoleColor.White);
                    if (chooseArtist == -1)
                    {
                        ar = TopItemsProvider.GetTopItems(_artistDB);
                        
                        artistList = ar.Select(artist => artist.Alias)
                               .Distinct()
                               .ToArray();
                        
                        do
                        {
                            ShowMenu();
                            chooseArtist = MenuItems.CreateMenu(artistList, ConsoleColor.Magenta, ConsoleColor.White);
                        }while (chooseArtist == -1);
                    }
                    Console.ResetColor();
                    _songs = _songDB.Where(song => song.Artist.Alias == artistList[chooseArtist]).ToArray();
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();


                    break;
                case 'D':
                    //Console.WriteLine("Albums.");
                    Album[] al = _albumDB;
                    string[] albumList = al.Select(album => album.Name)
                               .Distinct()
                               .ToArray();
                    
                    ShowMenu();
                    int chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                    if (chooseAlbums == -1)
                    {
                        al = TopItemsProvider.GetTopItems(_albumDB);
                        //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                        albumList = al.Select(album => album.Name)
                               .Distinct()
                               .ToArray();
                        ShowMenu();

                        chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                        do
                        {
                            ShowMenu();

                            chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                        } while (chooseAlbums == -1);
                    }
                    Console.ResetColor();
                    _songs = _songDB.Where(song => song.Album.Name == albumList[chooseAlbums]).ToArray();
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();

                    break;
                case 'L':
                    //Console.WriteLine("Playists.");
                    Playlist[] pl = _playlistDB;
                    string[] playList = pl.Select(playlist => playlist.Name)
                               .Distinct()
                               .ToArray();
                    
                    ShowMenu();
                    int choosePlaylist = MenuItems.CreateMenu(playList, ConsoleColor.Green, ConsoleColor.Black);
                    if (choosePlaylist == -1)
                    {
                        pl = TopItemsProvider.GetTopItems(_playlistDB);
                        //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                        string[] playList2 = pl.Select(playlist => playlist.Name)
                               .Distinct()
                               .ToArray();
                        ShowMenu();

                        choosePlaylist = MenuItems.CreateMenu(playList2, ConsoleColor.Green, ConsoleColor.Black);
                        do
                        {
                            ShowMenu();

                            choosePlaylist = MenuItems.CreateMenu(playList2, ConsoleColor.Green, ConsoleColor.Black);
                        } while (choosePlaylist == -1);

                    }
                    Console.ResetColor();
                    _songs = pl[choosePlaylist].Songs;
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    _currentPlaylist = pl[choosePlaylist];
                    ShowMenuOnlySong();

                    break;
                case 'R':
                    //Console.WriteLine("Radio.");
                    Radio[] rd = _radioDB;
                    string[] playRadio = rd.Select(radio => radio.Name)
                               .Distinct()
                               .ToArray();
                    
                    ShowMenu();
                    int chooseRadio = MenuItems.CreateMenu(playRadio, ConsoleColor.Yellow, ConsoleColor.Black);
                    if (chooseRadio == -1)
                    {
                        rd = TopItemsProvider.GetTopItems(_radioDB);
                        //Playlist[] list = topItems.Select(item => new Playlist { Count = item.Count }).ToArray();

                        string[] playRadio2 = rd.Select(playlist => playlist.Name)
                               .Distinct()
                               .ToArray();
                        ShowMenu();

                        chooseRadio = MenuItems.CreateMenu(playRadio2, ConsoleColor.Yellow, ConsoleColor.Black);
                        do
                        {
                            ShowMenu();

                            chooseRadio = MenuItems.CreateMenu(playRadio2, ConsoleColor.Yellow, ConsoleColor.Black);
                        } while (chooseRadio == -1);
                    }
                    Console.ResetColor();
                    _songs = rd[chooseRadio].OnAirPlaylist.Songs;
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();
                    break;
                case 'Q':
                    if(_currentPlaylist != null)
                    {
                        _currentPlaylist.AddSong(_song);
                        _songsAdded.Add(_song);
                    }
                    break;
                case var _ when char.IsDigit(userInput):
                    _song = _songs[n - 1];
                    break;
                case 'E':
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
                    Environment.Exit(0);
                    break;
            }
        }
        static public class TopItemsProvider
        {
            static public T[] GetTopItems<T>(T[] array) where T : ICountable
            {
                return array.OrderByDescending(item => item.Count).Take(5).ToArray();
            }
        }
    }
}