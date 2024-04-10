using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonJSONTool.Helper
{
    public static class FileHelper
    {
        public static bool Exists(string? filePath)
        {
            if (filePath == null) return false;
            try
            {
                var file = new FileInfo(filePath);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
