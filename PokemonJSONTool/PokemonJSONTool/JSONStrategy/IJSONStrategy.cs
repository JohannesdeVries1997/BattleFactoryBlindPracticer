using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PokemonJSONTool.NewFolder
{
    public interface IJSONStrategy
    {
        public void SaveJSON(string fileName);
    }
}
