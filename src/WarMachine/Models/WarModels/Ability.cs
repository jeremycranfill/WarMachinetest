using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Ability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SoloAbility> SoloAbilities { get; set; }



    }
}
