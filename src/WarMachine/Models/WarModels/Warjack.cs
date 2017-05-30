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
        public string FA { get; set; }


    }
}
