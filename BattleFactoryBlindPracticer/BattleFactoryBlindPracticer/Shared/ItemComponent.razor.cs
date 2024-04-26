using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class ItemComponent
    {
        [Parameter]
        public string Item { get; set; } = string.Empty;

        [Parameter]
        public bool IsGuessable { get; set; } = false;

        private GuessComponent guessComponent { get; set; } = new();

        private bool confirmButtonDisabled = false;

        private List<string> autoCompleteList = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            confirmButtonDisabled = !IsGuessable;
        }

        protected override async Task OnInitializedAsync()
        {
            autoCompleteList = await DataGetter.GetOptionList(_client, "Item");
        }

        private void ConfirmClick()
        {
            confirmButtonDisabled = true;
            guessComponent.HandleGuessCheck();
        }
    }
}
