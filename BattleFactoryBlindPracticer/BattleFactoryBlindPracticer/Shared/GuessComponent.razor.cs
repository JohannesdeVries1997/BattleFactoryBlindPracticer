using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BattleFactoryBlindPracticer.Model;

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
            switch (args.Code)
            {
                case "Enter":
                    OnEnterPressed.InvokeAsync();
                    break;
                case "NumpadEnter":
                    OnEnterPressed.InvokeAsync();
                    break;
                case "Tab":
                    TakeFirstAutocomplete();
                    break;
            }
        }

        public string GetInputValue()
        {
            return inputValue;
        }

        public void SetInputValue(string value)
        {
            inputValue = value;
        }

        public void SetCorrect()
        {
            ShowAnswer();
            SetStyleCorrect();
        }

        public void SetIncorrect()
        {
            ShowAnswer();
            SetStyleInCorrect();
        }

        private void ShowAnswer()
        {
            inputBoxDisabled = true;
            displayedValue = GuessString;
            StateHasChanged();
        }

        private bool IsCorrect()
        {
            return StringHelper.CompareStrings(_inputValue, GuessString);
        }

        private void SetStyleCorrect()
        {
            SetInputBoxStyle("border-color: lightgreen");
        }

        private void SetStyleInCorrect()
        {
            SetInputBoxStyle("border-color: salmon");
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

        private void TakeFirstAutocomplete()
        {
            inputValue = autoCompleteList.FirstOrDefault() ?? inputValue;
            StateHasChanged();
        }
    }
}
