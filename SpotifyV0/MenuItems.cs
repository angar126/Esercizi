using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyV0
{
    static class MenuItems
    {
        static public int CreateMenu(string[] options, ConsoleColor BackgroundColor, ConsoleColor ForeGround)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForeGround;
            bool validInput = false;

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
           
            int userChoice;
            do
            {
                Console.WriteLine();
                if (validInput)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong character, try again");
                    Console.ResetColor();
                }
                Console.ResetColor();
                Console.Write("Enter your choice: ");
                
            } while (validInput=!int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 1 || userChoice > options.Length);

            Console.WriteLine();
            Console.ResetColor();
            return userChoice - 1;
        }
    }   
}
