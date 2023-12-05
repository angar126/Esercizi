using SpotiView;
using System;

namespace SpotiControl
{
    //andrebbe nella view
    static public class MenuItems
    {
        static public int CreateMenu(string[] options, ConsoleColor BackgroundColor, ConsoleColor ForeGround)
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForeGround;
            bool validInput = false;
            
            View.ShowList(options);
            

            int userChoice;
            do
            {
                Console.WriteLine();
                if (validInput)
                {
                    View.ErrorMsgMenu();
                }
                Console.ResetColor();
                View.EnterChoiceTop5Msg();

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

            int userChoice;
            do
            {
                Console.WriteLine();
                if (validInput)
                {
                    View.ErrorMsgMenu();
                }
                Console.ResetColor();
                View.EnterChoiceTop5Msg();

            } while (validInput = !int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 0 || userChoice > options.Length);

            Console.WriteLine();
            Console.ResetColor();
            return userChoice - 1;
        }
    }
}
