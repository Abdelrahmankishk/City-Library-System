using City_Library_System.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Services
{
    public class DisplayService
    {
        public void ShowBranchInfo(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("LIBRARY BRANCH INFO");
            Console.WriteLine(branch.Display());
        }

        public void ShowAllMembers(LibraryBranch branch)
        {
            if (branch.Users.Count == 0)
            {
                throw new InvalidOperationException("No Registered Members");
            }
            ThemeHelper.PrintHeader("All Registered Users");
            for(int i = 0; i < branch.Users.Count; i++)
            {
                string UserHeader = branch.Users[i] is Librarian ? "LIBRARIAN PROFILE" : "MEMBER PROFILE";
                ThemeHelper.PrintSectionTitle(UserHeader);
                Console.WriteLine(branch.Users[i].Display());
            }
        }

        public void ShowAvailableBooks(LibraryBranch branch)
        {
            if (branch.Copies.Count == 0)
            {
                ThemeHelper.PrintError("No Available Books");
                return;
            }
            List<BookCopy> availableCopies = branch.GetAvailableCopies();
            if(availableCopies.Count == 0)
            {
                ThemeHelper.PrintWarning("No Available Book Copies");
                return;
            }
            else
            {

            ThemeHelper.PrintHeader("Available Book Copies:");
            for(int i = 0; i < availableCopies.Count; i++)
            {
                Console.WriteLine(availableCopies[i].Display());
            }

            }
        }

        public void ShowAllCopies(LibraryBranch branch)
        {
            ThemeHelper.PrintHeader("All Book Copies:");
            if (branch.Copies.Count == 0)
            {
                ThemeHelper.PrintError("No Book Copies Found");
                return;
            }
            for(int i = 0; i < branch.Copies.Count; i++)
            {
                Console.WriteLine(branch.Copies[i].Display());
            }
        }
        public void ShowMemberHistory(Member member)
        { 
            Console.WriteLine(member.GetHistoryDisplay());
        }

        public void ShowBorrowSuccess(Member member,BookCopy copy)
        {
            if(member == null)
            {
                throw new ArgumentNullException("Member cannot be null.");
            }
            if(copy == null)
            {
                throw new ArgumentNullException("Book copy cannot be null.");
            }
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyID}] \"{copy.book.Title}\" borrowed by {member.Name}");
            ThemeHelper.PrintSuccess($"Due Date: {copy.ActiveTransaction!.DueDate:dd/MM/yyyy}");
        }

        public void ShowReturnSuccess(BookCopy copy, decimal fine) { 
            if(copy == null)
            {
                throw new ArgumentNullException("Book copy cannot be null.");
            }
            ThemeHelper.PrintSuccess($"Copy [{copy.CopyID}]: \"{copy.book.Title}\" returned");
            if(fine > 0)
            {
                ThemeHelper.PrintWarning($"Late return fine: {fine:f2}");
            }
            else
            {
                ThemeHelper.PrintWarning("Returned on time. No fine.");
            }
        }

        public void RegistrationSuccess(Member member)
        {
            if(member == null)
            {
                throw new ArgumentNullException("Member cannot be null.");
            }
            ThemeHelper.PrintSuccess($"Member: {member.Name} - [{member.MembershipID}] registered");
        }

        public void ShowAddBookCopySuccess(BookCopy copy)
        {
            if(copy == null)
            {
                throw new ArgumentNullException("Book copy cannot be null.");
            }
            ThemeHelper.PrintSuccess($"Copy: [{copy.CopyID}] - \"{copy.book.Title}\" added to library");
        }

    }
}
