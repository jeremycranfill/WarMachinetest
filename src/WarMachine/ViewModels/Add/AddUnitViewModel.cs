using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WarMachine.Models.WarModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WarMachine.ViewModels
{
    public class AddUnitViewModel : BasedModelViewModel
    {

        public AddUnitViewModel() { }
        public AddUnitViewModel(IList<Ability> abills, IList<Weapon> weapons, IList<Spell> spells)
        {

            allAbills = new List<SelectListItem>();
            foreach (var abil in abills)
            {
                var item = new SelectListItem
                {
                    Value = abil.ID.ToString(),
                    Text = abil.Name
                };

                allAbills.Add(item);
            }



            allWeaps = new List<SelectListItem>();
            foreach (var weapon in weapons)
            {
                var item = new SelectListItem
                {
                    Value = weapon.ID.ToString(),
                    Text = weapon.Name
                };

                allWeaps.Add(item);
            }

            allSpells = new List<SelectListItem>();
            foreach (var spell in spells)
            {
                var item = new SelectListItem
                {
                    Value = spell.ID.ToString(),
                    Text = spell.Name
                };

                allSpells.Add(item);
            }

        }












        [Required]
        [Display(Name = "Min Unit Size")]
        public int MinUnit { get; set; }


        [Required]
        [Display(Name = "Max Unit Size")]
        public int MaxUnit { get; set; }


   




    }
}
