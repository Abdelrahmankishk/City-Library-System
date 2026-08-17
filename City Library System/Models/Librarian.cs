using ConsoleTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public class Librarian : LibraryUser
    {
        static int _counter = 0;
        public string LibrarianID { get; private set; }

        public decimal Salary { get; private set; }
        public DateOnly HireDate { get; init; }

        public Librarian(string name, string phone, decimal salary, DateOnly hireDate) : base(name, phone)
        {
            _counter++;
            LibrarianID = $"LIB-{_counter:D3}";

            Salary = salary;
            HireDate = hireDate;
        }
        public override string Display()
        {
            return $"ID: {LibrarianID} Name: {Name} Phone: {Phone}\n Salary: {Salary} Hired: {HireDate}";
        }
    }
}
