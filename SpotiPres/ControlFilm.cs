using System;
using System.Linq;
using SpotiData;
using SpotiServ;
using SpotiServ.Services;

namespace SpotiPres
{
    public class ControlFilm : ControlPlayer
    {
        FilmDTO[] _films;

        MediaPlayer _mediaPlayer;

        char[] _bottonFilm = new char[] { 'F', 'B', 'P', 'S', 'M', 'C', 'A', 'D', 'E' }; //'L', 'R', 'H', 'Q'

        public ControlFilm(UserListenerDTO User):base (User)
        {
            _timeOver = User.TimeSpan < TimeSpan.Zero;

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
                    View.ShowList(_films.Select(film => film.Title).ToArray());
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
            FilmService fs = FilmService.GetInstance();
            FilmDTO[] fl = fs.GetAll().ToArray();
            int choose = chooseObj(fl, film => film.Title, ConsoleColor.Magenta, ConsoleColor.White);
            _films = fl;
            _mediaPlayer = new MediaPlayer(_films);
            _film = (FilmDTO)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        void HandleDirector()
        {
            DirectorService ds = DirectorService.GetInstance();
            DirectorDTO[] dr = ds.GetAll().ToArray();
            int choose = chooseObj(dr, director => director.Name, ConsoleColor.Red, ConsoleColor.White);
            FilmService fs = FilmService.GetInstance();
            _films = fs.GetAll().ToArray().Where(film => film.DirectorDTO.Equals(dr[choose])).ToArray();
            _mediaPlayer = new MediaPlayer(_films);
            _film = (FilmDTO)playItem(_films[_mediaPlayer.CurrentIndex]);
            _view.ShowPlaying(_film.Title, _timeOver);
        }
        override public void Exit()
        {
            View.ExitMsg();
        }
    }
}
