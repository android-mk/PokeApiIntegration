using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeApiIntegration.Models
{
    public class PokemonResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<PokemonAbility> Abilities { get; set; }
    }

    public class PokemonAbility
    {
        [JsonPropertyName("ability")]
        public Ability Ability { get; set; }

        [JsonPropertyName("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonPropertyName("slot")]
        public int Slot { get; set; }
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}