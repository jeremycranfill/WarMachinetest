using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels.Edit
{
    public class EditAbillityViewModel
    {

        //this might not be needed
        /*/
        public AddAbilityViewModel() {}
        public AddAbilityViewModel(IList<Ability> AbilityList)
        {
            Abilities = new List<SelectListItem>();
            foreach (var abil in AbilityList)

            {

                Abilities.Add(
                new SelectListItem
                {
                    Value = abil.ID.ToString(),
                    Text = abil.Name



                }
                );


            }
            




        }
        /*/

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public List<SelectListItem> Abilities { get; set; } = new List<SelectListItem>();

        public int SoloId { get; set; }

    }
}
