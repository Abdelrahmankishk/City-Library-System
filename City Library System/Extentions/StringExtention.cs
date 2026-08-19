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
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsDigit(str[i]))
                {
                    return true;
                }

            }
            return false;
        }

        public static bool IsValidEmail(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            bool hasATT = false;
            bool hasDot = false;

            if (str.Contains("@"))
                hasATT = true;
            if (str.Contains('.'))
                hasDot = true;

            return hasDot && hasATT;

        }
    }
}
