using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class Warjack : BaseModel
    {
        public enum Sizes { Light, Heavy, Colossal }
        public Sizes Size { get; set; }


        override public IList<String> GetProps()

        {
            IList<string> Props =
                new[] { "Name", "SPD", "STR", "MAT", "RAT", "DEF", "ARM", "CMD", "PointCost","Size", "FA", "factionName" };
            return Props;


        }






    }
}
