﻿using Microsoft.AspNetCore.Components;

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
        public bool IsGuessable { get; set; } = true;

        private string sourceString { get; set; } = $"/Resources/Sprites/spr_rs_000.png";

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (!IsGuessable)
            {
                ShowSprite();
            }
        }

        public void ShowSprite()
        {
            sourceString = $"/Resources/Sprites/spr_rs_{DexNumberToString(pokedexNumber)}.png";
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
