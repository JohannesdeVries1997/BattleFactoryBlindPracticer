using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class SpriteComponent
    {
        [Parameter]
        public int pokedexNumber { get; set; } = 0;

        [Parameter]
        public int Height { get; set; } = 64;

        [Parameter]
        public int Width { get; set; } = 64;

        [Parameter]
        public bool IsShown { get; set; } = true;

        private string sourceString { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            sourceString = $"{navManager.BaseUri}Resources/Sprites/spr_rs_000.png";
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (IsShown)
            {
                ShowSprite();
            }
        }

        public void ShowSprite()
        {
            sourceString = $"{navManager.BaseUri}Resources/Sprites/spr_rs_{DexNumberToString(pokedexNumber)}.png";
            StateHasChanged();
        }

        private string DexNumberToString(int pokedexNumber)
        {
            string result = string.Empty;
            if (pokedexNumber < 100) result += "0";
            if (pokedexNumber < 10) result += "0";
            result += pokedexNumber.ToString();
            return result;
        }
    }
}
