using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarbeastSpell
    {
        public int WarbeastId { get; set; }
        public WarBeast Warbeast { get; set; }

        public int Spellid { get; set; }
        public Spell Spell { get; set; }



    }
}
