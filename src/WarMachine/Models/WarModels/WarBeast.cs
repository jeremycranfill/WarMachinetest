using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class WarBeast : BaseModel
    {


         public IList<WarbeastSpell> WarbeastSpells { get; set; }
        public IList<WarbeastWeapon> WarbeastWeapons { get; set; }
        public IList<WarBeastAbillity> WarbeastAbiliities {get; set;}


        public enum sizes {Lesser, Light, Heavy, Pack }
        public sizes Size { get; set; }
        public int Fury { get; set; }
        public int Threshhold { get; set; }

        override public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost","Size","Fury","Threshhold", "FA", "factionName" };
            return Props;


        }


        public override void Delete(ModelDbContext context)
        {

            context.WarBeasts.Remove(context.WarBeasts.SingleOrDefault(c => c.ID == this.ID));


            var soloAbils = (context.WarbeastAbillities.Where(c => c.WarBeastid == ID));

            foreach (var abil in soloAbils)
            {
                context.WarbeastAbillities.Remove(abil);
            }



            var soloSpells = (context.WarbeastSpells.Where(c => c.WarbeastId == ID));

            foreach (var spell in soloSpells)
            {
                context.WarbeastSpells.Remove(spell);

            }

            var soloWeaps = (context.WarbeastWeapons.Where(c => c.WarbeastID == ID));

            foreach (var weap in soloWeaps)
            {

                context.WarbeastWeapons.Remove(weap);

            }

            context.SaveChanges();

        }


    }
}
