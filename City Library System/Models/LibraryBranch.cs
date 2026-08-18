using City_Library_System.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public class LibraryBranch: IDisplayable
    {
        readonly List<BookCopy> _BookCopies = new();
        readonly List<Member> _Members = new();

        public LibraryBranch(string branchID, string branchName, string address, string phone, string? openingHours, Librarian manager)
        {
            BranchID = branchID;
            BranchName = branchName;
            Address = address;
            Phone = phone;
            OpeningHours = openingHours;
            Manager = manager;
        }

        public string BranchID { get; init; }
        public string BranchName { get; init; }
        public string Address { get; init; }
        public string Phone { get; init; }
        public string? OpeningHours { get; private set; }
        public Librarian Manager { get; init; }

        public IReadOnlyList<BookCopy> Copies => _BookCopies;
        public IReadOnlyList<Member> Members => _Members;
        public IReadOnlyList<LibraryUser> Users {
            get
            {
                List<LibraryUser> users = new();
                users.Add(Manager);
                users.AddRange(Members);
                return users;
            }    
        }

        public Member RegisterMember(string name, string Phone)
        {
            Member member = new Member(name, Phone);
            _Members.Add(member);
            return member;
        }
        public Member RegisterMember(string name, DateOnly DateOfBirth,string email ,string Phone, DateOnly MebershipDate)
        {
            Member member = new Member(name,email,Phone,DateOfBirth,MebershipDate);
            _Members.Add(member);
            return member;
        }

        public Member FindMember(string membershipID)
        {
            for(int i = 0; i < _Members.Count; i++)
            {
                if (_Members[i].MembershipID == membershipID)
                {
                    return _Members[i];
                }
            }
            throw new Exception($"Member with ID {membershipID} not found.");
        }

        public void AddBookCopy(BookCopy copy)
        {
            if (copy == null)
            {
                throw new ArgumentNullException("Book copy cannot be null");
            }
            _BookCopies.Add(copy);
        }

        public BookCopy FindBookCopy(string copyID)
        {
            for(int i = 0; i < _BookCopies.Count; i++)
            {
                if (_BookCopies[i].CopyID == copyID)
                {
                    return _BookCopies[i];
                }
            }
            throw new Exception($"Book copy with ID {copyID} not found.");
        }

        public List<BookCopy> GetAvailableCopies()
        {
            List<BookCopy> availableCopies = new();
            for(int i = 0; i < _BookCopies.Count; i++)
            {
                if (_BookCopies[i].isAvailable())
                {
                    availableCopies.Add(_BookCopies[i]);
                }
            }
            return availableCopies;
        }

        public string Display()
        {
            return $@"ID : {BranchID}
Name : {BranchName}
Address : {Address}
Phone : {Phone}
Opening Hours : {OpeningHours}
Manager : {Manager.Name}
Total Members : {Members.Count}
Total Book Copies : {Copies.Count}";
        }
    }
}
