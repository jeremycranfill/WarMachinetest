using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Ability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SoloAbility> SoloAbilities { get; set; }
        public IList<UnitAbiliity> UnitAbillities { get; set; }
        public IList<WarBeastAbillity> WarbeastAbillities { get; set; }
        public IList<WarjackAbillity> WarjackAbillities { get; set; }
        public IList<WarcasterAbility> WarcasterAbillities { get; set; }
        public IList<WarlockAbillity> WarlockAbillities { get; set; }



        virtual public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "Description" };
            return Props;


        }


        public void Delete(ModelDbContext context)
        {

            context.Abilities.Remove(context.Abilities.SingleOrDefault(c => c.ID == this.ID));


            var soloAbility = context.SoloAbilities.Where(c => c.AbilityID == this.ID).ToList();

            foreach (var solo in soloAbility)
            {
                context.Remove(solo);

            }

            var unitAbility = context.UnitAbilities.Where(c => c.AbilityID == this.ID);

            foreach (var unit in unitAbility)
            {

                context.UnitAbilities.Remove(unit);

            }


            var warbeastAbility = context.WarbeastAbillities.Where(c => c.AbillityId == this.ID);

            foreach (var warbeast in warbeastAbility)
            { context.WarbeastAbillities.Remove(warbeast); }


            var warjackAbilitys = context.WarjackAbilities.Where(c => c.AbillityID == this.ID);


            foreach (var warjack in warjackAbilitys)
            { context.WarjackAbilities.Remove(warjack); }



            var casterAbilitys = context.WarcasterAbilities.Where(c => c.AbilityId == this.ID);

            foreach (var warcaster in casterAbilitys)
            { context.WarcasterAbilities.Remove(warcaster); }


            var warlockAbilitys = context.WarlockAbillities.Where(c => c.AbillityId == this.ID);

            foreach (var warlock in warlockAbilitys)
            { context.WarlockAbillities.Remove(warlock); }





            context.SaveChanges();





        }








    }
}
