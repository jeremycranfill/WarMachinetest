using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarjackAbillity
    {
        public int WarjackID { get; set; }
        public Warjack Warjack { get; set; }

        public int AbillityID { get; set; }
        public Ability Abillity { get; set; }

    }
}
 