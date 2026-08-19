using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Helpers
{
    public static class ConsoleHelper
    {
        public static void MainMenu()
        {
            ThemeHelper.PrintHeader("CITY LIBRARY — MAIN MENU");
            ThemeHelper.PrintOption("1. Branch Information");
            ThemeHelper.PrintOption("2. Show All Users");
            ThemeHelper.PrintOption("3. Show Available Books");
            ThemeHelper.PrintOption("4. Show All Book Copies");
            ThemeHelper.PrintOption("5. Borrow a Book");
            ThemeHelper.PrintOption("6. Return a Book");
            ThemeHelper.PrintOption("8. Register New Member");
            Console.WriteLine("────────────────────────────────────────");
            ThemeHelper.PrintOption("0. Exit");
            Console.WriteLine("════════════════════════════════════════");
            Console.Write("Enter your choice: ");
        }
    }
}
