using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class WarBeast : BaseModel
    {


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





    }
}
