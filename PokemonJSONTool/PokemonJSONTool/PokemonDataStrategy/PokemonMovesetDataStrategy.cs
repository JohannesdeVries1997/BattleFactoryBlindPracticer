using PokemonJSONTool.CSVStrategy;
using PokemonJSONTool.JSONStrategy;
using PokemonJSONTool.Model;
using PokemonJSONTool.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.PokemonDataStrategy
{
    public class PokemonMovesetDataStrategy : IPokemonDataStategy
    {
        public void ConvertDataToJson(ICSVStrategy csvStrategy, IJSONStrategy jSONStrategy, string csvFilePath, string jsonSavePath)
        {
            List<BattleFactorySet> battleFactorySets = new();
            List<string> data = csvStrategy.Load(csvFilePath);

            bool isHeader = true;
            foreach(var item in data)
            {
                if (isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] pokemonData = item.Split(';');

                if (pokemonData.Length != 14)
                {
                    Console.WriteLine($"Data line is not the correct length: {pokemonData.Length} items");
                    continue;
                }

                battleFactorySets.Add(CreateBattleFactorySet(pokemonData));
            }

            jSONStrategy.SaveJSON(jsonSavePath, battleFactorySets);
        }

        private BattleFactorySet CreateBattleFactorySet(string[] pokemonData)
        {
            var battleFactorySet = new BattleFactorySet();

            battleFactorySet.PokemonName = pokemonData[0];
            battleFactorySet.Moves = new string[]{ pokemonData[1], pokemonData[2], pokemonData[3], pokemonData[4]};
            battleFactorySet.Item = pokemonData[5];

            string increasedStat = pokemonData[6];
            string decreasedStat = pokemonData[7];
            string natureString = $"{StatEffectToNature(increasedStat, decreasedStat)}";
            if(increasedStat != "-")
            {
                natureString += $" ( +{increasedStat}, -{ decreasedStat})";
            }
            battleFactorySet.Nature = natureString;

            var evs = GetOrderedEvs(pokemonData.SubArray(8, 6));
            battleFactorySet.HPEv = evs[0];
            battleFactorySet.AttEv = evs[1];
            battleFactorySet.DefEv = evs[2];
            battleFactorySet.SpAttEv = evs[3];
            battleFactorySet.SpDefEv = evs[4];
            battleFactorySet.SpeEv = evs[5];

            return battleFactorySet;
        }

        private string StatEffectToNature(string increasedStat, string decreasedStat)
        {
            string[,] Natures =
            {   {"Hardy","Lonely","Adamant","Naughty","Brave"},
                {"Bold","Docile","Impish","Lax","Relaxed"},
                {"Modest","Mild","Bashful","Rash","Quiet"},
                {"Calm","Gentle","Careful","Quirky","Sassy"},
                {"Timid","Hasty","Jolly","Naive","Serious"}};

            return Natures[StatToIndex(increasedStat), StatToIndex(decreasedStat)];
        }

        private int StatToIndex(string stat)
        {
            int index = 0;
            switch (stat)
            {
                case "Atk":
                    index = 0;
                    break;
                case "Def":
                    index = 1;
                    break;
                case "SpAtk":
                    index = 2;
                    break;
                case "SpDef":
                    index = 3;
                    break;
                case "Speed":
                    index = 4;
                    break;
            }
            return index;
        }

        private int[] GetOrderedEvs(string[] EvData)
        {
            int[] evs = new int[]{0,0,0,0,0,0};

            int xCount = 0;
            for(int i = 0; i < EvData.Length; i++)
            {
                if (EvData[i] == "X")
                {
                    xCount++;
                    evs[i] = 1;
                }
            }

            for(int i = 0; i < evs.Length; i++)
            {
                evs[i] = evs[i] * 510 / xCount;
            }

            return evs;
        }
    }
}
