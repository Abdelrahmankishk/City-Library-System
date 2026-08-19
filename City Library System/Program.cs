using City_Library_System.Helpers;
using City_Library_System.Models.Enums;
using ConsoleTheme;

namespace City_Library_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char Choice;
            do
            {
                ConsoleHelper.MainMenu();
                
                bool ParseResult = char.TryParse(Console.ReadLine(), out Choice);

                if (Choice < '0' || Choice > '9')
                    ThemeHelper.PrintError("Enter Valid Choice");

               
            } while (Choice != '0');

        }
        
    }
}
