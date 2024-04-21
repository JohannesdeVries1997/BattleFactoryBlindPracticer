using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class GuessComponent
    {
        [Parameter]
        public bool IsGuessable { get; set; } = false;

        private bool inputBoxDisabled = true;

        [Parameter]
        public EventCallback OnEnterPressed { get; set; }

        [Parameter]
        public string GuessString { get; set; } = string.Empty;

        [Parameter]
        public List<string> OptionList { get; set; } = new();

        private List<string> autoCompleteList { get; set; } = new();

        private string displayedValue = string.Empty;

        private string _inputValue { get; set; } = string.Empty;
        private string inputValue { get { return _inputValue; } set { _inputValue = value; UpdateAutoCompleteList(); } }

        private string inputBoxStyling = string.Empty;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            inputBoxDisabled = !IsGuessable;
            if (!IsGuessable)
            {
                ShowAnswer();
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            UpdateAutoCompleteList();
        }

        public void HandleGuessCheck()
        {
            ShowAnswer();
            if (IsCorrect())
            {
                SetInputBoxStyle("border-color: lightgreen");
            }
            else
            {
                SetInputBoxStyle("border-color: salmon");
            }
        }

        public void HandleOnKeyDown(KeyboardEventArgs args)
        {
            if (args.Code != "Enter" && args.Code != "NumpadEnter") return;
            OnEnterPressed.InvokeAsync();
        }

        public string GetInputValue()
        {
            return inputValue;
        }

        private void ShowAnswer()
        {
            inputBoxDisabled = true;
            displayedValue = GuessString;
            StateHasChanged();
        }

        private bool IsCorrect()
        {
            string inputLower = _inputValue.ToLower();
            string answerLower = GuessString.ToLower();
            return (inputLower == answerLower);
        }

        private void SetInputBoxStyle(string styling)
        {
            inputBoxStyling = styling;
            StateHasChanged();
        }


        private void UpdateAutoCompleteList()
        {
            string input = _inputValue.ToLower();
            autoCompleteList.Clear();
            foreach (string str in OptionList)
            {
                if (autoCompleteList.Count > 6) continue;

                var lowercase = str.ToLower();
                if (lowercase.StartsWith(input))
                {
                    autoCompleteList.Add(str);
                }
            }
            if (autoCompleteList.Count == 1 && _inputValue == autoCompleteList.FirstOrDefault()) autoCompleteList.Clear();
            StateHasChanged();
        }
    }
}
