using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.Models.WarModels
{
    public class WarBeast : BaseModel
    {


        public enum size {Lesser, Light, Heavy, Pack }
        public int Fury { get; set; }
        public int Threshhold { get; set; }



    }
}
