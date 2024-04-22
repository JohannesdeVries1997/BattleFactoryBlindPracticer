using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class CryButton
    {
        [Parameter]
        public int pokedexNumber { get; set; } = 0;

        [Parameter]
        public bool IsDisabled { get; set; } = false;

        private string audioId { get; set; } = "sound";

        private bool disabled { get; set; } = false;

        private string SourceString { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            disabled = IsDisabled;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            SourceString = $"{navManager.BaseUri}/Resources/Cries/{pokedexNumber}.mp3";
            audioId += pokedexNumber.ToString();
            StateHasChanged();
        }

        public void EnableButton()
        {
            disabled = false;
            StateHasChanged();
        }
    }
}
