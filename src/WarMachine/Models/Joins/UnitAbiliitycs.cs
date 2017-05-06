using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class UnitAbiliitycs
    {
        public int UnitID { get; set; }
        public UnitModel Unit { get; set; }

        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }
}
