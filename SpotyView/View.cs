using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotiView
{
    public class View
    {
        char _musicChar = 'M';
        char _filmChar = 'V';
        //char _select;
        public View() { }
        //public View(char select) { _select = select; }
        public void TopMenu()
        {
            Console.Clear();
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
        }
        public void AddSong(string currentPlaylistName)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Add Song to last selected Playlist ({currentPlaylistName}):Q ");
            Console.ResetColor();
        }
        public void ShowList(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {strings[i]}");
            }
        }
        public void Button(string String, ConsoleColor BackgroundColor, ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
            Console.Write(String);
            Console.ResetColor();
        }
        public void MiddleMenuSong()
        {
            Button("Artist:A", ConsoleColor.Magenta, ConsoleColor.White);
            Console.Write(" ");
            Button("Albums:D", ConsoleColor.Red, ConsoleColor.White);
            Console.Write(" ");
            Button("Playlists:L", ConsoleColor.Green, ConsoleColor.Black);
            Console.Write(" ");
            Button("Radio:R", ConsoleColor.Yellow, ConsoleColor.Black);
            Console.Write(" ");
            Button("Exit:E", ConsoleColor.White, ConsoleColor.Black);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        public void MiddleMenuFilm()
        {
            Button("Films:A", ConsoleColor.Magenta, ConsoleColor.White);
            Console.Write(" ");
            Button("Director:D", ConsoleColor.Red, ConsoleColor.White);
            Console.Write(" ");
            Button("Exit:E", ConsoleColor.White, ConsoleColor.Black);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        public void ShowPlaying(string playable, bool timeOver)
        {
            Console.WriteLine("--------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Playing now : {playable}");
            Console.ResetColor();
            Console.WriteLine("Next:F     Previous:B     Pause:P     Stop:S");
            if (timeOver)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Time is Over!");
                Console.ResetColor();
            }
        }
        public void ShowMenuMusic()
        {
            TopMenu();
            MiddleMenuSong();
        }
        public void ShowMenuFilm()
        {
            TopMenu();
            MiddleMenuFilm();
        }
        public void ShowMenu(char TypeMenu)
        {
            if (TypeMenu == _filmChar) ShowMenuFilm();
            else if (TypeMenu == _musicChar) ShowMenuMusic();
            else Console.WriteLine("Error!");
        }
        public void ErrorMsgMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("Wrong character, try again");
            Console.ResetColor();
            Thread.Sleep(200);
        }
        public void EnterChoiceMsg()
        {
            Console.Write("Enter your choice: ");
        }
        public void ErrorMsg()
        {
            Console.WriteLine("Error!");
        }
        public void ExitMsg()
        {
            Console.WriteLine("Exiting the program.");
        }
        public void ExceptionDataStreamMsg(string file, string msg)
        {
            Console.WriteLine($"Error writing to {file}: {msg}");
        }
        public void SpaceLine()
        {
            Console.WriteLine();
        }
    }
}
