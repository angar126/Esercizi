
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiPres
{
    static public class MenuEnum
    {

        //andrebbe nella view
        static public int CreateMenu(string[] options)
        {

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
                View.EnterChoiceMsg();

            } while (validInput = !int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 0 || userChoice > options.Length);

            Console.WriteLine();
            Console.ResetColor();
            return userChoice - 1;
        }
    }
}
