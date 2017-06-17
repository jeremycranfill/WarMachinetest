using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarlockSpell
    {
        public int SpellId { get; set; }
        public Spell Spell { get; set; }

        public int WarlockId { get; set; }
        public Warlock Warlock { get; set; }

    }
}
