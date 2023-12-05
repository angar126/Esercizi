using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackend;
using SpotiView;

namespace SpotiControl
{
    public class ControlFilm : ControlPlayer
    {
        Film[] _films;
        Film[] _filmDB;
        Director[] _directorDB;
        MediaPlayer _mediaPlayer;

        char[] _bottonFilm = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'E' }; //'L', 'R', 'H', 'Q'

        public ControlFilm(Director[] DirectorDB, Film[] FilmDB, UserListener User):base (User)
        {
            _timeOver = User.TimeSpan < TimeSpan.Zero;
            _directorDB = DirectorDB;
            _filmDB = FilmDB;
            _view = new View();
        }
        public void CreateMenuFilm()
        {
            char userInput = new char();
            while (!userInput.Equals('E'))
            {
                if (_film != null)
                {
                    _view.ShowMenuFilm();
                    _view.ShowList(_films.Select(film => film.Title).ToArray());
                    _view.ShowPlaying(_film.Title, _timeOver);
                }
                else _view.ShowMenuFilm(); ;
                userInput = GetValidInputFilm();
                HandleInputVideo(userInput, _mediaPlayer);
            }
        }
        public override void CreateMenu()
        {
            CreateMenuFilm();
        }
        char GetValidInputFilm()
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
            } while (validInput = !(_bottonFilm.Contains(userInput) || _films != null && _films.Length != 0 && n > 0 && n <= _films.Length));
            return userInput;
        }
        void HandleInputVideo(char userInput, MediaPlayer Mediaplayer)
        {
            switch (userInput)
            {
                case 'F':
                    HandleNext(Mediaplayer);
                    break;
                case 'B':
                    HandlePrevious(Mediaplayer);
                    break;
                case 'P':
                    HandlePause(Mediaplayer);
                    break;
                case 'S':
                    HandleStop(Mediaplayer);
                    break;
                case 'M':
                    HandleFilms();
                    break;
                case 'C':
                    HandleProfile();
                    break;
                case 'A':
                    HandleFilms();
                    break;
                case 'D':
                    HandleDirector();

                    break;
                case var _ when char.IsDigit(userInput):
                    _film = _films[n - 1];
                    break;
                case 'E':
                    Exit();
                    break;
            }
        }
        void HandleFilms()
        {
            Film[] fl = _filmDB;
            int choose = chooseObj(fl, film => film.Title, ConsoleColor.Magenta, ConsoleColor.White);
            _films = fl;
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        void HandleDirector()
        {
            Director[] dr = _directorDB;
            int choose = chooseObj(dr, director => director.Name, ConsoleColor.Red, ConsoleColor.White);
            _films = _filmDB.Where(film => film.Director.Equals(dr[choose])).ToArray();
            _mediaPlayer = new MediaPlayer(_films);
            _film = (Film)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        override public void Exit()
        {
            View.ExitMsg();
        }
    }
}
