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

        public static bool PhoneHasDigits(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false; 
            }

            return true;
        }

        public static bool IsValidEmail(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            return str.Contains("@") && str.Contains('.');

        }
    }
}
