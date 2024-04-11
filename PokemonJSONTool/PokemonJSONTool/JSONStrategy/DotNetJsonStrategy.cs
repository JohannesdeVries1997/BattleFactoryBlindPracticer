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
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                
            };
            string jsonString = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
