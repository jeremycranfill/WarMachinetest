using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Weapon
    {
        public IList<SoloWeapon> SoloWeapons { get; set; }
        public IList<UnitWeapon> UnitWeapons { get; set; }

        public string Name { get; set; }
        public int RNG { get; set; }
        public int POW { get; set; }
        public string Type { get; set; }
        public int ID { get; set; }
        public int ROF { get; set; }
    }
}
