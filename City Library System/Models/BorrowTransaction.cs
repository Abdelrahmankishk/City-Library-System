using City_Library_System.Contracts;

namespace City_Library_System.Models
{
    public class BorrowTransaction : IDisplayable
    {
        static int _counter = 1000;
        static decimal FinePerDay = 10m;
        static string dateFormat = "dd/MM/yyyy";

        public BorrowTransaction(Member member, BookCopy bookCopy, int LoanDays = 14)
        {
            TransationID = ++_counter;
            this.member = member;
            this.bookCopy = bookCopy;

            BorrowDate = DateOnly.FromDateTime(DateTime.Today);
            DueDate = DateOnly.FromDateTime(DateTime.Today.AddDays(LoanDays));
            ReturnDate = null;
        }

        public int TransationID { get; init; }
        public Member member { get; init; }
        public BookCopy bookCopy { get; init; }
        public DateOnly BorrowDate { get; private set; }
        public DateOnly DueDate { get; private set; }
        public DateOnly? ReturnDate { get; private set; }

        public bool isReturned() => ReturnDate.HasValue;

        public decimal CalCulateFine()
        {
            DateOnly Current = ReturnDate ?? DateOnly.FromDateTime(DateTime.Today);
            int OverDays = Current.DayNumber - DueDate.DayNumber;
            if (OverDays > 0)
            {
                return OverDays * FinePerDay;
            }
            else
            {
                return 0;
            }
        }
        public decimal CalCulateFine(DateOnly returnDate)
        {
            int OverDays = returnDate.DayNumber - DueDate.DayNumber;
            if (OverDays > 0)
            {
                return OverDays * FinePerDay;
            }
            else { return 0; }
        }
        public void MarkReturned(DateOnly returnDate) => ReturnDate = returnDate;

        public string Display()
        {
            string returnedInfo = isReturned() ? ReturnDate!.Value.ToString(dateFormat) : "Not Returned Yet";
            string status = isReturned() ? "Returned" : "Active";
            decimal fine = CalCulateFine();
            string FineDisplay = fine > 0 ? $"{fine:F2} EGP" : "No Fine";

            return $@"── Transaction #{TransationID} ──────────────
Book: {bookCopy.book.Title}
Copy ID: {bookCopy.CopyID}
Borrowed: {BorrowDate.ToString(dateFormat)}
Due: {DueDate.ToString(dateFormat)}
Returned: {returnedInfo}
Status: {status}
Fine: {FineDisplay}
";
        }
    }
}