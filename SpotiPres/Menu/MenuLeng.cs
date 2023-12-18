using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using SpotiServ;
using SpotiUtil;


namespace SpotiPres
{
    public class MenuLeng
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

        //prova senza login user
        static TimeSpan timespan = TimeSpan.FromMinutes(5);
        static UserListenerDTO user = new UserListenerDTO("User",timespan);
        static public void CreateMenu()
        {
            //fai il login
            //andrebbe nella view
            View.printTopMenuLeng();
            CultureInfo culture = new CultureInfo(ShowLengMenu());
            Logger.LogInfo($"Login Data: {DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", culture)}");
            Console.WriteLine(culture.ToString());
            Thread.Sleep(200);
            Console.Clear();
            MenuMediaSource.CreateMenu(user);
            
        }
        static string ShowLengMenu()
        {
            View.printChooseLenguage();
            int index = MenuEnum.CreateMenu(_lenguages.Keys.ToArray());
            return _lenguages.ElementAt(index).Value;
        }
        
    }
}
