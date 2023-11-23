using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class MenuPlayer
    {
        Song[] _songDB;
        Radio[] _radioDB;
        Playlist[] _playlistDB;
        char[] _botton = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'L', 'R','E' };
        char[] _numb = new char[0];
        Song _song;
        Song[] _songs;
        int n;

        IPlaylist _playlist;
        MediaPlayer _mediaPlayer;
        public MenuPlayer(Song[] songDB, Radio[] RadioDB, Playlist[] PlaylistDB)
        {
            _songDB = songDB;
            _radioDB = RadioDB;
            _playlistDB=PlaylistDB;
            CreateMenuSong();   
        }
        public MenuPlayer(Song song)
        {
            _song = song;
            Song[]  _songs =new Song[] { song };
            _mediaPlayer = new MediaPlayer(_songs);
        }
        public MenuPlayer(IPlaylist IPlaylist)
        {
            Song[]  _songs = IPlaylist.Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = _songs[_mediaPlayer.CurrentIndex];
        }
        //public Song Song {  get { return _song; } set { _song = value; } }
        public void CreateMenuSong()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                // Mostra il menu
                if (_song != null)
                {
                    ShowMenu();
                    ShowList();
                    ShowMenuSong(_song);
                }else ShowMenu();

                // Ottieni l'input dell'utente
                userInput = GetValidInputSong();

                // Gestisci l'input dell'utente
                HandleInputSong(userInput, _mediaPlayer);
                Console.Clear();
            }
        }

        void ShowMenuSong(Song song)
        {
            ShowSong(_song);           
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
        }
        void ShowMenuOnlySong()
        {
            Console.WriteLine("--------------------------------------------");
            ShowSong(_song);
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
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
                    CreateMenuSong();
                    //continue;
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                n = (int)Char.GetNumericValue(userInput);
                Console.WriteLine();

            } while (validInput = !(_botton.Contains(userInput)|| _songs != null && _songs.Length != 0 && n > 0 && n <= _songs.Length));
            

                //userInput == 'F' || userInput == 'B' || userInput == 'P' || userInput == 'S' || userInput == 'E'));

                return userInput;
        }
        void ShowSong(Song song) {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {song.Title}");
            Console.ResetColor();
        }
        void ShowMenuItem(ConsoleColor BackgroundColor, ConsoleColor ForeGround)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForeGround;
            


            Console.ResetColor();
        }
       
        void HandleInputSong(char userInput, MediaPlayer Mediaplayer)
        {
            
            switch (userInput)
            {
                case 'F':
                    Console.WriteLine("Next pressed.");
                    _song = Mediaplayer.Next();

                    break;
                case 'B':
                    Console.WriteLine("Previous pressed.");
                    _song = Mediaplayer.Previous();
                    break;
                case 'P':
                    Console.WriteLine("Pause pressed.");
                    Mediaplayer.Pause();
                    break;
                case 'S':
                    Console.WriteLine("Stop pressed.");
                    Mediaplayer.Stop();
                    break;
                case 'M':
                    Console.WriteLine("Music.");
                    goto case 'A';
                    //break;
                case 'C':
                    Console.WriteLine("Profile.");
                    // Aggiungi il codice
                    break;
                case 'A':
                    Console.WriteLine("Artist.");
                    string[] artistList = _songDB.Select(song => song.Artist.Alias)
                               .Distinct()
                               .ToArray();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu();
                    int chooseArtist = MenuItems.CreateMenu(artistList, ConsoleColor.Magenta, ConsoleColor.White);
                    Console.ResetColor();
                    _songs = _songDB.Where(song => song.Artist.Alias == artistList[chooseArtist]).ToArray();               
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();
                    

                    break;
                case 'D':
                    Console.WriteLine("Albums.");
                    string[] albumList = _songDB.Select(song => song.Album.Name)
                               .Distinct()
                               .ToArray();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu();
                    int chooseAlbums = MenuItems.CreateMenu(albumList, ConsoleColor.Red, ConsoleColor.White);
                    Console.ResetColor();
                    _songs = _songDB.Where(song => song.Album.Name == albumList[chooseAlbums]).ToArray();
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();
                    
                    break;
                case 'L':
                    Console.WriteLine("Playists.");
                    string[] playList = _playlistDB.Select(playlist => playlist.Name)
                               .Distinct()
                               .ToArray();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu();
                    int choosePlaylist = MenuItems.CreateMenu(playList, ConsoleColor.Green, ConsoleColor.Black);
                    Console.ResetColor();
                    _songs = _playlistDB[choosePlaylist].Songs;
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();
                    
                    break;
                case 'R':
                    Console.WriteLine("Radio.");
                    string[] playRadio = _radioDB.Select(radio => radio.Name)
                               .Distinct()
                               .ToArray();
                    Console.WriteLine();
                    Console.WriteLine();
                    ShowMenu();
                    int chooseRadio = MenuItems.CreateMenu(playRadio, ConsoleColor.Yellow, ConsoleColor.Black);
                    Console.ResetColor();
                    _songs = _radioDB[chooseRadio].OnAirPlaylist.Songs;
                    _mediaPlayer = new MediaPlayer(_songs);
                    _song = _songs[_mediaPlayer.CurrentIndex];
                    ShowMenuOnlySong();
                    
                    break;
                case var _ when char.IsDigit(userInput):

                    _song = _songs[n-1];
                    
                    break;
                case 'E':
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
            }
        }
        
    }
}