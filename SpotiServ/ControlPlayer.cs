using SpotiData;
using System;
using System.Linq;
using SpotiView;
using SpotiControl;

namespace SpotiServ
{
    abstract public class ControlPlayer
    {
        protected SongDTO _song;
        protected SongDTO[] _songs;
        protected SongDTO[] _songDB;
        protected Film _film;
        protected bool _timeOver = false;
        protected UserListenerDTO _user;
        protected char _typeMenu;
        protected View _view;
        protected int n;
        public char TypeMenu { get { return _typeMenu; } set { _typeMenu = value; } }
        public ControlPlayer(UserListenerDTO User)
        {
            _user = User;
            _timeOver = User.TimeSpan < TimeSpan.Zero;
            _view = new View();
            _songDB = SongService.GetInstance().GetAll().ToArray();
        }
        protected void HandleNext(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    _song = (SongDTO)playItem(Mediaplayer.Next());
                else _film = (Film)playItem(Mediaplayer.Next());
        }

        protected void HandlePrevious(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    _song = (SongDTO)playItem(Mediaplayer.Previous());
                else _film = (Film)playItem(Mediaplayer.Previous());
        }

        protected void HandlePause(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    Mediaplayer.Pause();
        }

        protected void HandleStop(MediaPlayer Mediaplayer)
        {
            if (Mediaplayer != null)
                if (_songs != null)
                    Mediaplayer.Stop();
        }
        protected dynamic playItem(dynamic play)
        {
            if (play is SongDTO)
            {
                SongDTO song = play as SongDTO;
                if (_timeOver || _user.TimeSpan < TimeSpan.Zero)
                {
                    Random random = new Random();
                    song = _songDB[random.Next(_songDB.Length)];
                    _timeOver = true;
                }
                //_user.TimeSpan = TimeSpan.FromMilliseconds(song.TimeMillis);
                play = song;
            }
            //Logger.LogInfo($"User time span: {XmlConvert.ToString(_user.TimeSpan)}");
            return play;
        }
        protected int chooseItem<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            string[] play1 = list.Select(selector)
                       .Distinct()
                       .ToArray();
            _view.ShowMenu(_typeMenu);
            return MenuItems.CreateMenu(play1, backgroundColor, foregroundColor);
        }

        //Choose complex obj
        protected int chooseObj<T>(T[] list, Func<T, string> selector, ConsoleColor backgroundColor, ConsoleColor foregroundColor) where T : ICountable
        {
            int choose = chooseItem(list, selector, backgroundColor, foregroundColor);
            if (choose == -1)
            {
                list = TopItemsProvider.GetTopItems(list);
                //choose = chooseItem<T>(list, selector, backgroundColor, foregroundColor);
                do
                {
                    _view.ShowMenu(_typeMenu);
                    choose = chooseItem(list, selector, backgroundColor, foregroundColor);
                } while (choose == -1);
            }
            Console.ResetColor();
            return choose;
        }
        static protected class TopItemsProvider
        {
            static public T[] GetTopItems<T>(T[] array) where T : ICountable
            {
                return array.OrderByDescending(item => item.Rating).Take(5).ToArray();
            }
        }
        abstract public void CreateMenu();

        protected char UserInput()
        {
            char userInput;
            View.EnterChoiceMsg();
            userInput = char.ToUpper(Console.ReadKey().KeyChar);
            n = (int)char.GetNumericValue(userInput);
            _view.SpaceLine();
            return userInput;
        }
        protected void HandleProfile() { }
        abstract public void Exit();
    }
}
