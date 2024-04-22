using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class TypeImageComponent
    {
        [Parameter]
        public string PokemonType { get; set; } = "None";

        [Parameter]
        public bool IsShown { get; set; } = false;

        private string sourceString { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            sourceString = $"{navManager.BaseUri}/Resources/Types/Unknown.png";
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (IsShown)
            {
                ShowType();
            }
        }

        public void ShowType()
        {
            sourceString = $"{navManager.BaseUri}/Resources/Types/{PokemonType}.png";
            StateHasChanged();
        }
    }
}
