using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    // Extension methods must be defined in a static class.
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string RemoveComma(this String str)
        {
            return str.Replace(",", string.Empty);
        }

        public static string GetFirstXCharacters(this String str, int X)
        {
            if (str.Length < X)
            {
                return str;
            }
            else
            {
                return str.Substring(0, X);
            }
        }

        public static string Nullable(this string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str;
        }
    }
