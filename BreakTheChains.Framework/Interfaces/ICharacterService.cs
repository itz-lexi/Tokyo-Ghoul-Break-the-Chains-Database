using System.Collections.Generic;
using System.Threading.Tasks;
using BreakTheChains.Framework.Models;

namespace BreakTheChains.Framework.Interfaces
{
    public interface ICharacterService
    {
        Task<List<CharacterModel>> GetCharacters();
    }
}
