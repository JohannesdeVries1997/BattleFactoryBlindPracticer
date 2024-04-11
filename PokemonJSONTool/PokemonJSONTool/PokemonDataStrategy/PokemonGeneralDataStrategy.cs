using PokemonJSONTool.CSVStrategy;
using PokemonJSONTool.JSONStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonJSONTool.Model;
using System.Reflection.Metadata.Ecma335;

namespace PokemonJSONTool.PokemonDataStrategy
{
    public class PokemonGeneralDataStrategy : IPokemonDataStategy
    {
        public void ConvertDataToJson(ICSVStrategy csvStrategy, IJSONStrategy jSONStrategy, string csvFilePath, string jsonSavePath)
        {
            List<Pokemon> pokemonList = new();

            List<string> generalData = csvStrategy.Load(csvFilePath);

            bool isHeader = true;

            foreach (var item in generalData)
            {
                if(isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] pokemonData = item.Split(';');

                if( pokemonData.Length !=  12) 
                {
                    Console.WriteLine($"Data line is not the correct length: {pokemonData.Length} items");
                    continue;
                }

                pokemonList.Add(MakePokemon(pokemonData));
            }

            jSONStrategy.SaveJSON(jsonSavePath, pokemonList);
        }

        private Pokemon MakePokemon(string[] pokemonData)
        {
            var pokemon = new Pokemon();

            if (!int.TryParse(pokemonData[0], out int id))
            {
                Console.WriteLine($"Failed to parse id:{pokemonData[0]}");
            }
            pokemon.PokedexNumber = id;

            pokemon.Name = pokemonData[1];

            if (!Enum.TryParse(pokemonData[2], out PokemonType type1))
            {
                Console.WriteLine($"Failed to parse pokemonType:{pokemonData[2]}");
            }
            if (!Enum.TryParse(pokemonData[3], out PokemonType type2))
            {
                Console.WriteLine($"Failed to parse pokemonType:{pokemonData[3]}");
            }
            pokemon.Type1 = type1;
            pokemon.Type2 = type2;

            if (!int.TryParse(pokemonData[4], out int hp))
            {
                Console.WriteLine($"Failed to parse hp:{pokemonData[4]}");
            }
            if (!int.TryParse(pokemonData[5], out int att))
            {
                Console.WriteLine($"Failed to parse att:{pokemonData[5]}");
            }
            if (!int.TryParse(pokemonData[6], out int def))
            {
                Console.WriteLine($"Failed to parse def:{pokemonData[6]}");
            }
            if (!int.TryParse(pokemonData[7], out int spatt))
            {
                Console.WriteLine($"Failed to parse spatt:{pokemonData[7]}");
            }
            if (!int.TryParse(pokemonData[8], out int spdef))
            {
                Console.WriteLine($"Failed to parse spdef:{pokemonData[8]}");
            }
            if (!int.TryParse(pokemonData[9], out int spe))
            {
                Console.WriteLine($"Failed to parse spe:{pokemonData[9]}");
            }
            pokemon.HP = hp;
            pokemon.Att = att;
            pokemon.Def = def;
            pokemon.SpAtt = spatt;
            pokemon.SpDef = spdef;
            pokemon.Spe = spe;

            if (!Enum.TryParse(pokemonData[10], out Ability ability1))
            {
                Console.WriteLine($"Failed to parse Ability:{pokemonData[10]}");
            }
            if (!Enum.TryParse(pokemonData[11], out Ability ability2))
            {
                Console.WriteLine($"Failed to parse Ability:{pokemonData[11]}");
            }
            pokemon.Ability1 = ability1;
            pokemon.Ability2 = ability2;

            return pokemon;
        }
    }
}
