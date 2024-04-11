using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PokemonJSONTool.Model
{
    public struct Types
    {
        PokemonType Type1;
        PokemonType Type2;

        public Types(PokemonType type1, PokemonType type2)
        {
            this.Type1 = type1;
            this.Type2 = type2;
        }
    }

    public struct Stats
    {
        int HP;
        int Att;
        int Def;
        int SpAtt;
        int SpDef;
        int Spe;

        public Stats(int hp, int att, int def, int spatt, int spdef, int spe)
        {
            this.HP = hp;
            this.Att = att;
            this.Def = def;
            this.SpAtt = spatt;
            this.SpDef = spdef;
            this.Spe = spe;
        }
    }

    public struct Abilities
    {
        Ability Ability1;
        Ability Ability2;

        public Abilities(Ability ability1, Ability ability2)
        {
            this.Ability1 = ability1;
            this.Ability2 = ability2;
        }
    }


    public class Pokemon
    {
        public Pokemon() { }

        public Pokemon(int pokedexNumber)
        {
            PokedexNumber = pokedexNumber;
        }

        public int PokedexNumber { get; set; }

        public string Name { get; set; } = string.Empty;

        public Types Typing { get; set; }

        public Stats Stats { get; set; }

        public Abilities Abilities { get; set; }
    }
}
