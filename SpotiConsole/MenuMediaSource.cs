using SpotiView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackend;

namespace SpotiControl
{
    //dovrei dividere parte view e switch case
    static class MenuMediaSource
    {
        static DataBase _db;
        static char TypeMenu;

        static public void CreateMenu(DataBase db)
        {
            _db = db;
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
                    CreateMenu(_db);
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
                    ControlMusic music = new ControlMusic(_db.SongDB,_db.RadioDB,_db.PlaylistDB,_db.ArtistDB,_db.AlbumDB,_db.User);
                    music.TypeMenu = TypeMenu;
                    music.CreateMenu();

                    break;
                case 'V':
                    //Console.WriteLine("V pressed.");
                    ControlFilm film = new ControlFilm(_db.DirectorDB,_db.FilmDB,_db.User);
                    film.TypeMenu = TypeMenu;
                    film.CreateMenu();

                    break;
                case 'E':
                    View.ExitMsg();
                    Environment.Exit(0);
                    break;
            }
        }
       
    }
}
