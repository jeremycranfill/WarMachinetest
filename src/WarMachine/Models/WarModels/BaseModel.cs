using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.Models.WarModels
{
    public class BaseModel
    {
        public string Faction { get; set; }
        public string Name { get; set; }
        //public IList<Weapon> Weapons { get; set; }
        //public IList<Spell> Spells { get; set; }
        //public IList<Ability> Abilities { get; set; }

        public  int SPD { get; set; }
        public int STR { get; set; }
        public int MAT { get; set; }
        public int RAT { get; set; }
        public int DEF { get; set; }
        public int ARM { get; set; }
        public int CMD { get; set; }
        public int ID { get; set; }
        public int PointCost { get; set; }



    }

    }

