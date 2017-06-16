using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



    }
}
