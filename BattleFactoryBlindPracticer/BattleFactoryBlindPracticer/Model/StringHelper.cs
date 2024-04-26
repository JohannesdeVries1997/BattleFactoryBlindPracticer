namespace BattleFactoryBlindPracticer.Model
{
    public static class StringHelper
    {
        public static bool CompareStrings(string a, string b)
        {
            string aLower = a.ToLower().RemoveSpecialCharacters();
            string bLower = b.ToLower().RemoveSpecialCharacters();
            return (aLower == bLower);
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            char[] illegalCharacters = {' ','\t','\n','-','.',',','\''};
            List<char> illegalCharacterList = new(illegalCharacters);
            for(int i = 0; i < str.Length; i++)
            {
                if (illegalCharacterList.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }

            return str;
        }
    }
}
