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
        public IList<WarjackWeapon> WarjackWeapons { get; set; }
        public IList<WarbeastWeapon> WarbeastWeapons {get; set;}
        public IList<WarlockWeapon> WarlockWeapons { get; set; }
        public IList<WarcasterWeapon> WarcasterWeapons { get; set; }

        public enum WeaponType {Ranged, Melee }

        public string Name { get; set; }
        public int RNG { get; set; }
        public int POW { get; set; }
        public WeaponType Type { get; set; }
        public int ID { get; set; }
        public int ROF { get; set; }



         public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "RNG", "POW", "Type", "ROF" };
            return Props;


        }







    }
}
