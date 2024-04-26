using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class AbilityComponent
    {
        [Parameter]
        public string[] Abilities { get; set; } = new string[2];

        [Parameter]
        public bool IsGuessable { get; set; } = false;
        private bool IsGuessable2 { get; set; } = false;

        private bool confirmButtonDisabled = false;
        private List<string> autoCompleteList = new();

        private GuessComponent ability1 = new();
        private GuessComponent ability2 = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            confirmButtonDisabled = !IsGuessable;
            if (Abilities[1] == "None")
            {
                IsGuessable2 = false;
                ability2.SetInputValue("None");
            }
            else
            {
                IsGuessable2 = IsGuessable;
            }
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            autoCompleteList = await DataGetter.GetAllAbilities(_client);
        }

        private void HandleConfirm()
        {
            ability1.CheckCorrect(Abilities);
            ability2.CheckCorrect(Abilities);
            confirmButtonDisabled = true;
        }
    }
}
