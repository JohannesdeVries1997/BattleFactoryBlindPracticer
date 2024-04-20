using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class RoundSelectorButton
    {
        [Parameter]
        public int RoundNumber { get; set; } = 0;

        [Parameter]
        public EventCallback<int> OnRoundButtonClick { get; set; }

        private bool Pressed { get; set; } = false;

        private string styleString { get; set; } = "unpressed";

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if(Pressed)
            {
                styleString = "pressed";
            }
            else
            {
                styleString = "unpressed";
            }
            StateHasChanged();
        }

        public async Task OnClick()
        {
            Pressed = true;
            await OnRoundButtonClick.InvokeAsync(this.RoundNumber);
        }

        public void Unpress()
        {
            Pressed = false;
        }
    }
}
