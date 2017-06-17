﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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



    }
}
