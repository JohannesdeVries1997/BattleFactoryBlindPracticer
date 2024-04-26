namespace BattleFactoryBlindPracticer.Model
{
    public static class StringHelper
    {
        public static bool CompareStrings(string a, string b)
        {
            string aLower = a.ToLower();
            string bLower = b.ToLower();
            return (aLower == bLower);
        }
    }
}
