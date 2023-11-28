using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyV0.Model;

namespace SpotifyV0
{
    static class MenuMediaSource
    {
        static ConsoleUI _console;
        static public void CreateMenu(ConsoleUI console)
        {
            _console = console;
            char userInput = new char();

            while (!(userInput.Equals('E')|| userInput.Equals('M') || userInput.Equals('V')))
            {

                Console.WriteLine("Per iniziare un brano premi 'M', per iniziare un film premi 'V' :");

                userInput = GetValidInput();
                console.TypeMenu = userInput;
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
                    Console.WriteLine("Wrong character, try again");
                    Console.ResetColor();
                    CreateMenu(_console);
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
                    //Console.WriteLine("M pressed.");

                    _console.CreateMenuMusic();

                    break;
                case 'V':
                    Console.WriteLine("V pressed.");

                    //al momento ripropone il menu
                    _console.CreateMenuFilm();

                    break;
                case 'E':
                    Console.WriteLine("Exiting the program.");
                    Environment.Exit(0);
                    break;
            }
        }
       
    }
}
