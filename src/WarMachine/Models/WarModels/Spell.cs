using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class Spell
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string RNG { get; set; }
        public int AOE { get; set; }
        public int POW { get; set; }
        public string Duration { get; set; }
        public bool OFF { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    }
}