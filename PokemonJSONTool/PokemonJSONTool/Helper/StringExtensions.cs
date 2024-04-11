using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.Helper
{
    public static class StringExtensions
    {
        public static string RemoveQuoteMarks(this string str)
        {
            if (!str.Contains('\"'))
            {
                return str;
            }

            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '\"')
                {
                    result += str[i];
                }
            }
            str = result;
            return str;
        }

        public static string[] SubArray(this string[] stringArray, int startIndex, int count)
        {
            var result = new string[count];
            for(int i = 0; i < count; i++)
            {
                result[i] = stringArray[startIndex + i];
            }
            return result;
        }
    }
}
