using City_Library_System.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public abstract class LibraryUser : IDisplayable
    {
        public string Name { get; protected set; }
        public string Phone { get; protected set; }

        public LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }

        public abstract string Display();
    }
}
