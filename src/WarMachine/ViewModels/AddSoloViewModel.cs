using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WarMachine.ViewModels
{
    public class AddSoloViewModel: BaseeAddModel
    {
        [Required]
        [Display(Name = "Field Allowance")]
        public int FA { get; set; }

    }
}
