using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace Pokeapi{
    public class WebRequest
    {
        public static async Task GetPokemonDataAsync(int PokeId, Action<Pokemon> Callback){
            using (var Client = new HttpClient()){
                try {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response = await Client.GetAsync("");
                    Response.EnsureSuccessStatusCode();
                    string StringResponse = await Response.Content.ReadAsStringAsync();

                    JObject PokeInfo = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    JArray TypeList = PokeInfo["types"].Value<JArray>();
                    List<string> Types = new List<string>();

                    foreach(JObject x in TypeList)
                    {
                        Types.Add(x["type"]["name"].Value<string>());
                    }

                    Pokemon Pokestuff = new Pokemon{
                        Name = PokeInfo["name"].Value<string>(),
                        Weight = PokeInfo["weight"].Value<int>(),
                        Height = PokeInfo["height"].Value<int>(),
                        Types = Types,
                        Sprite = PokeInfo["sprites"]["front_default"].Value<string>()
                    };

                    Callback(Pokestuff);


                }

                catch (HttpRequestException e){
                    System.Console.WriteLine($"Request exeption: {e.Message}");
                }
            }
        }
    }
}