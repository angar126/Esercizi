using SpotiView;
using System;

using SpotiData;

namespace SpotiServ
{
    //dovrei dividere parte view e switch case
    static class MenuMediaSource
    {

        static char TypeMenu;
        static UserListenerDTO _user;
        static public void CreateMenu(UserListenerDTO user)
        {
            _user = user;
            char userInput = new char();

            while (!(userInput.Equals('E')|| userInput.Equals('M') || userInput.Equals('V')))
            {

                View.printMusicOrFilm();

                userInput = GetValidInput();
                TypeMenu = userInput;
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
                    CreateMenu(_user);
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
                    ControlMusic music = new ControlMusic(_user);
                    music.TypeMenu = TypeMenu;
                    music.CreateMenu();

                    break;
                case 'V':
                    //Console.WriteLine("V pressed.");
                    //ControlFilm film = new ControlFilm(_db.DirectorDB,_db.FilmDB,_db.User);
                    //film.TypeMenu = TypeMenu;
                    //film.CreateMenu();

                    break;
                case 'E':
                    View.ExitMsg();
                    Environment.Exit(0);
                    break;
            }
        }
       
    }
}
