using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokemonJSONTool.Model
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

        public PokemonType Type1 { get; set; }
        public PokemonType Type2 { get; set; }

        public int HP { get; set; }
        public int Att { get; set; }
        public int Def { get; set; }
        public int SpAtt { get; set; }
        public int SpDef { get; set; }
        public int Spe { get; set; }

        public Ability Ability1 { get; set; }
        public Ability Ability2 { get; set; }
    }
}
