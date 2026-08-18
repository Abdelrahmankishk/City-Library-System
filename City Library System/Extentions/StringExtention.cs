using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace City_Library_System.Extentions
{
    public static class StringExtention
    {
        public static string NormalizeID(this string str)
        {
            return str?.Trim().ToUpperInvariant() ?? string.Empty;
        }
    }
}
