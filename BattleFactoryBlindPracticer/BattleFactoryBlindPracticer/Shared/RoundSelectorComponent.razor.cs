using Microsoft.AspNetCore.Components;
using System.Data;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class RoundSelectorComponent
    {
        [Parameter]
        public EventCallback<int> OnRoundButtonClicked { get; set; }

        [Parameter]
        public int InitialRoundSelected { get; set; } = 0;
        private int roundSelected { get; set; } = 0;

        private RoundSelectorButton button1 { get; set; } = new();
        private RoundSelectorButton button2 { get; set; } = new();
        private RoundSelectorButton button3 { get; set; } = new();
        private RoundSelectorButton button4 { get; set; } = new();
        private RoundSelectorButton button5 { get; set; } = new();
        private RoundSelectorButton button6 { get; set; } = new();

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(roundSelected == 0)
            {
                PressInitialSelectedButton();
            }
        }

        private async Task HandleRoundButtonClick(int roundNumber)
        {
            roundSelected = roundNumber;
            await OnRoundButtonClicked.InvokeAsync(roundNumber);
            UnpressButtonsExcept(roundNumber);
        }

        private void UnpressButtonsExcept(int roundNumber)
        {
            if (button1.RoundNumber != roundNumber) button1.Unpress();
            if (button2.RoundNumber != roundNumber) button2.Unpress();
            if (button3.RoundNumber != roundNumber) button3.Unpress();
            if (button4.RoundNumber != roundNumber) button4.Unpress();
            if (button5.RoundNumber != roundNumber) button5.Unpress();
            if (button6.RoundNumber != roundNumber) button6.Unpress();
        }

        private void PressInitialSelectedButton()
        {
            switch (InitialRoundSelected)
            {
                case 1:
                    button1.Press();
                    break;
                case 2:
                    button2.Press();
                    break;
                case 3:
                    button3.Press();
                    break;
                case 4:
                    button4.Press();
                    break;
                case 5:
                    button5.Press();
                    break;
                case 6:
                    button6.Press();
                    break;
            }
        }
    }
}
