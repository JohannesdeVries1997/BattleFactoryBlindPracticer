using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class RoundSelectorButton
    {
        [Parameter]
        public int RoundNumber { get; set; } = 0;

        public EventCallback<int> EventCallback { get; set; } = new();

        private string styleString = "unpressed";

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void OnClick()
        {
            EventCallback.InvokeAsync(this.RoundNumber);
            styleString = "pressed";
            StateHasChanged();
        }

        public void Unpress()
        {
            styleString = "unpressed";
            StateHasChanged();
        }
    }
}
