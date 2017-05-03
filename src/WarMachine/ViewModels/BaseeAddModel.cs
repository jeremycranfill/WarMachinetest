using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.ViewModels
{
    public class BaseeAddModel
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int SPD { get; set; }

        [Required]
        public int STR { get; set; }

        [Required]
        public int MAT { get; set; }

        [Required]
        public int RAT { get; set; }

        [Required]
        public int DEF { get; set; }

        [Required]
        public int ARM { get; set; }

        [Required]
        public int CMD { get; set; }
        
        [Required]
        public int PointCost { get; set; }

    }
}
