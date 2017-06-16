using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class Warcaster : BaseModel
    {
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
