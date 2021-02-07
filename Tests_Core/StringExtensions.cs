using System.Linq;

namespace Tests_Core
{
    public static class StringExtensions
    {
        public static string[] RemoveWhitespace(this string[] input)
        {
            var trimmedStringArray = new string[3];
            var startIndex = 2;
            for (int i = 0; i < trimmedStringArray.Length; i++)
            {
                trimmedStringArray[i] = new string(input[startIndex++].ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray());
            }

            return trimmedStringArray;
        }
    }
}
