using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.ViewModels
{
    public class AddWeaponViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int RNG { get; set; }
        [Required]
        public int POW { get; set; }
        //TODO enum of some type maybe
        [Required]
        public string Type { get; set; }
      
        public int ROF { get; set; }





    }
}

