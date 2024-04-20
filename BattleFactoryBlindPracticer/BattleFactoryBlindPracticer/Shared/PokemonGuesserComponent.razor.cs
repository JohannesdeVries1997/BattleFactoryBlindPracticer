using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class PokemonGuesserComponent
    {
        [Parameter]
        public int AnswerPokedexNumber { get; set; } = 0;

        [Parameter]
        public List<Pokemon> Pokemons { get; set; } = new();

        private Pokemon answerPokemon { get; set; } = new();
        private Pokemon guessPokemon { get; set; } = new();
        private List<string> optionList { get; set; } = new();

        private SpriteComponent pokemonGuess_SpriteComponent { get; set; } = new();
        private CryButton pokemonGuess_CryButton { get; set; } = new();
        private TypeImageComponent pokemonGuess_TypeImageComponent1 { get; set; } = new();
        private TypeImageComponent pokemonGuess_TypeImageComponent2 { get; set; } = new();

        private SpriteComponent pokemonAnswer_SpriteComponent { get; set; } = new();
        private CryButton pokemonAnswer_CryButton { get; set; } = new();
        private TypeImageComponent pokemonAnswer_TypeImageComponent1 { get; set; } = new();
        private TypeImageComponent pokemonAnswer_TypeImageComponent2 { get; set; } = new();

        private GuessComponent pokemonNameGuessComponent { get; set; } = new();
        private bool ConfirmDisabled = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            guessPokemon.GetEmptyPokemon();
        }
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (Pokemons.TryGetPokemonByDexNumber(AnswerPokedexNumber, out Pokemon pokemon))
            {
                answerPokemon = pokemon;
            }
            else
            {
                answerPokemon.Type1 = "None";
                answerPokemon.Type2 = "None";
            }
            CreateOptionList();
            StateHasChanged();
        }

        private void CreateOptionList()
        {
            optionList.Clear();
            foreach (Pokemon p in Pokemons)
            {
                optionList.Add(p.Name);
            }
        }

        private void ConfirmClick()
        {
            pokemonNameGuessComponent.HandleGuessCheck();
            if (Pokemons.TryGetPokemonByName(pokemonNameGuessComponent.GetInputValue(), out Pokemon pokemon))
            {
                guessPokemon = pokemon;
            }
            ShowGuess();
            RevealAnswer();
            ConfirmDisabled = true;
            StateHasChanged();
        }

        private void RevealAnswer()
        {
            pokemonAnswer_SpriteComponent.ShowSprite();
            pokemonAnswer_TypeImageComponent1.ShowType();
            pokemonAnswer_TypeImageComponent2.ShowType();
        }

        private void ShowGuess()
        {
            pokemonGuess_SpriteComponent.ShowSprite();
            pokemonGuess_CryButton.EnableButton();
            pokemonGuess_TypeImageComponent1.ShowType();
            pokemonGuess_TypeImageComponent2.ShowType();
        }
    }
}
