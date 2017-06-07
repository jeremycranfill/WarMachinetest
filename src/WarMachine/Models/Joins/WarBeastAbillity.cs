using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarBeastAbillity
    {
        public int WarBeastid { get; set; }
        public WarBeast WarBeast { get; set; }

        public int AbillityId { get; set; }
        public Ability Ability { get; set; }

    }
}
