using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarcasterSpell
    {
        public int SpellId { get; set; }
        public Spell Spell { get; set; }

        public int WarcasterId { get; set; }
        public Warcaster Warcaster { get; set; }

    }
}
