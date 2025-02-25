using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PokeApiIntegration.Models;

namespace PokeApiIntegration.Services
{
    public class PokeApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PokeApiService> _logger;

        public PokeApiService(HttpClient httpClient, ILogger<PokeApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<PokemonResponse> GetPokemonAsync(string name)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Raw JSON Response: {Content}", content); // Log the raw JSON

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<PokemonResponse>(content, options);
        }
    }
}