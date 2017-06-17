using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



    }
}
