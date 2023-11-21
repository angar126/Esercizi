using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    class MenuSong
    {
        Song _song;
        public MenuSong(Song song)
        {
            _song = song;
        }
        public Song Song {  get { return _song; } set { _song = value; } }
        public void CreateMenuSong()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                // Mostra il menu
                ShowMenuSong(_song);

                // Ottieni l'input dell'utente
                userInput = GetValidInputSong(_song);

                // Gestisci l'input dell'utente
                HandleInputSong(userInput);
            }
        }

        void ShowMenuSong(Song song)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {song.Title}");
            Console.ResetColor();
            Console.WriteLine("--------------");
            Console.WriteLine("Next press F:");
            Console.WriteLine("Previous press B:");
            Console.WriteLine("Pause press P:");
            Console.WriteLine("Stop Press S:");
            Console.WriteLine("--------------");
            Console.WriteLine("For Exit press E:");
        }

        char GetValidInputSong(Song song)
        {
            char userInput;
                bool validInput = false;

            do
            {
                if (validInput)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Scelta sbagliata, ritenta");
                    Console.ResetColor();
                    ShowMenuSong(song);
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
            
            } while (validInput=!(userInput == 'F' || userInput == 'B' || userInput == 'P' || userInput == 'S' || userInput == 'E'));

            return userInput;
        }

        void HandleInputSong(char userInput)
        {
            
            switch (userInput)
            {
                case 'F':
                    Console.WriteLine("Next pressed.");
                    // Aggiungi il codice per gestire l'azione "Next"
                    break;
                case 'B':
                    Console.WriteLine("Previous pressed.");
                    // Aggiungi il codice per gestire l'azione "Previous"
                    break;
                case 'P':
                    Console.WriteLine("Pause pressed.");
                    // Aggiungi il codice per gestire l'azione "Pause"
                    break;
                case 'S':
                    Console.WriteLine("Stop pressed.");
                    // Aggiungi il codice per gestire l'azione "Stop"
                    break;
                case 'E':
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}