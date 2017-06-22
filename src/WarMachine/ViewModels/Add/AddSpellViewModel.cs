using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static WarMachine.Models.WarModels.Spell;

namespace WarMachine.ViewModels
{
    public class AddSpellViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Cost { get; set; }

        [Required]
        public string RNG { get; set; }
        [Required]
        public AoeType AOE { get; set; }
        [Required]
        public int POW { get; set; }
        [Required]
        public DurationType Duration { get; set; }
        [Required]
        public bool OFF { get; set; }
        [Required]
        public string Description { get; set; }


    }
}
