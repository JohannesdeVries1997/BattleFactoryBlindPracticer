﻿using PokemonJSONTool.CSVStrategy;
using PokemonJSONTool.Helper;
using PokemonJSONTool.JSONStrategy;
using PokemonJSONTool.PokemonDataStrategy;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace PokemonJSONTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--Pokemon JSON File Tool--");
                Console.WriteLine("Which JSON do you want to update? : ");
                Console.WriteLine("Pokemon General Data: 1");
                Console.WriteLine("Pokemon Moveset Data: 2");
                Console.WriteLine("Pokemon Moves Data: 3");

                int option = GetOption();
                IPokemonDataStategy pokemonDataStategy;

                switch (option)
                {
                    case 1:
                        pokemonDataStategy = new PokemonGeneralDataStrategy();
                        break;
                    case 2:
                        pokemonDataStategy = new PokemonMovesetDataStrategy();
                        break;
                    case 3:
                        pokemonDataStategy = new PokemonMovesStrategy();
                        break;
                    default:
                        continue;
                }

                string csvFilePath = string.Empty;
                int tries = 0;
                while (tries < 5)
                {
                    Console.WriteLine("Specify where the data is saved...");
                    csvFilePath = Console.ReadLine() ?? string.Empty;

                    if (FileHelper.Exists(csvFilePath))
                    {
                        break;
                    }

                    Console.WriteLine("this is not a valid path, try again.");
                    csvFilePath = string.Empty;
                    tries++;
                }

                if(csvFilePath == string.Empty)
                {
                    ResetConsole();
                    continue;
                }
                csvFilePath = csvFilePath.RemoveQuoteMarks();

                string saveFilePath = string.Empty;
                Console.WriteLine("Specify where the data is saved...");
                saveFilePath = Console.ReadLine() ?? string.Empty;

                if (saveFilePath == string.Empty)
                {
                    ResetConsole();
                    continue;
                }
                saveFilePath = saveFilePath.RemoveQuoteMarks();

                ICSVStrategy csvStrategy = new StreamReaderStrategy();
                IJSONStrategy jsonStrategy = new NewtonSoftStrategy();
                pokemonDataStategy.ConvertDataToJson(
                    csvStrategy,
                    jsonStrategy,
                    csvFilePath,
                    saveFilePath);

                ResetConsole();
            }
        }

        private static int GetOption()
        {
            bool reading = true;
            while (reading)
            {
                var input = Console.ReadLine();
                if(int.TryParse(input, out int result))
                {
                    return result;
                }
            }
            return 0;
        }

        private static void ResetConsole()
        {
            Console.WriteLine("Resetting console, press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}