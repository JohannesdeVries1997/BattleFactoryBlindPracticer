using System.IO;
using BattleFactoryBlindPracticer.Model;
using Newtonsoft.Json;

namespace BattleFactoryBlindPracticer.Model
{
    public static class PokemonFactory
    {
        public static async Task<List<Pokemon>> GetPokemonData(HttpClient _client)
        {
            var result = await _client.GetByteArrayAsync("Resources/PokemonGeneralData.json");
            var jsonString = System.Text.Encoding.Default.GetString(result);
            return JsonConvert.DeserializeObject<List<Pokemon>>(jsonString) ?? new List<Pokemon>();
        }

        public static async Task<List<BattleFactorySet>> GetBattleFactoryData(HttpClient _client)
        {
            var result = await _client.GetByteArrayAsync("Resources/BattleFactorySets.json");
            var jsonString = System.Text.Encoding.Default.GetString(result);
            return JsonConvert.DeserializeObject<List<BattleFactorySet>>(jsonString) ?? new List<BattleFactorySet>();
        }
    }
}
