using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BattleFactoryBlindPracticer.Shared
{
    public partial class StatsComponent
    {
        [Parameter]
        public int HP { get; set; } = 0;
        private int displayedHP = 0;

        [Parameter]
        public int Att { get; set; } = 0;
        private int displayedAtt = 0;

        [Parameter]
        public int Def { get; set; } = 0;
        private int displayedDef = 0;

        [Parameter]
        public int SpAtt { get; set; } = 0;
        private int displayedSpAtt = 0;

        [Parameter]
        public int SpDef { get; set; } = 0;
        private int displayedSpDef = 0;

        [Parameter]
        public int Spe { get; set; } = 0;
        private int displayedSpe = 0;

        [Parameter]
        public int HPEvs { get; set; } = 0;
        private int displayedHPEvs = 0;

        [Parameter]
        public int AttEvs { get; set; } = 0;
        private int displayedAttEvs = 0;

        [Parameter]
        public int DefEvs { get; set; } = 0;
        private int displayedDefEvs = 0;

        [Parameter]
        public int SpAttEvs { get; set; } = 0;
        private int displayedSpAttEvs = 0;

        [Parameter]
        public int SpDefEvs { get; set; } = 0;
        private int displayedSpDefEvs = 0;

        [Parameter]
        public int SpeEvs { get; set; } = 0;
        private int displayedSpeEvs = 0;

        [Parameter]
        public bool IsShown { get; set; } = true;

        [Parameter]
        public bool IsGuessable { get; set; } = true;

        private List<string> chosenEvs = new();

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (IsShown)
            {
                ShowStats();
            }
            if (!IsGuessable)
            {
                ShowEvs();
            }
        }

        private void ShowStats()
        {
            displayedHP = HP;
            displayedAtt = Att;
            displayedDef = Def;
            displayedSpAtt = SpAtt;
            displayedSpDef = SpDef;
            displayedSpe = Spe;
        }

        private void ShowEvs()
        {
            displayedHPEvs = HPEvs;
            displayedAttEvs = AttEvs;
            displayedDefEvs = DefEvs;
            displayedSpAttEvs = SpAttEvs;
            displayedSpDefEvs = SpDefEvs;
            displayedSpeEvs = SpeEvs;
        }

        private void HandleButtonClick(string stat)
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
                    displayedHPEvs = maxEvs / divider;
                    break;
                case "Att":
                    displayedAttEvs = maxEvs / divider;
                    break;
                case "Def":
                    displayedDefEvs = maxEvs / divider;
                    break;
                case "SpAtt":
                    displayedSpAttEvs = maxEvs / divider;
                    break;
                case "SpDef":
                    displayedSpDefEvs = maxEvs / divider;
                    break;
                case "Spe":
                    displayedSpeEvs = maxEvs / divider;
                    break;
            }
        }
    }
}
