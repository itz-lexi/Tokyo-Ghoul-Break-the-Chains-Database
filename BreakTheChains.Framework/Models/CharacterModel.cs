using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakTheChains.Framework.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Rarity { get; set; }
        public int Type { get; set; }
    }
}
