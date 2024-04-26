using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class AbilityComponent
    {
        [Parameter]
        public string Ability1 { get; set; } = string.Empty;

        [Parameter]
        public string Ability2 { get; set; } = string.Empty;

        [Parameter]
        public bool IsGuessable { get; set; } = false;

        private bool confirmButtonDisabled = false;
        private List<string> autoCompleteList = new();

        private GuessComponent guessComponent1 = new();
        private GuessComponent guessComponent2 = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            confirmButtonDisabled = !IsGuessable;
            if (IsGuessable && Ability2 == "None")
            {
                guessComponent2.SetInputValue("None");
                guessComponent2.SetCorrect();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            autoCompleteList = await DataGetter.GetAllAbilities(_client);
        }

        private void HandleConfirm()
        {
            string[] options = { Ability1, Ability2 };
            guessComponent1.CheckCorrect(options);
            guessComponent2.CheckCorrect(options);
            confirmButtonDisabled = true;
        }
    }
}
