using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class Faction
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public ICollection<SoloModel> Solos;
        public ICollection<UnitModel> Units;
        public ICollection<WarBeast> Beats;
        public ICollection<Warjack> Jacks;


        //TODO Themes
        //TODO Hordes / Warmachine 
    }
}
