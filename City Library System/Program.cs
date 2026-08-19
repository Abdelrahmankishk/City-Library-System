using City_Library_System.Helpers;
using City_Library_System.Models;
using City_Library_System.Models.Enums;
using City_Library_System.Services;
using ConsoleTheme;

namespace City_Library_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryBranch libraryBranch = DataSeeder.Seed();
            DisplayService displayService = new();
            LibraryService libraryService = new(libraryBranch, displayService);
            char Choice;
            try
            {
                do
                {
                    ConsoleHelper.MainMenu();

                    bool ParseResult = char.TryParse(Console.ReadLine(), out Choice);
                    if (Choice < '0' || Choice > '9')
                        ThemeHelper.PrintError("Enter Valid Choice");

                    switch (Choice)
                    {
                        case '1':
                            displayService.ShowBranchInfo(libraryBranch);
                            break;
                        case '2':
                            displayService.ShowAllMembers(libraryBranch);
                            break;
                        case '3':
                            displayService.ShowAvailableBooks(libraryBranch);
                            break;
                        case '4':
                            displayService.ShowAllCopies(libraryBranch);
                            break;
                        case '5':
                            libraryService.HandleBorrow();
                            break;
                        case '6':
                            libraryService.HandleReturn();
                            break;
                        case '7':
                            libraryService.HandleHistory();
                            break;
                        case '8':
                            libraryService.HandleRegisterMember();
                            break;
                    }


                } while (Choice != '0');
            }
            catch (Exception ex)
            {
                ThemeHelper.PrintError(ex.Message);
            }

        }
        
    }
}
