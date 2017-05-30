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
        public string FA { get; set; }



    }
}
