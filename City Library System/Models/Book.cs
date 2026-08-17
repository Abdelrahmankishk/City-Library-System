using City_Library_System.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public class Book: IDisplayable
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string Category { get; private set; }
        public int PubYear { get; private set; }

        public Book(string iSBN, string title, string authorName, string category, int pubYear)
        {
            ISBN = iSBN;
            Title = title;
            AuthorName = authorName;
            Category = category;
            PubYear = pubYear;
        }
        public Book(string iSBN, string title): this(iSBN,title,"Unknown", "General", 0)
        {

        }

        public string Display()
        {
            return $"[{ISBN}] - {Title} Written by {AuthorName} Category: {Category} PUblished in: {PubYear}";
        }
    }
}
