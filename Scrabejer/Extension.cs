using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabejer
{
    public static class Extension
    {
        public static string RemoveFirst(this string str, char c)
        {
            bool first = true;
            return new string(str.Where(letter =>
            {
                bool invalidLetter = letter == c && first;
                if (invalidLetter) first = false;
                return !invalidLetter;
            }
            ).ToArray());
        }
        public static bool ContainsOnlyOnce(this string str, string lettersAllowedOnce)
        {
            foreach (char charInStr in str)
            {
                if (lettersAllowedOnce.Contains(charInStr)) lettersAllowedOnce = lettersAllowedOnce.RemoveFirst(charInStr);
                else if (lettersAllowedOnce.Contains('.')) lettersAllowedOnce = lettersAllowedOnce.RemoveFirst('.');
                else return false;
            }
            return true;
        }
    }
}
