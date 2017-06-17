using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarlockAbillity
    {
        public int AbillityId { get; set; }
        public Ability Abillity { get; set; }

        public int WarlockId { get; set; }
        public Warlock Warlock { get; set; }

    }
}
