using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WarMachine.Models.WarModels.Weapon;

namespace WarMachine.ViewModels.Edit
{
    public class EditWeaponViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int RNG { get; set; }
        [Required]
        public int POW { get; set; }
        //TODO enum of some type maybe
        [Required]
        public WeaponType Type { get; set; }
      
        public int ROF { get; set; }

        public WeaponType WeaponType;

        public int Soloid { get; set; }





    }
}

