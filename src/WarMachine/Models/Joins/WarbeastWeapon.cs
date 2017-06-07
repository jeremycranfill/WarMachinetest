using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarbeastWeapon
    {
        public int WarbeastID { get; set; }
        public WarBeast Warbeast { get; set; }

        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }

    }
}
