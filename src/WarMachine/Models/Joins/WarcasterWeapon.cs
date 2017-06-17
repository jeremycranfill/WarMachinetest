using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class WarcasterWeapon
    {
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }

        public int WarcsaterId { get; set; }
        public Warcaster Warcaster { get; set; }

    }
}
