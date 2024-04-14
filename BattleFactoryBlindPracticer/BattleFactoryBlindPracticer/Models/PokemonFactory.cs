namespace BattleFactoryBlindPracticer.Models
{
    public class PokemonFactory
    {
        public PokemonFactory() { }

        public Pokemon GetPokemon(int pokedexNumber)
        {
            Pokemon pokemon = LoadPokemonData(pokedexNumber);
            return pokemon;
        }

        private Pokemon LoadPokemonData(int pokedexNumber)
        {
            return new Pokemon();
        }
    }
}
