using City_Library_System.Contracts;
using City_Library_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public class BookCopy : IDisplayable, IBorrowable
    {
        public BookCopy(string copyID, string condtion = "Good", Book book)
        {
            CopyID = copyID;
            Condtion = condtion;
            copyStatus = CopyStatus.Available ;
            this.book = book;
        }

        public string CopyID { get; init; }
        public string Condtion { get; private set; }
        public CopyStatus copyStatus { get; private set; } 
        public Book book { get; init; }

        public BorrowTransactions? ActiveTransaction { get;  set; }

        public string Display()
        {
            return $"Copy [{CopyID}] - {book.Title} | Condition: {Condtion} | {copyStatus}";
        }

        public void Borrow(Member member, int loanDays = 14)
        {
            if (!isAvailable())
                throw new InvalidOperationException($"Copy [{CopyID}] is Not Available (Status: {copyStatus})");

            copyStatus = CopyStatus.Borrowed;
            ActiveTransaction = new BorrowTransactions(member, this, loanDays);
            member.AddBorrowTransaction(ActiveTransaction);
        }


        public bool isAvailable() => copyStatus == CopyStatus.Available ? true : false; 

        public decimal Return()
        {
            if (ActiveTransaction == null)
                throw new InvalidOperationException("No Active Transaction for this copy");

            if (copyStatus != CopyStatus.Borrowed)
                throw new InvalidOperationException($"Copy [{CopyID}] is not currently borrowed");

            ActiveTransaction.MarkReturned(DateOnly.FromDateTime(DateTime.Today));
            decimal fine = ActiveTransaction.CalCulateFine();
            copyStatus = CopyStatus.Available;
            ActiveTransaction = null;

            return fine;
        }

 
    }
}
