using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class StatsComponent
    {
        [Parameter]
        public int HP { get; set; } = 0;
        private int guessedHP = 0;
        private string guessedHPClass = string.Empty;

        [Parameter]
        public int Att { get; set; } = 0;
        private int guessedAtt = 0;
        private string guessedAttClass = string.Empty;

        [Parameter]
        public int Def { get; set; } = 0;
        private int guessedDef = 0;
        private string guessedDefClass = string.Empty;

        [Parameter]
        public int SpAtt { get; set; } = 0;
        private int guessedSpAtt = 0;
        private string guessedSpAttClass = string.Empty;

        [Parameter]
        public int SpDef { get; set; } = 0;
        private int guessedSpDef = 0;
        private string guessedSpDefClass = string.Empty;

        [Parameter]
        public int Spe { get; set; } = 0;
        private int guessedSpe = 0;
        private string guessedSpeClass = string.Empty;

        [Parameter]
        public int HPEvs { get; set; } = 0;
        private int guessedHPEvs = 0;
        private string guessedHPEvsClass = string.Empty;

        [Parameter]
        public int AttEvs { get; set; } = 0;
        private int guessedAttEvs = 0;
        private string guessedAttEvsClass = string.Empty;

        [Parameter]
        public int DefEvs { get; set; } = 0;
        private int guessedDefEvs = 0;
        private string guessedDefEvsClass = string.Empty;

        [Parameter]
        public int SpAttEvs { get; set; } = 0;
        private int guessedSpAttEvs = 0;
        private string guessedSpAttEvsClass = string.Empty;

        [Parameter]
        public int SpDefEvs { get; set; } = 0;
        private int guessedSpDefEvs = 0;
        private string guessedSpDefEvsClass = string.Empty;

        [Parameter]
        public int SpeEvs { get; set; } = 0;
        private int guessedSpeEvs = 0;
        private string guessedSpeEvsClass = string.Empty;

        [Parameter]
        public bool ShowStats { get; set; } = true;

        [Parameter]
        public bool ShowEvs { get; set; } = true;

        [Parameter]
        public bool StatIsGuessable { get; set; } = true;

        [Parameter]
        public bool EvIsGuessable { get; set; } = false;

        private bool StatIsGuessed = false;

        private bool EvIsGuessed = false;

        private List<string> chosenEvs = new();

        private void HandleEvButtonClick(string stat)
        {
            if(chosenEvs.Contains(stat))
            {
                chosenEvs.Remove(stat);
            }
            else
            {
                chosenEvs.Add(stat);
            }
            SetEv(stat, 0, 1);
            UpdateEvs();
        }

        private void UpdateEvs()
        {
            foreach (string chosenEv in chosenEvs)
            {
                SetEv(chosenEv, 510, chosenEvs.Count);
            }
        }

        private void SetEv(string stat, int maxEvs, int divider)
        {
            switch (stat)
            {
                case "HP":
                    guessedHPEvs = maxEvs / divider;
                    break;
                case "Att":
                    guessedAttEvs = maxEvs / divider;
                    break;
                case "Def":
                    guessedDefEvs = maxEvs / divider;
                    break;
                case "SpAtt":
                    guessedSpAttEvs = maxEvs / divider;
                    break;
                case "SpDef":
                    guessedSpDefEvs = maxEvs / divider;
                    break;
                case "Spe":
                    guessedSpeEvs = maxEvs / divider;
                    break;
            }
        }

        private void HandleStatConfirm()
        {
            HandleGuessCheck(HP, guessedHP, ref guessedHPClass);
            HandleGuessCheck(Att, guessedAtt, ref guessedAttClass);
            HandleGuessCheck(Def, guessedDef, ref guessedDefClass);
            HandleGuessCheck(SpAtt, guessedSpAtt, ref guessedSpAttClass);
            HandleGuessCheck(SpDef, guessedSpDef, ref guessedSpDefClass);
            HandleGuessCheck(Spe, guessedSpe, ref guessedSpeClass);
            StatIsGuessed = true;
            StateHasChanged();
        }

        private void HandleGuessCheck(int answer, int guess, ref string styleClass)
        {
            if(answer == guess)
            {
                styleClass = "correct";
            }
            else
            {
                styleClass = "incorrect";
            }
        }

        private void HandleEvConfirm()
        {
            HandleGuessCheck(HPEvs, guessedHPEvs, ref guessedHPEvsClass);
            HandleGuessCheck(AttEvs, guessedAttEvs, ref guessedAttEvsClass);
            HandleGuessCheck(DefEvs, guessedDefEvs, ref guessedDefEvsClass);
            HandleGuessCheck(SpAttEvs, guessedSpAttEvs, ref guessedSpAttEvsClass);
            HandleGuessCheck(SpDefEvs, guessedSpDefEvs, ref guessedSpDefEvsClass);
            HandleGuessCheck(SpeEvs, guessedSpeEvs, ref guessedSpeEvsClass);
            EvIsGuessed = true;
            StateHasChanged();
        }
    }
}
