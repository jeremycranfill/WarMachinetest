using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Warlock : BaseModel
    {

        public IList<WarlockWeapon> WarlockWeapons { get; set; }
        public IList<WarlockSpell> WarlockSpells { get; set; }
        public IList<WarlockAbillity> WarlockAbillities { get; set; }


        public int Fury { get; set; }
       public int WarbeastPoints { get; set; }
        public string Feat { get; set; }


        public override void Delete(ModelDbContext context)
        {

            context.Warlocks.Remove(context.Warlocks.SingleOrDefault(c => c.ID == this.ID));


            var soloAbils = (context.WarlockAbillities.Where(c => c.WarlockId == ID));

            foreach (var abil in soloAbils)
            {
                context.WarlockAbillities.Remove(abil);
            }



            var soloSpells = (context.WarlockSpells.Where(c => c.WarlockId == ID));

            foreach (var spell in soloSpells)
            {
                context.WarlockSpells.Remove(spell);

            }

            var soloWeaps = (context.WarlockWeapons.Where(c => c.WarlockId == ID));

            foreach (var weap in soloWeaps)
            {

                context.WarlockWeapons.Remove(weap);

            }

            context.SaveChanges();

        }

    }
}
