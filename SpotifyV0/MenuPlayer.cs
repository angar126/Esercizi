using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class MenuPlayer
    {
        char[] _botton = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'L', 'R','E' };
        Song _song;
        Song[] _songs;
        IPlaylist _playlist;
        MediaPlayer _mediaPlayer;
        public MenuPlayer()
        {
            CreateMenuSong();
        }
        public MenuPlayer(Song song)
        {
            _song = song;
            _songs =new Song[] { song };
            _mediaPlayer = new MediaPlayer(_songs);
        }
        public MenuPlayer(IPlaylist IPlaylist)
        {
            _songs = IPlaylist.Songs;
            _mediaPlayer = new MediaPlayer(_songs);
            _song = _songs[_mediaPlayer.CurrentIndex];
        }
        public Song Song {  get { return _song; } set { _song = value; } }
        public void CreateMenuSong()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                // Mostra il menu
                if (_song != null)
                {
                    ShowMenuSong(_song);
                }else ShowMenuSong();

                // Ottieni l'input dell'utente
                userInput = GetValidInputSong();

                // Gestisci l'input dell'utente
                HandleInputSong(userInput, _mediaPlayer);
            }
        }

        void ShowMenuSong(Song song)
        {
            ShowMenuSong();
            ShowSong(_song);
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
        }
        void ShowMenuSong()
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
            ShowMenuItem();
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
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

            } while (validInput = !(_botton.Contains(userInput)));
            //userInput == 'F' || userInput == 'B' || userInput == 'P' || userInput == 'S' || userInput == 'E'));

            return userInput;
        }
        void ShowSong(Song song) {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {song.Title}");
            Console.ResetColor();
        }
        void ShowMenuItem()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Seleziona cosa ascoltare");
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
                    // Aggiungi il codice
                    break;
                case 'S':
                    Console.WriteLine("Stop pressed.");
                    // Aggiungi il codice
                    break;
                case 'M':
                    Console.WriteLine("Music.");
                    // Aggiungi il codice
                    break;
                case 'C':
                    Console.WriteLine("Profile.");
                    // Aggiungi il codice
                    break;
                case 'A':
                    Console.WriteLine("Artist.");
                    // Aggiungi il codice
                    break;
                case 'D':
                    Console.WriteLine("Albums.");
                    // Aggiungi il codice
                    break;
                case 'L':
                    Console.WriteLine("Playists.");
                    // Aggiungi il codice
                    break;
                case 'R':
                    Console.WriteLine("Radio.");
                    // Aggiungi il codice
                    break;
                case 'E':
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}