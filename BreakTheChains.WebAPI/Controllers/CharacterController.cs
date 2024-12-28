using Microsoft.AspNetCore.Mvc;
using BreakTheChains.Framework.Models;
using BreakTheChains.Framework.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakTheChains.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetCharacters")]
        public async Task<List<CharacterModel>> GetCharacters()
        {
            List<CharacterModel> characterList = await _characterService.GetCharacters();
            return characterList;
        }
    }
}
