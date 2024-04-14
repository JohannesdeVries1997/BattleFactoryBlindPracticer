using PokemonJSONTool.CSVStrategy;
using PokemonJSONTool.JSONStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.PokemonDataStrategy
{
    internal class PokemonMovesStrategy : IPokemonDataStategy
    {
        public void ConvertDataToJson(ICSVStrategy csvStrategy, IJSONStrategy jSONStrategy, string csvFilePath, string jsonSavePath)
        {
            var csvData = csvStrategy.Load(csvFilePath);
            csvData.RemoveAt(0);
            List<string> result = new();

            foreach(string str in csvData)
            {
                var moveData = str.Split(';');
                result.Add(moveData[0]);
            }

            jSONStrategy.SaveJSON(jsonSavePath, result);
        }
    }
}
