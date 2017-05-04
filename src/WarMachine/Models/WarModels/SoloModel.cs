using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class SoloModel : BaseModel
    {
        public int FA { get; set; }
       public IList<SoloAbility> SoloAbilities { get; set; }

    }
}
