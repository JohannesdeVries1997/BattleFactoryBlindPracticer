using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.CSVStrategy
{
    public interface ICSVStrategy
    {
        public List<string> Load(string filePath);
    }
}
