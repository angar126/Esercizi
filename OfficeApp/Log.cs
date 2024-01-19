using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeApp
{
    internal static class Log
    {
        private const int MaxRowsToShow = 10;

        private static readonly List<string> _logLines = new List<string>();

        public static void Add(string txt)
        {
            _logLines.Add(txt);

            if (_logLines.Count > MaxRowsToShow)
            {
                _logLines.RemoveAt(0);
            }
            Show();
        }

        public static void Show()
        {
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            for (int i = 0; i <= MaxRowsToShow + 5; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
            foreach (var line in _logLines)
            {
                Console.WriteLine(line);
            }
            Console.SetCursorPosition(0, Console.WindowHeight / 2);
        }


    }
}


