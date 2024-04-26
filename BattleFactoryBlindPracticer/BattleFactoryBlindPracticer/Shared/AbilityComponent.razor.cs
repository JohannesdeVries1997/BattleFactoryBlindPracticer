using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class AbilityComponent
    {
        [Parameter]
        public Pokemon Pokemon { get; set; } = new();

        [Parameter]
        public bool IsGuessable { get; set; } = false;

        private bool confirmButtonDisabled = false;
        private List<string> autoCompleteList = new();

        private GuessComponent ability1 = new();
        private GuessComponent ability2 = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            confirmButtonDisabled = !IsGuessable;
            if (IsGuessable && Pokemon.Ability2 == "None")
            {
                ability2.SetInputValue("None");
                ability2.SetCorrect();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            autoCompleteList = await DataGetter.GetAllAbilities(_client);
        }

        private void HandleConfirm()
        {
            string[] options = { Pokemon.Ability1, Pokemon.Ability2 };
            ability1.CheckCorrect(options);
            ability2.CheckCorrect(options);
            confirmButtonDisabled = true;
        }
    }
}
