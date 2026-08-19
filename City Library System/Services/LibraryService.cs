using City_Library_System.Extentions;
using City_Library_System.Models;
using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Services
{
    public class LibraryService
    {
        private readonly LibraryBranch _branch;
        private readonly DisplayService _displayService;

        public LibraryService(LibraryBranch branch, DisplayService displayService)
        {
            _branch = branch;
            _displayService = displayService;
        }

        public void HandleBorrow()
        {
            string MemberIdInput = ThemeHelper.Prompt("Enter Member ID: ").NormalizeID();
            Member member = _branch.FindMember(MemberIdInput);

            _displayService.ShowAvailableBooks(_branch);

            string BookCopyIDInput = ThemeHelper.Prompt("Enter Copy ID to borrow: ").NormalizeID();
            BookCopy bookCopy = _branch.FindBookCopy(BookCopyIDInput);

            bookCopy.Borrow(member);

            _displayService.ShowBorrowSuccess(member, bookCopy);
        }

        public void HandleReturn()
        {
            string BookCopyIDInput = ThemeHelper.Prompt("Enter Copy ID to borrow: ").NormalizeID();
            BookCopy bookCopy = _branch.FindBookCopy(BookCopyIDInput);

            decimal fine = bookCopy.Return();

            _displayService.ShowReturnSuccess(bookCopy, fine);
        }

        public void HandleHistory()
        {
            string MemberIdInput = ThemeHelper.Prompt("Enter Member ID: ").NormalizeID();
            Member member = _branch.FindMember(MemberIdInput);

            _displayService.ShowMemberHistory(member);
        }

        public void HandleRegisterMember()
        {
            string UserName = ThemeHelper.Prompt("Enter Full Name: ");

            string PhoneNumber = ThemeHelper.Prompt("Enter Phone Number: ");
            if (!PhoneNumber.PhoneHasDigits())
                throw new Exception("Phone number must contain at least one digit.");

            string email = ThemeHelper.Prompt("Enter Email Address: ");
            if(!email.IsValidEmail())
                throw new Exception("Invalid email format. Must contain '@' and '.'");
            
            Member member = new Member(UserName,email,PhoneNumber,default, DateOnly.FromDateTime(DateTime.Now));

            _displayService.RegistrationSuccess(member);
        }
    }
}
