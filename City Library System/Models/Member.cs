using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Models
{
    public class Member : LibraryUser
    {
        static int _counter = 0;

        List<BorrowTransactions> _borrowTransactions = new();
        public string MembershipID { get; private set; }
        public DateOnly DateOfBirth { get; set; }
        public string? email { get; private set; }
        
        DateOnly MembershipDate { get; set; }

        public IReadOnlyList<BorrowTransactions> BorrowTransactions => _borrowTransactions;
        public Member(string name, string phone) : base(name, phone)
        {
            _counter++;
            MembershipID = $"MEM-{_counter:D3}";
        }

        public Member(string name, string? email, string phone, DateOnly dateOfBirth, DateOnly MembershipDate) : base(name, phone)
        {
            _counter++;
            MembershipID = $"MEM-{_counter:D3}";
            DateOfBirth = dateOfBirth;
            this.email = email;
            this.MembershipDate = MembershipDate;
        }

        public void AddBorrowTransaction(BorrowTransactions transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
            }
            _borrowTransactions.Add(transaction);
        }

        public override string Display()
        {
            return $"ID: {MembershipID} Name: {Name} joined: {MembershipDate} \n Phone: {Phone}, Email: {email ?? "NA" } Borrows : {0}";
        }

        public string GetHistoryDisplay() {             
            StringBuilder sb = new StringBuilder();
            if (BorrowTransactions.Count == 0)
            {
                sb.AppendLine("No borrowing transactions found");
            }
            else
            {
                foreach (var transaction in BorrowTransactions)
                {
                    sb.AppendLine(transaction.Display());
                }
            }
            return sb.ToString();
        }
    }
}
