using BattleFactoryBlindPracticer.Model;
using Microsoft.AspNetCore.Components;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class MoveListComponent
    {
        [Parameter]
        public bool IsGuessable { get; set; } = false;

        [Parameter]
        public string[] Moves { get; set; } = { "None", "None", "None", "None" };

        private List<string> AllMoves = new();

        private GuessComponent Move1 = new();
        private GuessComponent Move2 = new();
        private GuessComponent Move3 = new();
        private GuessComponent Move4 = new();

        private void ConfirmClick()
        {
            Move1.HandleGuessCheck();
            Move2.HandleGuessCheck();
            Move3.HandleGuessCheck();
            Move4.HandleGuessCheck();
        }

        protected override async Task OnInitializedAsync()
        {
            AllMoves = await DataGetter.GetOptionList(_client, "Move");
        }
    }
}
