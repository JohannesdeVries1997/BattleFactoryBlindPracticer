using System.IO;
using BattleFactoryBlindPracticer.Model;
using Newtonsoft.Json;

namespace BattleFactoryBlindPracticer.Model
{
    public static class DataGetter
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

        /// <summary>
        /// Return a list of options for the autocomplete function.
        /// </summary>
        /// <param name="_client"></param>
        /// <param name="list">possible values: "Move", "Item", "Ability" , "Nature"</param>
        /// <returns></returns>
        public static async Task<List<string>> GetOptionList(HttpClient _client, string list)
        {
            var result = await _client.GetByteArrayAsync($"Resources/{list}List.json");
            var jsonString = System.Text.Encoding.Default.GetString(result);
            return JsonConvert.DeserializeObject<List<string>>(jsonString) ?? new List<string>();
        } 
    }
}
