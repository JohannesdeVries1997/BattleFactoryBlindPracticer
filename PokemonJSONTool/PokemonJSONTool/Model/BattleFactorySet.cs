using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.Model
{
    public class BattleFactorySet
    {
        public string PokemonName { get; set; } = string.Empty;

        public string[] Moves { get; set; } = new string[4];

        public string Item { get; set; } = string.Empty;

        public string Nature { get; set; } = string.Empty;

        public int HPEv { get; set; }
        public int AttEv { get; set; }
        public int DefEv { get; set; }
        public int SpAttEv { get; set; }
        public int SpDefEv { get; set; }
        public int SpeEv { get; set; }
    }
}
