using City_Library_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Helpers
{
    public static class DataSeeder
    {
        public static LibraryBranch Seed()
        {
            //===== Librarian =====================================================================================================
            Librarian Manager = new("Sara Ahmed", "01012345678",salary: 8500m, hireDate: new DateOnly(2019,3,15));

            //===== Members =======================================================================================================
            Member member01 = new("Ahmed Kamal", phone: "01098765432",email: null ,dateOfBirth: new DateOnly(2003, 7, 22),MembershipDate: new DateOnly(2023, 1, 20));
            Member member02 = new("Nour Hassan", phone: "01155556677", email: null ,dateOfBirth: new DateOnly(1997, 4, 15),MembershipDate: new DateOnly(2024, 3, 5));
            Member member03 = new("Abdelrahman KEeshk", phone: "01018610600", email: "AbdelrahmanKishk@gmail.com" ,dateOfBirth: new DateOnly(2004, 4, 25),MembershipDate: new DateOnly(2026, 4, 25));

            //===== Books =========================================================================================================
            Book book1 = new("9780135398524", "Clean Code", "Robert C. Martin", "software engineering", 2006);
            Book book2 = new("9780132119177", "The Pragmatic Programmer", "Andrew Hunt & David Thomas", "software engineering", 1999);
            Book book3 = new("9780060888695", "To Kill a Mockingbird", "Harper Lee", "classic fiction", 1960);

            //===== Book Copies =========================================================================================================
            BookCopy Copy1 = new("COPY-001", book1);
            BookCopy Copy2 = new("COPY-002", book1, "Fair");
            BookCopy Copy3 = new("COPY-003", book2, "Excellent");
            BookCopy Copy4 = new("COPY-004", book3, "Poor");


            //===== Library Branch  =========================================================================================================
            LibraryBranch branch = new("BR-01", "City Library — Nasr City Branch", "15 Nasr Road, Nasr City, Cairo", "01012345678", "Sat–Thu: 09:00 AM – 09:00 PM", Manager);

            //===== Add Book Copies  =========================================================================================================
            branch.AddBookCopy(Copy1);
            branch.AddBookCopy(Copy2);
            branch.AddBookCopy(Copy3);
            branch.AddBookCopy(Copy4);

            //===== Add Members  =========================================================================================================
            branch.RegisterMember(member01);
            branch.RegisterMember(member02);
            branch.RegisterMember(member03);


            return branch;
        }
    }
}
