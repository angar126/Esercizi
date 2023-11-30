using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyV0
{
    internal class MenuLogin
    {
        static Control _console;
        static Dictionary<string, string> _lenguages = new Dictionary<string, string>()
            {
            { "Chinese (Simplified)", "zh-CN" },
            { "English", "en-US" },
            { "French", "fr-FR" },
            { "German", "de-DE" },
            { "Italian", "it-IT" },
            { "Japanese", "ja-JP" },
            { "Portuguese (Portugal)", "pt-PT" },
            { "Russian", "ru-RU" },
            { "Spanish", "es-ES" },

        };
        static public void CreateMenu(Control console)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("         MENU DI LOGIN");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            CultureInfo culture = new CultureInfo(ShowLengMenu());
            Logger.LogInfo($"Login Data: {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", culture)}");
            Console.WriteLine(culture.ToString());
            Thread.Sleep(200);
            Console.Clear();
            MenuMediaSource.CreateMenu(console);
            
        }
        static string ShowLengMenu()
        {
            Console.WriteLine("Choose the language: ");
            int index = MenuEnum.CreateMenu(_lenguages.Keys.ToArray());
            return _lenguages.ElementAt(index).Value;
        }
        
    }
}
