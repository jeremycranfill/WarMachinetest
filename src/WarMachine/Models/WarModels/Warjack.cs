using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Warjack : BaseModel
    {
        public enum Sizes { Light, Heavy, Colossal }
        public Sizes Size { get; set; }



        public IList<WarjackAbillity> WarjackAbilities { get; set; }
        public IList<WarjackWeapon> WarjackWeapons { get; set; }







        override public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost","Size", "FA", "factionName" };
            return Props;


        }


        public override void Delete(ModelDbContext context)
        {

            context.Warjacks.Remove(context.Warjacks.SingleOrDefault(c => c.ID == this.ID));


            var soloAbils = (context.WarjackAbilities.Where(c => c.WarjackID == ID));

            foreach (var abil in soloAbils)
            {
                context.WarjackAbilities.Remove(abil);
            }


                       

            var soloWeaps = (context.WarjackWeapons.Where(c => c.WarjackId == ID));

            foreach (var weap in soloWeaps)
            {

                context.WarjackWeapons.Remove(weap);

            }

            context.SaveChanges();

        }



    }
}
