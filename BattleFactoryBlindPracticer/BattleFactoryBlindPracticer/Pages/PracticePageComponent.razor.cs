using BattleFactoryBlindPracticer.Model;
using System.Net;

namespace BattleFactoryBlindPracticer.Pages
{
    struct RoundInfo{
        public int startIndex;
        public int endIndex;

        public RoundInfo(int startIndex, int endIndex)
        {
            this.startIndex = startIndex;
            this.endIndex = endIndex;
        }
    }

    public partial class PracticePageComponent
    {
        private List<Pokemon> pokemons = new();

        private List<BattleFactorySet> sets = new();

        private BattleFactorySet chosenSet = new BattleFactorySet();

        private int pokedexNumber = 0;

        private Guid pokemonGuesser_Id = Guid.NewGuid();
        private Guid moveList_Id = Guid.NewGuid();

        private int roundNumber = 1;
        private RoundInfo[] roundInfo = {
            new RoundInfo(0, 91),
            new RoundInfo(54, 158),
            new RoundInfo(159, 263),
            new RoundInfo(264, 359),
            new RoundInfo(360, 455),
            new RoundInfo(456, 551)
        };
        
        protected override async Task OnInitializedAsync()
        {
            pokemons = await DataGetter.GetPokemonData(_client);
            sets = await DataGetter.GetBattleFactoryData(_client);
            GenerateNewPokemon();
        }

        private void HandleNextClick()
        {
            pokemonGuesser_Id = Guid.NewGuid();
            moveList_Id = Guid.NewGuid();
            GenerateNewPokemon();
        }

        private void GenerateNewPokemon()
        {
            Random random = new();
            RoundInfo round = roundInfo[roundNumber - 1];
            int interval = round.endIndex - round.startIndex;
            int offset = round.startIndex;
            int number = random.Next() % interval;
            number += offset;
            chosenSet = sets[number];
            pokedexNumber = BFsetToPokedexNumber(chosenSet);
        }

        private int BFsetToPokedexNumber(BattleFactorySet bfSet)
        {
            foreach (Pokemon p in pokemons)
            {
                if (p.Name == bfSet.PokemonName)
                {
                    return p.PokedexNumber;
                }
            }

            return 0;
        }
    }
}
