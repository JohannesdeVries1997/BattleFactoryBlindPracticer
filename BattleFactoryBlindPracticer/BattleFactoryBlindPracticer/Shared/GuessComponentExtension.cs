using BattleFactoryBlindPracticer.Model;

namespace BattleFactoryBlindPracticer.Shared
{
    public static class GuessComponentExtension
    {
        public static void CheckCorrect(this GuessComponent gc, string[] options)
        {
            foreach (var option in options)
            {
                if (StringHelper.CompareStrings(gc.GetInputValue(), option))
                {
                    gc.SetCorrect();
                    return;
                }
            }
            gc.SetIncorrect();
        }
    }
}
