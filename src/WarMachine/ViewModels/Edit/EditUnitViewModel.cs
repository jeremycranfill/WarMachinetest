using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WarMachine.Models.WarModels;

namespace WarMachine.ViewModels.Edit
{
    public class EditUnitViewModel : UnitModel
    {


        public EditUnitViewModel() { }

        public EditUnitViewModel(List<Ability> abilityList)
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
        

       new public List<SelectListItem> Abilities { get; set; } = new List<SelectListItem>();

      








    }
    }

