using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.ViewModels
{
    public class AddSpellViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }

        //TODO make this an enum possibly
        [Required]
        public string RNG { get; set; }
        [Required]
        public int AOE { get; set; }
        [Required]
        public int POW { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public bool OFF { get; set; }
        [Required]
        public string Description { get; set; }


    }
}
