using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using SpotiControl;
using SpotiData;
using SpotiUtil;
using SpotiView;

namespace SpotiServ
{
    internal class MenuLeng
    {
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
        static public void CreateMenu(DataBase db)
        {
            //andrebbe nella view
            View.printTopMenuLeng();
            CultureInfo culture = new CultureInfo(ShowLengMenu());
            Logger.LogInfo($"Login Data: {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", culture)}");
            Console.WriteLine(culture.ToString());
            Thread.Sleep(200);
            Console.Clear();
            MenuMediaSource.CreateMenu(db);
            
        }
        static string ShowLengMenu()
        {
            View.printChooseLenguage();
            int index = MenuEnum.CreateMenu(_lenguages.Keys.ToArray());
            return _lenguages.ElementAt(index).Value;
        }
        
    }
}
