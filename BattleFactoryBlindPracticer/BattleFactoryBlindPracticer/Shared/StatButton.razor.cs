using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class StatButton
    {
        [Parameter]
        public string Stat { get; set; } = string.Empty;

        [Parameter]
        public EventCallback<string> OnButtonPressed { get; set; }

        private bool On = false;

        private string buttonClass = "unpressed";
        
        private void HandleClick()
        {
            if(On)
            {
                On = false;
                buttonClass = "unpressed";
            }
            else
            {
                On = true;
                buttonClass = "pressed";
            }
            OnButtonPressed.InvokeAsync(Stat);
        }
    }
}
