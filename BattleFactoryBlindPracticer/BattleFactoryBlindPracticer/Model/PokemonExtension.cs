using System.Net;

namespace BattleFactoryBlindPracticer.Model
{
    public static class PokemonExtension
    {
        public static bool TryGetPokemonByDexNumber(this List<Pokemon> pokemons, int pokedexNumber, out Pokemon pokemon)
        {
            foreach (Pokemon p in pokemons)
            {
                if (p.PokedexNumber == pokedexNumber)
                {
                    pokemon = p;
                    return true;
                }
            }
            pokemon = new Pokemon();
            return false;
        }

        public static bool TryGetPokemonByName(this List<Pokemon> pokemons, string pokemonName, out Pokemon pokemon)
        {
            foreach (Pokemon p in pokemons)
            {
                if (CompareStrings(p.Name, pokemonName))
                {
                    pokemon = p;
                    return true;
                }
            }
            pokemon = new Pokemon();
            return false;
        }

        public static void GetEmptyPokemon(this Pokemon pokemon)
        {
            pokemon.PokedexNumber = 0;
            pokemon.Name = "";
            pokemon.Type1 = "None";
            pokemon.Type2 = "None";
            pokemon.Ability1 = "None";
            pokemon.Ability2 = "None";
            pokemon.HP = 0;
            pokemon.Att = 0;
            pokemon.Def = 0;
            pokemon.SpAtt = 0;
            pokemon.SpDef = 0;
            pokemon.Spe = 0;
        }

        private static bool CompareStrings(string a, string b)
        {
            string aLower = a.ToLower();
            string bLower = b.ToLower();
            return (a == b);
        }
    }
}
