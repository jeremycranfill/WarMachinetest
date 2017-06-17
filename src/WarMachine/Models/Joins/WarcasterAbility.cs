using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarcasterAbility
    {
        public int AbilityId { get; set; }
        public Ability Abillity { get; set; }

        public int WarcasterId { get; set; }
        public Warcaster Warcaster { get; set; }

    }
}
