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
    }
}
