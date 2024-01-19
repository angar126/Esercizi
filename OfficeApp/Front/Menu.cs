using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeApp.Models;
using OfficeApp.Models.Providers;

namespace OfficeApp.Front
{
    static public class Menu
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

            } while (validInput = !int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 0 || userChoice > options.Length);

            Console.WriteLine();
            Console.ResetColor();
            return userChoice - 1;
        }
        static public int CreateMenu(string[] options)
        {

            bool validInput = false;

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("--------------------------------------------------------");
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
                
                Log.Show();
            } while (validInput = !int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 0 || userChoice > options.Length);

            Console.WriteLine();
            Console.ResetColor();
            return userChoice;
        }
        public static char CreateMenu<T>(List<T> options)
    where T : ServiceType
        {
            bool validInput = false;

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i].Name}");
            }

            int userChoice;
            do
            {
                Console.WriteLine();
                if (validInput)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Carattere errato, riprova");
                    Console.ResetColor();
                }

                Console.ResetColor();
            } while (!(validInput = int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice)) || userChoice < 1 || userChoice > options.Count);

            Console.WriteLine();
            Console.ResetColor();
            return (char)(userChoice - 1);
        }

    }
}
