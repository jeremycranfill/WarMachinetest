using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels
{
    public class AddSoloViewModel: BaseeAddModel
    {
        [Required]
        [Display(Name = "Field Allowance")]
        public int FA { get; set; }

        /*/    public List<SelectListItem> Abilities { get; set; } = new List<SelectListItem>();

            public int AbilityID { get; set; }

            public AddSoloViewModel() { }

            public AddSoloViewModel(List<Ability> abilityList)
            {
                foreach (Ability ability in abilityList)
                {
                    Abilities.Add(new SelectListItem
                    {
                        Value = ability.ID.ToString(),
                        Text = ability.Name



                    }



                        );




                }
               
    }
        /*/

    }
}
