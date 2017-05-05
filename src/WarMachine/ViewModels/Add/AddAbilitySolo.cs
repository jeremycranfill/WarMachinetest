using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels.Add
{
    public class AddAbilitySolo
    {



        public IList<SelectListItem> Abilities { get; set; }
        [Required]
        public int SoloID { get; set; }
        [Required]
        public int AbilityID { get; set; }



        public AddAbilitySolo() { }
        public AddAbilitySolo(IList<Ability> AbilityList)
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

    }
}