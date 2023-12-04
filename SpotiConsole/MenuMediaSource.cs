using SpotiView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiControl
{
    //dovrei dividere parte view e switch case
    static class MenuMediaSource
    {
        static Control _console;
        static public void CreateMenu(Control console)
        {
            _console = console;
            char userInput = new char();

            while (!(userInput.Equals('E')|| userInput.Equals('M') || userInput.Equals('V')))
            {

                View.printMusicOrFilm();

                userInput = GetValidInput();
                console.TypeMenu = userInput;
                HandleInputSong(userInput);
            }
        }
        // andrebbe nella view
        static char GetValidInput()
        {
            char userInput;
            bool validInput = false;

            do
            {
                if (validInput)
                {
                    View.ErrorMsgMenu();
                    CreateMenu(_console);
                }
                View.EnterChoiceMsg();
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
                    //Console.WriteLine("V pressed.");

                    _console.CreateMenuFilm();

                    break;
                case 'E':
                    View.ExitMsg();
                    Environment.Exit(0);
                    break;
            }
        }
       
    }
}
