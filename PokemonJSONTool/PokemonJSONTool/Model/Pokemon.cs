﻿namespace PokemonJSONTool.Model
{
    public struct Types
    {
        PokemonType Type1;
        PokemonType Type2;
    }

    public struct Stats
    {
        int HP;
        int Att;
        int Def;
        int SpAtt;
        int SpDef;
        int Spe;
    }

    public struct Abilities
    {
        Ability Ability1;
        Ability Ability2;
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