using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Data;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Spell
    {
        public enum AoeType {None, One , Three , Four, Five };
        public enum DurationType {None , Rnd, Turn, Upkeep }

        public IList<SoloSpell> SoloSpells { get; set; }
        public IList<UnitSpell> UnitSpells { get; set; }       
        public IList<WarbeastSpell> WarBeastSpells { get; set; }
        public IList<WarlockSpell> WarlockSpells { get; set; }
        public IList<WarcasterSpell> WarcasterSpells { get; set; }




        public string Name { get; set; }
        public int Cost { get; set; }
        public string RNG { get; set; }
        public AoeType AOE { get; set; }
        public int POW { get; set; }
        public DurationType Duration { get; set; }
        public bool OFF { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public bool isAnimi { get; set; }






         public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "Cost", "RNG", "AOE", "POW", "Duration", "OFF", "Description" };
            return Props;


        }



        public void Delete(ModelDbContext context)
        {

            context.Spells.Remove(context.Spells.SingleOrDefault(c => c.ID == this.ID));


            var soloSpell = context.SoloSpells.Where(c => c.SpellID == this.ID).ToList();

            foreach (var solo in soloSpell)
            {
                context.Remove(solo);

            }

            var unitSpell = context.UnitSpells.Where(c => c.SpellID == this.ID);

            foreach (var unit in unitSpell)
            {

                context.UnitSpells.Remove(unit);

            }


            var warbeastSpell = context.WarbeastSpells.Where(c => c.Spellid == this.ID);

            foreach (var warbeast in warbeastSpell)
            { context.WarbeastSpells.Remove(warbeast); }


          



            var casterSpells = context.WarcasterSpells.Where(c => c.SpellId == this.ID);

            foreach (var warcaster in casterSpells)
            { context.WarcasterSpells.Remove(warcaster); }


            var warlockSpells = context.WarlockSpells.Where(c => c.SpellId == this.ID);

            foreach (var warlock in warlockSpells)
            { context.WarlockSpells.Remove(warlock); }





            context.SaveChanges();





        }






    }
}