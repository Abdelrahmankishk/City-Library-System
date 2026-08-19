using City_Library_System.Models.Enums;
using ConsoleTheme;

namespace City_Library_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThemeHelper.PrintHeader("City Library System");
            ThemeHelper.PrintSectionTitle("Welcome to the City Library System");
            ThemeHelper.PrintOption("Please select an option from the menu below:");
            ThemeHelper.PrintError("1. Register a new member");
            ThemeHelper.PrintWarning("2. Display all registered members");
            ThemeHelper.PrintSuccess("3. Display library branch information");
        }
    }
}
