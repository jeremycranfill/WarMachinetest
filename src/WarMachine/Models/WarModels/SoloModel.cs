using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class SoloModel : BaseModel
    {
       
       public IList<SoloAbility> SoloAbilities { get; set; }
        public IList<SoloSpell> SoloSpells { get; set; }
        public IList<SoloWeapon> SoloWeapons { get; set; }

        public override void Delete(ModelDbContext context)
        {

            context.Solos.Remove(context.Solos.SingleOrDefault(c => c.ID == this.ID));


            var soloAbils = (context.SoloAbilities.Where(c => c.SoloID == ID));

            foreach (var abil in soloAbils)
            {
                context.SoloAbilities.Remove(abil);
            }



            var soloSpells = (context.SoloSpells.Where(c => c.SoloID == ID));

            foreach (var spell in soloSpells)
            {
                context.SoloSpells.Remove(spell);

            }

            var soloWeaps = (context.SoloWeapons.Where(c => c.SoloID == ID));

            foreach(var weap in soloWeaps)
            {

                context.SoloWeapons.Remove(weap);

            }

            context.SaveChanges();

        }



    }



}
