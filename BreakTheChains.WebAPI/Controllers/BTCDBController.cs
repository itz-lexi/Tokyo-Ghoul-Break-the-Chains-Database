using Microsoft.AspNetCore.Mvc;
using BreakTheChains.Framework.Models;

namespace BreakTheChains.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreakTheChainsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CharacterModel> GetCharacters()
        {
            return new CharacterModel
            {
                Name = "Kaneki Ken",
            };
        }
    }
}
