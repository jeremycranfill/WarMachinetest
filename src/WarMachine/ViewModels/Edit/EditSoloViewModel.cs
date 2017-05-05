using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels.Edit
{
    public class EditSoloViewModel
    {


        public EditSoloViewModel() { }

        public EditSoloViewModel(List<Ability> abilityList)
        {
            foreach (Ability ability in abilityList)
            {
                Abilities.Add(new SelectListItem
                {
                    Value = ability.ID.ToString(),
                    Text = ability.Name



                });

            }
        }




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

        [Required]
        [Display(Name = "Field Allowance")]
        public int FA { get; set; }

        public int ID { get; set; }


        public List<SelectListItem> Abilities { get; set; } = new List<SelectListItem>();

        public int AbilityID { get; set; }









    }
    }

