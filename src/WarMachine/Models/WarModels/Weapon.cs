using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
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

        public void Delete(ModelDbContext context)
        {

            context.Weapons.Remove(context.Weapons.SingleOrDefault(c => c.ID == this.ID));


            var soloWeapon = context.SoloWeapons.Where(c => c.WeaponID == this.ID).ToList();

            foreach (var solo in soloWeapon)
            {
                context.Remove(solo);

            }

            var unitWeapon = context.UnitWeapons.Where(c => c.WeaponId == this.ID);

            foreach (var unit in unitWeapon)
            {

                context.UnitWeapons.Remove(unit);

            }


            var warbeastWeapon = context.WarbeastWeapons.Where(c => c.WeaponId == this.ID);

            foreach (var warbeast in warbeastWeapon)
            { context.WarbeastWeapons.Remove(warbeast); }


            var warjackWeapons = context.WarjackWeapons.Where(c => c.WeaponId == this.ID);


            foreach (var warjack in warjackWeapons)
            { context.WarjackWeapons.Remove(warjack); }



            var casterWeapons = context.WarcasterWeapons.Where(c => c.WeaponId == this.ID);

            foreach (var warcaster in casterWeapons)
            { context.WarcasterWeapons.Remove(warcaster); }


            var warlockWeapons = context.WarlockWeapons.Where(c => c.WeaponId == this.ID);

            foreach (var warlock in warlockWeapons)
            { context.WarlockWeapons.Remove(warlock); }





            context.SaveChanges();





        }





    }
}
