using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PokemonJSONTool.CSVStrategy
{
    internal class StreamReaderStrategy : ICSVStrategy
    {
        public List<string> Load(string filePath)
        {
            var reader = new StreamReader(filePath);
            var lines = new List<string>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(line != null) { lines.Add(line); }
            }

            return lines;
        }
    }
}
