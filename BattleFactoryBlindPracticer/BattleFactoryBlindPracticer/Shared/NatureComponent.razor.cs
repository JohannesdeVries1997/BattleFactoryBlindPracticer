using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class NatureComponent
    {
        [Parameter]
        public string Nature { get; set; } = string.Empty;

        [Parameter]
        public bool IsGuessable { get; set; } = false;

        private GuessComponent guessComponent = new();
        private List<string> autoCompleteList = new();

        private bool confirmButtonDisabled = false;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            confirmButtonDisabled = !IsGuessable;
        }

        protected async override Task OnInitializedAsync()
        {
            autoCompleteList = await DataGetter.GetOptionList(_client, "Nature");
        }

        private void HandleConfirm()
        {
            guessComponent.HandleGuessCheck();
            confirmButtonDisabled = true;
        }
    }
}