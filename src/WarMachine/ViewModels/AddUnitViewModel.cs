using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WarMachine.ViewModels
{
    public class AddUnitViewModel : BaseeAddModel
    {
        [Required]
        [Display(Name = "Min Unit Size")]
        public int MinUnit { get; set; }


        [Required]
        [Display(Name = "Max Unit Size")]
        public int MaxUnit { get; set; }


        [Required]
        [Display(Name = "Field Allowance")]
        public int FA { get; set; }




    }
}
