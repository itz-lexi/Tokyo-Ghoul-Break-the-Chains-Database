using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakTheChains.DataAccess;
using BreakTheChains.DataAccess.Entities;
using BreakTheChains.Framework.Interfaces;
using BreakTheChains.Framework.Models;
using Microsoft.EntityFrameworkCore;

namespace BreakTheChains.Framework.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly BreakTheChainsDBContext _context;

        public CharacterService(BreakTheChainsDBContext context)
        {
            _context = context;
        }

        public async Task<List<CharacterModel>> GetCharacters()
        {
            var characters = await _context.Characters
                .Select(c => new CharacterModel
                {
                    Id = c.id,
                    Name = c.name,
                    Nickname = c.nickname,
                    Rarity = c.rarity,
                    Type = c.type
                })
                .ToListAsync();

            return characters;
        }
    }
}
