using Microsoft.AspNetCore.Mvc;
using PokeApiIntegration.Services;
using System.Threading.Tasks;

namespace PokeApiIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly PokeApiService _pokeApiService;

        public PokemonController(PokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemon(string name)
        {
            var pokemonData = await _pokeApiService.GetPokemonAsync(name);
            return Ok(pokemonData);
        }
    }
}