using System;

namespace SpotifyV0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MenuMediaSource.CreateMenu();
            Song song = new Song("TITOLO1");
            Song song2 = new Song("TITOLO2");
            Song[] songList = 
            MenuPlayer m = new MenuPlayer();
            m.CreateMenuSong();
            //string[] a = new string[] { "a", "b", "c" };
            //MenuItems.CreateMenu(a);
        }
    }
}
