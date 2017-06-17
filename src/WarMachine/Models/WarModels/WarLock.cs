using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Warlock : BaseModel
    {

        public IList<WarlockWeapon> WarlockWeapons { get; set; }
        public IList<WarlockSpell> WarlockSpells { get; set; }
        public IList<WarlockAbillity> WarlockAbillities { get; set; }


        public int Fury { get; set; }
       public int WarbeastPoints { get; set; }
        public string Feat { get; set; }
       



    }
}
