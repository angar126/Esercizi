using System;

namespace SpotifyV0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuMediaSource.CreateMenu();
            Song song = new Song("TITOLO!");
            MenuPlayer m = new MenuPlayer();
            m.CreateMenuSong();
            //string[] a = new string[] { "a", "b", "c" };
            //MenuItems.CreateMenu(a);
        }
    }
}
