using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.Joins;

namespace WarMachine.Models.WarModels
{
    public class Spell
    {
        public enum AoeType {None, One , Three , Four, Five };
        public enum DurationType {None , Rnd, Turn, Upkeep }

        public IList<SoloSpell> SoloSpells { get; set; }
        public IList<UnitSpell> UnitSpells { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string RNG { get; set; }
        public AoeType AOE { get; set; }
        public int POW { get; set; }
        public DurationType Duration { get; set; }
        public bool OFF { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    }
}