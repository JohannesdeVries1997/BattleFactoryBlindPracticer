using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PokemonJSONTool.JSONStrategy
{
    public class DotNetJsonStrategy : IJSONStrategy
    {
        public void SaveJSON(string filePath, object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
