using System.Text.RegularExpressions;

namespace Packt.Shared
{
    public static class StringExtensions
    {
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^someregex");
        }

        public static bool IsValidPassword(this string input)
        {
            return Regex.IsMatch(input, @"^someregex");
        }

        public static bool IsValidHex(this string input)
        {
            return Regex.IsMatch(input, @"^someregex");
        }
    }
}