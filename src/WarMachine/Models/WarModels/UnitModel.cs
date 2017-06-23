using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class UnitModel : BaseModel
    {
        public int MinUnit { get; set; }
        public int MaxUnit { get; set; }
       

        public IList<UnitSpell> UnitSpells { get; set; }
        public IList<UnitAbiliity> UnitAbillities { get; set; }
        public IList<UnitWeapon> UnitWeapons { get; set; }

        override public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost", "FA", "MinUnit","MaxUnit", "factionName" };
            return Props;


        }

        public override void Delete(ModelDbContext context)
        {

            context.Units.Remove(context.Units.SingleOrDefault(c => c.ID == this.ID));


            var UnitAbils = (context.UnitAbilities.Where(c => c.UnitID == ID));

            foreach (var abil in UnitAbils)
            {
                context.UnitAbilities.Remove(abil);
            }



            var UnitSpells = (context.UnitSpells.Where(c => c.UnitID == ID));

            foreach (var spell in UnitSpells)
            {
                context.UnitSpells.Remove(spell);

            }

            var UnitWeaps = (context.UnitWeapons.Where(c => c.UnitID == ID));

            foreach (var weap in UnitWeaps)
            {

                context.UnitWeapons.Remove(weap);

            }

            context.SaveChanges();

        }

    }
}
