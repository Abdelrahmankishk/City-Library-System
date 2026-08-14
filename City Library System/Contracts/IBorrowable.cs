using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Contracts
{
    public interface IBorrowable
    {
        void Borrow(Member member, int loanDays = 14);
        decimal Return();
        bool isAvailable();
    }
}
