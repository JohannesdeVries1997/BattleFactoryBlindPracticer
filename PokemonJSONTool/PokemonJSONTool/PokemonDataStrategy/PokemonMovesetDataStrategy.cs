﻿using PokemonJSONTool.CSVStrategy;
using PokemonJSONTool.JSONStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.PokemonDataStrategy
{
    public class PokemonMovesetDataStrategy : IPokemonDataStategy
    {
        public void ConvertDataToJson(ICSVStrategy csvStrategy, IJSONStrategy jSONStrategy, string csvFilePath, string jsonSavePath)
        {
            throw new NotImplementedException();
        }
    }
}
