using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.Joins
{
    public class SoloWeapon
    { 
        public int SoloID { get; set; }
        public SoloModel Solo { get; set; }

        public int WeaponID { get; set; }
        public Weapon Weapon { get; set; }



    }
}
