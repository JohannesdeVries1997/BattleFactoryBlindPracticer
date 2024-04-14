namespace BattleFactoryBlindPracticer.Models
{
    public class Pokemon
    {
        public Pokemon() { }

        public Pokemon(int pokedexNumber)
        {
            PokedexNumber = pokedexNumber;
        }

        public int PokedexNumber { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type1 { get; set; } = string.Empty;
        public string Type2 { get; set; } = string.Empty;

        public int HP { get; set; }
        public int Att { get; set; }
        public int Def { get; set; }
        public int SpAtt { get; set; }
        public int SpDef { get; set; }
        public int Spe { get; set; }

        public string Ability1 { get; set; } = string.Empty;
        public string Ability2 { get; set; } = string.Empty;
    }
}
