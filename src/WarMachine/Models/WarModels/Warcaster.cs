using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Warcaster : BaseModel
    {

        public IList<WarcasterAbility> WarcasterAbillities { get; set; }
        public IList<WarcasterSpell> WarcasterSpells{ get; set; }
        public IList<WarcasterWeapon> WarcasterWeapons { get; set; }



        public int Focus { get; set; }
        public int WarjackPoints { get; set; }
        public string Feat { get; set; }



        override public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost","Focus","WarjackPoints","Feat", "FA", "factionName" };
            return Props;


        }

        public override void Delete(ModelDbContext context)
        {

            context.Warcasters.Remove(context.Warcasters.SingleOrDefault(c => c.ID == this.ID));


            var soloAbils = (context.WarcasterAbilities.Where(c => c.WarcasterId == ID));

            foreach (var abil in soloAbils)
            {
                context.WarcasterAbilities.Remove(abil);
            }



            var soloSpells = (context.WarcasterSpells.Where(c => c.WarcasterId == ID));

            foreach (var spell in soloSpells)
            {
                context.WarcasterSpells.Remove(spell);

            }

            var soloWeaps = (context.WarcasterWeapons.Where(c => c.WarcsaterId == ID));

            foreach (var weap in soloWeaps)
            {

                context.WarcasterWeapons.Remove(weap);

            }

            context.SaveChanges();

        }

    }
}
