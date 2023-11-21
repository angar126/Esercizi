using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    static class MenuMediaSource
    {
        static public void CreateMenu()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {

                Console.WriteLine("Per iniziare un brano premi 'M', per iniziare un file premi 'V' :");

                userInput = GetValidInput();

                HandleInputSong(userInput);
            }
        }
        static char GetValidInput()
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
                    CreateMenu();
                }
                Console.Write("Enter your choice: ");
                userInput = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

            } while (validInput = !(userInput == 'M' || userInput == 'V' || userInput == 'E'));

            return userInput;
        }
        static void HandleInputSong(char userInput)
        {

            switch (userInput)
            {
                case 'M':
                    Console.WriteLine("M pressed.");

                    //prova
                    Song song = new Song("TITOLO!");
                    MenuSong classUI = new MenuSong(song);
                    classUI.CreateMenuSong();

                    break;
                case 'V':
                    Console.WriteLine("V pressed.");
                    
                    break;
                case 'E':
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
